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
    public class ProductController : Controller
    {
        private DataRicePKEntities db = new DataRicePKEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.tblProducts.ToList());
        }

        // GET: Product/Details/5
        

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {


            ViewBag.Message = new SelectList(db.tblProductCategories, "ProductCategoryId", "ProductCategoryName");
                return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create(tblProduct tblProduct)
         {
            

            db.tblProducts.Add(tblProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            

            
        }

        // GET: Product/Edit/5
        public ActionResult Edit(long? Id)
        {
            ViewBag.Message = new SelectList(db.tblProductCategories, "ProductCategoryId", "ProductCategoryName");

            tblProduct pr = db.tblProducts.Where(x => x.ProductId == Id).FirstOrDefault();
            //List<string> list = db.tblProduct.Select(x => x.ProductName).ToList();
            //ViewBag.ProductName = new SelectList(list);

            return View(pr);
           
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                tblProduct pr = db.tblProducts.Where(x => x.ProductId == Id).FirstOrDefault();
                pr.ProductName = tblProduct.ProductName;
                pr.ProductCategoryId = tblProduct.ProductCategoryId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblProduct);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDailyRate DailyRate = db.tblDailyRates.Where(x => x.ProductId == id).SingleOrDefault();
            if(DailyRate!=null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tblProduct tblProduct = db.tblProducts.Find(id);
                if (tblProduct == null)
                {
                    return HttpNotFound();
                }
                return View(tblProduct);
            }
          
        }

        // POST: Product/Delete/5
        [HttpPost]
       
        public JsonResult DeleteConfirmed(long id)
        {
            tblDailyRate DailyRate = db.tblDailyRates.Where(x => x.ProductId == id).SingleOrDefault();
            if (DailyRate != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblProduct tblProduct = db.tblProducts.Find(id);
                db.tblProducts.Remove(tblProduct);
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
