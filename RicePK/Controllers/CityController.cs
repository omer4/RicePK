using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RicePK.Models;

namespace RicePK.Controllers
{
    [SessionTimeOut]
    public class CityController : Controller
    {
        

        private DataRicePKEntities db = new DataRicePKEntities();

        // GET: City
        public ActionResult Index()
        {
            return View(db.tblCities.ToList());
        }

        // GET: City/Details/5
        

        // GET: City/Create
        public ActionResult Create()
        {
            ViewBag.City = new SelectList(db.tblStates, "StateId", "StateName");
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,CityName,StateId")] tblCity tblCity)
        {
            if (ModelState.IsValid)
            {
                db.tblCities.Add(tblCity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCity);
        }

        // GET: City/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.City = new SelectList(db.tblStates, "StateId", "StateName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCity tblCity = db.tblCities.Find(id);
            if (tblCity == null)
            {
                return HttpNotFound();
            }
          

            return View(tblCity);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,CityName,StateId")] tblCity tblCity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCity);
        }

        // GET: City/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDailyRate dailyRate = db.tblDailyRates.Where(x => x.CityId == id).SingleOrDefault();

            if(dailyRate != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tblCity tblCity = db.tblCities.Find(id);
                if (tblCity == null)
                {
                    return HttpNotFound();
                }
                return View(tblCity);
            }

            
        }

        // POST: City/Delete/5
        [HttpPost]
       
        public JsonResult
            DeleteConfirmed(long id)
        {
            tblDailyRate dailyRate = db.tblDailyRates.Where(x => x.CityId == id).SingleOrDefault();

            if (dailyRate != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblCity tblCity = db.tblCities.Find(id);
                db.tblCities.Remove(tblCity);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
