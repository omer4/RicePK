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
    public class StateController : Controller
    {
        private DataRicePKEntities db = new DataRicePKEntities();

        // GET: State
        public ActionResult Index()
        {
            return View(db.tblStates.ToList());
        }

        // GET: State/Details/5
       

        // GET: State/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: State/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,StateName")] tblState tblState)
        {
            if (ModelState.IsValid)
            {
                db.tblStates.Add(tblState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblState);
        }

        // GET: State/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblState tblState = db.tblStates.Find(id);
            if (tblState == null)
            {
                return HttpNotFound();
            }
            return View(tblState);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,StateName")] tblState tblState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblState);
        }

        // GET: State/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCity City = db.tblCities.Where(x => x.StateId == id).SingleOrDefault();

            if (City != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tblState tblState = db.tblStates.Find(id);
                if (tblState == null)
                {
                    return HttpNotFound();
                }
                return View(tblState);
            }
           
        }

        // POST: State/Delete/5
        [HttpPost]
      
        public JsonResult DeleteConfirmed(long id)
        {
            tblCity City = db.tblCities.Where(x => x.StateId == id).SingleOrDefault();

            if (City != null)
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblState tblState = db.tblStates.Find(id);
                db.tblStates.Remove(tblState);
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
