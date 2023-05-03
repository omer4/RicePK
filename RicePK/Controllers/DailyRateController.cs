using RicePK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RicePK.Controllers
{
   
    public class DailyRateController : Controller
    {
        private DataRicePKEntities db = new DataRicePKEntities();
        // GET: DailyRate
        public ActionResult Index()
        {
            return View();
        }
       
       
        public ActionResult Create( int id = 0)
        {
            DailyRateModel obj = new DailyRateModel();
            obj.DailyRateDate = DateTime.Now.Date;
            if (id != 0)
            {
                tblDailyRate PR = db.tblDailyRates.Where(x => x.DailyRateId == id).SingleOrDefault();
                obj.DailyRateId = PR.DailyRateId;
                obj.DailyRateDate = PR.DailyRateDate;
                obj.ProductId = PR.ProductId;
                obj.CityId = PR.CityId;
                obj.Min = PR.Min;
                obj.Max = PR.Max;
               
            }
            return View(obj);
        }
        [HttpGet]
        public JsonResult getsaledetailbyid(int id)
        {
            try
            {
                var st = db.tblDailyRates.Where(x => x.DailyRateId == id).SingleOrDefault();
               
                return Json(new { Master = st}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public JsonResult Save(DailyRateModel PR)
        {
            if (PR.DailyRateId != 0)
            {
                //Edit case
                tblDailyRate obj = db.tblDailyRates.Where(x => x.DailyRateId == PR.DailyRateId).SingleOrDefault();
                obj.DailyRateDate = PR.DailyRateDate;
                obj.DailyRateId = PR.DailyRateId;
                obj.CityId = PR.CityId;
                obj.ProductId = PR.ProductId;
                obj.Min = PR.Min;
                obj.Max = PR.Max;
               
               

                db.SaveChanges();

                return Json(PR, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblDailyRate obj = new tblDailyRate();
                obj.DailyRateDate = PR.DailyRateDate;
                obj.DailyRateId = PR.DailyRateId;
                obj.CityId = PR.CityId;
                obj.ProductId = PR.ProductId;
                obj.Min = PR.Min;
                obj.Max = PR.Max;
               
                db.tblDailyRates.Add(obj);
                db.SaveChanges();
                return Json(true);
            }

        }

       
        public ActionResult Displaylist(DailyRateModel a)
        {
            a.dtAllRecords = a.SelectAll();
            return View(a);
        }
        public JsonResult Delete(int id)
        {
            db.tblDailyRates.Remove(db.tblDailyRates.Where(x => x.DailyRateId == id).SingleOrDefault());
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}