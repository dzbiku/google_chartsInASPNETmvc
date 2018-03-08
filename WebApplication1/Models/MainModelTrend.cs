using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    //GodzinyKontowaneP
    public class MainModelTrend
    {
        public DateTime? Od { get; set; }
        public DateTime? Do { get; set; }
        public int? C { get; set; }
        public int? O { get; set; }
        public DateTime? Data { get; set; }
        public int? Period { get; set; }
        public int? Rok { get; set; }
        public string Ipt { get; set; }
        public double? Brk { get; set; }
        public double? Lhipa { get; set; }
        public double? Lhdpa { get; set; }
        public double? Ot { get; set; }
        public double? Lt { get; set; }
        public double? Sbrk { get; set; }
        public double? Slhipa { get; set; }
        public double? Slhdpa { get; set; }
        public double? Sot { get; set; }
        public double? Slt { get; set; }
        public double? PlanWyk { get; set; }
        public double? PlanWykD { get; set; }
        public double? ProgWyk { get; set; }
        public double? Trend { get; set; }
        public double? MinCzas { get; set; }
        public double? Roznica { get; set; }
        public int? X { get; set; }
        public double? PlanDOI { get; set; }
        public double? PlanOT { get; set; }
        public double? PlanLT { get; set; }
        public double? pDOI { get; set; }
        public double? pOT { get; set; }
        public double? pLT { get; set; }
        public double? yPlanDOI { get; set; }
        public double? yPlanOT { get; set; }
        public double? yPlanLT { get; set; }
        public double? yDOI { get; set; }
        public double? yOT { get; set; }
        public double? yLT { get; set; }
        public int? xIPT { get; set; }
        public int? Period_Year { get; set; }
        public double? DOI { get; set; }
    }


    //for chart 'Trend'
    //Dodatkowe
    /* 	Parametr	Etykieta	PośrednioProdukcyjne	BezpośrednioProdukcyjne	Nadgodziny	Nieobecności	Wszystkie	DOIi  */

    public class TrendModel
    {
        public DateTime? Od { get; set; }
        public DateTime? Do { get; set; }
        public int? C { get; set; }
        public int? O { get; set; }
        public DateTime? Data { get; set; }
        public int? Period { get; set; }
        public int? Rok { get; set; }
        public string Ipt { get; set; }
        public double? Brk { get; set; }
        public double? Lhipa { get; set; }
        public double? Lhdpa { get; set; }
        public double? Ot { get; set; }
        public double? Lt { get; set; }
        public double? Sbrk { get; set; }
        public double? Slhipa { get; set; }
        public double? Slhdpa { get; set; }
        public double? Sot { get; set; }
        public double? Slt { get; set; }
        public double? PlanWyk { get; set; }
        public double? PlanWykD { get; set; }
        public double? ProgWyk { get; set; }
        public double? Trend { get; set; }
        public double? MinCzas { get; set; }
        public double? Roznica { get; set; }
        public int? X { get; set; }
        public double? PlanDOI { get; set; }
        public double? PlanOT { get; set; }
        public double? PlanLT { get; set; }
        public double? pDOI { get; set; }
        public double? pOT { get; set; }
        public double? pLT { get; set; }
        public double? yPlanDOI { get; set; }
        public double? yPlanOT { get; set; }
        public double? yPlanLT { get; set; }
        public double? yDOI { get; set; }
        public double? yOT { get; set; }
        public double? yLT { get; set; }
        public int? xIPT { get; set; }
        public int? Period_Year { get; set; }
        public double? DOI { get; set; }

        public double? Parametr { get; set; }
        public double? Etykieta { get; set; }
        public double? PośrednioProdukcyjne { get; set; }
        public double? BezpośrednioProdukcyjne { get; set; }
        public double? Nadgodziny { get; set; }
        public double? Nieobecności { get; set; }
        public double? Wszystkie { get; set; }
        public double? DOIi { get; set; }

    }

    //for chart 'History'
    public class HistoryModel
    {
        public DateTime? Od { get; set; }
        public DateTime? Do { get; set; }
        public int? C { get; set; }
        public int? O { get; set; }
        public DateTime? Data { get; set; }
        public int? Period { get; set; }
        public int? Rok { get; set; }
        public string Ipt { get; set; }
        public double? Brk { get; set; }
        public double? Lhipa { get; set; }
        public double? Lhdpa { get; set; }
        public double? Ot { get; set; }
        public double? Lt { get; set; }
        public double? Sbrk { get; set; }
        public double? Slhipa { get; set; }
        public double? Slhdpa { get; set; }
        public double? Sot { get; set; }
        public double? Slt { get; set; }
        public double? PlanWyk { get; set; }
        public double? PlanWykD { get; set; }
        public double? ProgWyk { get; set; }
        public double? Trend { get; set; }
        public double? MinCzas { get; set; }
        public double? Roznica { get; set; }
        public int? X { get; set; }
        public double? PlanDOI { get; set; }
        public double? PlanOT { get; set; }
        public double? PlanLT { get; set; }
        public double? pDOI { get; set; }
        public double? pOT { get; set; }
        public double? pLT { get; set; }
        public double? yPlanDOI { get; set; }
        public double? yPlanOT { get; set; }
        public double? yPlanLT { get; set; }
        public double? yDOI { get; set; }
        public double? yOT { get; set; }
        public double? yLT { get; set; }
        public int? xIPT { get; set; }
        public int? Period_Year { get; set; }
        public double? DOI { get; set; }

        public double? Parametr { get; set; }
        public double? Etykieta { get; set; }
        public double? PośrednioProdukcyjne { get; set; }
        public double? BezpośrednioProdukcyjne { get; set; }
        public double? Nadgodziny { get; set; }
        public double? Nieobecności { get; set; }
        public double? Wszystkie { get; set; }
        public double? DOIi { get; set; }
    }
}