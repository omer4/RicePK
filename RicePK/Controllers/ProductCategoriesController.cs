using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using RicePK.Models;

namespace RicePK.Controllers
{
    [SessionTimeOut]
    public class ProductCategoriesController : Controller
    {
        private DataRicePKEntities db = new DataRicePKEntities();

        // GET: ProductCategories
        public ActionResult Index()
        {
            return View(db.tblProductCategories.ToList());
        }

        // GET: ProductCategories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductCategory tblProductCategory = db.tblProductCategories.Find(id);
            if (tblProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblProductCategory);
        }

        // GET: ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCategoryId,ProductCategoryName")] tblProductCategory tblProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.tblProductCategories.Add(tblProductCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblProductCategory);
        }

        // GET: ProductCategories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductCategory tblProductCategory = db.tblProductCategories.Find(id);
            if (tblProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblProductCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCategoryId,ProductCategoryName")] tblProductCategory tblProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProductCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblProductCategory);
        }

        // GET: ProductCategories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct product = db.tblProducts.Where(x => x.ProductCategoryId == id).SingleOrDefault();
            if(product!=null)
            {
               
               
            }
            else
            {
                tblProductCategory tblProductCategory = db.tblProductCategories.Find(id);
                if (tblProductCategory == null)
                {
                    return HttpNotFound();
                }
                
            }


            return View();


        }

        // POST: ProductCategories/Delete/5
        [HttpPost]
        public JsonResult DeleteConfirmed(long id)
        {

            tblProduct product = db.tblProducts.Where(x => x.ProductCategoryId == id).SingleOrDefault();
            if (product != null)
            {
                return Json(false,JsonRequestBehavior.AllowGet);
               
            }
            else
            {

                tblProductCategory tblProductCategory = db.tblProductCategories.Find(id);
                db.tblProductCategories.Remove(tblProductCategory);
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
