using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class ChartController : Controller
    {
        public DataTable results = new DataTable();
        public DataTable resultsTrend = new DataTable();
        public DataTable resultsHistoria = new DataTable();
        private static string _schemaName;

        //public string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=charts.drawing;Integrated Security=True";
        public string connString = null;//"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=charts.drawing;Integrated Security=True";


        //zapytania pomocnicze
        public string queryIPT = "select distinct IPT from GodzinyKontowaneP_Podsumowanie where xIPT = 1 order by IPT";
        public string queryPeriod = "select distinct Period_Year Parametr,left(Period_Year, 4)+'-'+right(Period_Year,2) Etykieta from " + _schemaName + "GodzinyKontowaneP_Podsumowanie where Period_Year is not null order by Etykieta desc";

        //gotowe zapytanie pod jeden wykres a dokladnie TREND
        public string queryTrend = "select * ,[SBRK] + [SLHIPA] as PośrednioProdukcyjne,[SLHDPA] as BezpośrednioProdukcyjne,[SOT] as Nadgodziny,[SLT] as Nieobecności,[SBRK] + [SLHIPA] + [SLHDPA] as Wszystkie,([SBRK] + [SLHIPA])/([SBRK] + [SLHIPA] + [SLHDPA]) DOIi " +
                                    "from " + _schemaName + "GodzinyKontowaneP_Podsumowanie," +
                                    "(select distinct Period_Year Parametr,left(Period_Year, 4)+'-'+right(Period_Year,2) Etykieta from GodzinyKontowaneP_Podsumowanie where Period_Year is not null ) as periodsProcedure " +
                                    "where xIPT = 1 and x = 2 and Period_Year = periodsProcedure.Parametr;";

        //zapytanie gotowe dla HISTORIA
        public string queryHistoria = "select *, [SBRK] + [SLHIPA] as PośrednioProdukcyjne, [SLHDPA] as BezpośrednioProdukcyjne, [SOT] as Nadgodziny, [SLT] as Nieobecności, [SBRK] + [SLHIPA] + [SLHDPA] as Wszystkie, ([SBRK] + [SLHIPA])/([SBRK] + [SLHIPA] + [SLHDPA]) DOIi " +
                                      "from " + _schemaName + "GodzinyKontowaneP_Podsumowanie," +
                                      "(select distinct Period_Year Parametr,left(Period_Year, 4)+'-'+right(Period_Year,2) Etykieta from GodzinyKontowaneP_Podsumowanie where Period_Year is not null ) as periodsProcedure " +
                                      "where Period_Year = periodsProcedure.Parametr and xIPT =1 order by C";

        public ActionResult Chart1()
        {
            GetConnectionStringAndSchemaIfExist();
            HistoryModel objProductModel = new HistoryModel();
            objProductModel.HistoryDatas = new History();
            // objProductModel.HistoryDatas = resultsHistoria;
            objProductModel.YearTitle = "Year";
            objProductModel.ImportsTitle = "Imports";
            objProductModel.ExportsTitle = "Exports";

            return View(objProductModel);
        }


        //for history
        public ActionResult ChartHistory()
        {
            GetConnectionStringAndSchemaIfExist();
            HistoryModel objProductModel = new HistoryModel();
            objProductModel.HistoryDatas = new History();
            // objProductModel.HistoryDatas = resultsHistoria;
            objProductModel.YearTitle = "Year";
            objProductModel.ImportsTitle = "Imports";
            objProductModel.ExportsTitle = "Exports";

            return View(objProductModel);
        }

        public ActionResult ChartExample()
        {
            return View();
        }

        public void getIPT()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand(queryIPT, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
        }

        public void getTrend()
        {
            using (SqlConnection conn1 = new SqlConnection(connString))
            using (SqlCommand command1 = new SqlCommand(queryTrend, conn1))
            using (SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command1))
                dataAdapter1.Fill(resultsTrend);
        }

        public void gethistory()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand(queryTrend, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(resultsHistoria);
        }

        public void GetConnectionStringAndSchemaIfExist()
        {
            connString = ConfigurationManager.AppSettings["connectionString"];
            _schemaName = ConfigurationManager.AppSettings["schemaName"];

        }

        //konwersja na JSON z DB, teraz funkcja przekazujaca to jako json'a do wykresu;
        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        public string GetChartTrend()
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(resultsTrend);
            return JSONString;
        }
        public JsonResult GetChartHistory()
        {
            var JSONString = string.Empty;

            //List<History> JSONString = new List<History>();
            GetConnectionStringAndSchemaIfExist();
            gethistory();
            var tmphistory = resultsHistoria;
            //JSONString = ConvertDataTable<History>(resultsHistoria);

            JSONString = JsonConvert.SerializeObject(resultsHistoria);
            return Json(new { JSONList = JSONString }, JsonRequestBehavior.AllowGet);
            //return JSONString;
        }

        public string GetChartDataHistory()
        {
            GetConnectionStringAndSchemaIfExist();
            gethistory();
            var tmphistory = resultsHistoria;

            var chartData = new object[tmphistory.Rows.Count + 1];

            double x, y;
            int j = 0;
            foreach (DataRow i in tmphistory.Rows)
            {
                j++;
                var dateWithoutHours = i.ItemArray[0].ToString().Split(' ')[0];
                chartData[j] = new object[] {
                    //i.ItemArray[0].ToString(), //data od 
                    dateWithoutHours,
                    Double.TryParse(i.ItemArray[41].ToString(), out x)?x:0, //PośrednioProdukcyjne
                    Double.TryParse(i.ItemArray[42].ToString(), out y)?y:0 //Bez----||------
                };
            }
            //return chartData;
            return JsonConvert.SerializeObject(chartData);
        }

        public ActionResult ChartTrend()
        {
            GetConnectionStringAndSchemaIfExist();
            HistoryModel objProductModel = new HistoryModel();
            objProductModel.HistoryDatas = new History();

            return View();
        }

        //"Trend Chart- SBRK, SLHiPA, SLDHPA, SOT and SLT",
        public string GetChartDataTrend()
        {
            GetConnectionStringAndSchemaIfExist();
            getTrend();
            var tmpTrend = resultsTrend;

            var chartData = new object[tmpTrend.Rows.Count + 1];

            double x, y,z,k,l;
            int j = 0;
            foreach (DataRow i in tmpTrend.Rows)
            {
                j++;
                var dateWithoutHours = i.ItemArray[0].ToString().Split(' ')[0];
                chartData[j] = new object[] {
                    //i.ItemArray[0].ToString(), //data od 
                    dateWithoutHours,
                    Double.TryParse(i.ItemArray[13].ToString(), out x)?x:0, //SBRK
                    Double.TryParse(i.ItemArray[14].ToString(), out y)?y:0, //SLHiPA
                    Double.TryParse(i.ItemArray[15].ToString(), out z)?z:0, //SLDHPA
                    Double.TryParse(i.ItemArray[16].ToString(), out k)?k:0, //SOT
                    Double.TryParse(i.ItemArray[17].ToString(), out l)?l:0 //SLT
                };
            }
            //return chartData;
            return JsonConvert.SerializeObject(chartData);
        }
    }
}