using RicePK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RicePK.Controllers
{
    
    public class DailyRateListController : Controller
    {
        DataRicePKEntities db = new DataRicePKEntities();
        // GET: DailyRateList
       
        public ActionResult Index()
        {

            DailyRateModel a = new DailyRateModel();


            return View(a);
          
           
        }
        [HttpPost]
        public PartialViewResult GetRecords(DateTime date,long[] productid=null,long[] cityid=null)
        {
            DailyRateModel a = new DailyRateModel();
            var obj = a.GetRates(date, productid, cityid);
            return PartialView(obj);
            //return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}