﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ChartController : Controller
    {
        public DataTable results = new DataTable();
        public DataTable resultsTrend = new DataTable();
        public DataTable resultsHistoria = new DataTable();


        public string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=charts.drawing;Integrated Security=True";

        //zapytania pomocnicze
        public string queryIPT = "select distinct IPT from GodzinyKontowaneP_Podsumowanie where xIPT = 1 order by IPT";
        public string queryPeriod = "select distinct Period_Year Parametr,left(Period_Year, 4)+'-'+right(Period_Year,2) Etykieta from GodzinyKontowaneP_Podsumowanie where Period_Year is not null order by Etykieta desc";

        //gotowe zapytanie pod jeden wykres a dokladnie TREND
        public string queryTrend = "select * ,[SBRK] + [SLHIPA] as PośrednioProdukcyjne,[SLHDPA] as BezpośrednioProdukcyjne,[SOT] as Nadgodziny,[SLT] as Nieobecności,[SBRK] + [SLHIPA] + [SLHDPA] as Wszystkie,([SBRK] + [SLHIPA])/([SBRK] + [SLHIPA] + [SLHDPA]) DOIi " +
                                    "from GodzinyKontowaneP_Podsumowanie," +
                                    "(select distinct Period_Year Parametr,left(Period_Year, 4)+'-'+right(Period_Year,2) Etykieta from GodzinyKontowaneP_Podsumowanie where Period_Year is not null ) as periodsProcedure " +
                                    "where xIPT = 1 and x = 2 and Period_Year = periodsProcedure.Parametr;";

        //zapytanie gotowe dla HISTORIA
        public string queryHistoria = "select *, [SBRK] + [SLHIPA] as PośrednioProdukcyjne, [SLHDPA] as BezpośrednioProdukcyjne, [SOT] as Nadgodziny, [SLT] as Nieobecności, [SBRK] + [SLHIPA] + [SLHDPA] as Wszystkie, ([SBRK] + [SLHIPA])/([SBRK] + [SLHIPA] + [SLHDPA]) DOIi " +
                                      "from GodzinyKontowaneP_Podsumowanie," +
                                      "(select distinct Period_Year Parametr,left(Period_Year, 4)+'-'+right(Period_Year,2) Etykieta from GodzinyKontowaneP_Podsumowanie where Period_Year is not null ) as periodsProcedure " +
                                      "where Period_Year = periodsProcedure.Parametr and xIPT =1 order by C";

        public ActionResult Index()
        {
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
    }
}