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
    public class FacilitatorsController : Controller
    {
        private DataRicePKEntities db = new DataRicePKEntities();

        // GET: Facilitators
        public ActionResult Index()
        {
            return View(db.tblFacilitators.ToList());
        }

        // GET: Facilitators/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFacilitator tblFacilitator = db.tblFacilitators.Find(id);
            if (tblFacilitator == null)
            {
                return HttpNotFound();
            }
            return View(tblFacilitator);
        }

        // GET: Facilitators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facilitators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacilitatorId,FacilitatorName,ContactNumber,Address,Type")] tblFacilitator tblFacilitator)
        {
            if (ModelState.IsValid)
            {
                db.tblFacilitators.Add(tblFacilitator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblFacilitator);
        }

        // GET: Facilitators/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFacilitator tblFacilitator = db.tblFacilitators.Find(id);
            if (tblFacilitator == null)
            {
                return HttpNotFound();
            }
            return View(tblFacilitator);
        }

        // POST: Facilitators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacilitatorId,FacilitatorName,ContactNumber,Address,Type")] tblFacilitator tblFacilitator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFacilitator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblFacilitator);
        }

        // GET: Facilitators/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFacilitator tblFacilitator = db.tblFacilitators.Find(id);
            if (tblFacilitator == null)
            {
                return HttpNotFound();
            }
            return View(tblFacilitator);
        }

        // POST: Facilitators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblFacilitator tblFacilitator = db.tblFacilitators.Find(id);
            db.tblFacilitators.Remove(tblFacilitator);
            db.SaveChanges();
            return RedirectToAction("Index");
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
