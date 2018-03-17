using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebApplication1.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Helpers;

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

        public ActionResult Index()
        {
            GetConnectionStringAndSchemaIfExist();
            TradingModel objProductModel = new TradingModel();
            objProductModel.ProductData = new Product();
            objProductModel.ProductData = GetChartData();
            objProductModel.YearTitle = "Year";
            objProductModel.ImportsTitle = "Imports";
            objProductModel.ExportsTitle = "Exports";
            getIPT();
            getTrend();
            gethistory();
            var tmp = results;
            var tmptrend = resultsTrend;
            var tmphistory = resultsHistoria;

            var tmpJsonTrend = DataTableToJSONWithJSONNet(tmptrend);

            return View(objProductModel);
        }

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
        public ActionResult Chart2()
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
        public Product GetChartData()
        {
            Product objproduct = new Product();
            //we can replace this code with database data.
            objproduct.Year = "2009,2010,2011,2012,2013,2014";
            objproduct.Imports = "2000,1000,3000,1500,2300,500";
            objproduct.Exports = "2100,1400,2900,2400,2300,1500";
            return objproduct;
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
        public string GetChartHistory()
        {
            var JSONString= string.Empty;
            
            //List<History> JSONString = new List<History>();
            GetConnectionStringAndSchemaIfExist();
            gethistory();
            var tmphistory = resultsHistoria;
            //JSONString = ConvertDataTable<History>(resultsHistoria);

            JSONString = JsonConvert.SerializeObject(resultsHistoria);
            //return Json(new { JSONList = JSONString }, JsonRequestBehavior.AllowGet);
            return JSONString;
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}