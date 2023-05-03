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
    public class BusinessDirectoriesController : Controller
    {
        private DataRicePKEntities db = new DataRicePKEntities();

        // GET: BusinessDirectories
        public ActionResult Index()
        {
            return View(db.tblBusinessDirectories.ToList());
        }

        // GET: BusinessDirectories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBusinessDirectory tblBusinessDirectory = db.tblBusinessDirectories.Find(id);
            if (tblBusinessDirectory == null)
            {
                return HttpNotFound();
            }
            return View(tblBusinessDirectory);
        }

        // GET: BusinessDirectories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessDirectories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BusinessName,Address,City,State,Country,Landline,Mobile,ContactPerson,ContactNumber,IsTrader,IsMiller,IsExporter,IsImporter,MillingCapacity,ThirdPartyProcessing")] tblBusinessDirectory tblBusinessDirectory)
        {
            if (ModelState.IsValid)
            {
                db.tblBusinessDirectories.Add(tblBusinessDirectory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblBusinessDirectory);
        }

        // GET: BusinessDirectories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBusinessDirectory tblBusinessDirectory = db.tblBusinessDirectories.Find(id);
            if (tblBusinessDirectory == null)
            {
                return HttpNotFound();
            }
            return View(tblBusinessDirectory);
        }

        // POST: BusinessDirectories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BusinessName,Address,City,State,Country,Landline,Mobile,ContactPerson,ContactNumber,IsTrader,IsMiller,IsExporter,IsImporter,MillingCapacity,ThirdPartyProcessing")] tblBusinessDirectory tblBusinessDirectory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBusinessDirectory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblBusinessDirectory);
        }

        // GET: BusinessDirectories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBusinessDirectory tblBusinessDirectory = db.tblBusinessDirectories.Find(id);
            if (tblBusinessDirectory == null)
            {
                return HttpNotFound();
            }
            return View(tblBusinessDirectory);
        }

        // POST: BusinessDirectories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblBusinessDirectory tblBusinessDirectory = db.tblBusinessDirectories.Find(id);
            db.tblBusinessDirectories.Remove(tblBusinessDirectory);
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
