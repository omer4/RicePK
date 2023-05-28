using RicePK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RicePK.Controllers
{
    //[SessionTimeOut]
    public class DailyRateListController : Controller
    {
        DataRicePKEntities db = new DataRicePKEntities();
        // GET: DailyRateList
       
        public ActionResult Index()
        {
           
            
           
                
                return View();
          
           
        }
        [HttpGet]
        public JsonResult getdateRecord()
        {
            DailyRateModel a = new DailyRateModel();
           var obj = a.SelectAll();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}