using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            TradingModel objProductModel = new TradingModel();
            objProductModel.ProductData = new Product();
            objProductModel.ProductData = GetChartData();
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
    }
}