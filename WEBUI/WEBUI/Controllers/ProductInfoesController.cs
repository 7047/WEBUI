using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEBUI.Models;

namespace WEBUI.Controllers
{
    public class ProductInfoesController : Controller
    {
        private WEBUIEntities6 db = new WEBUIEntities6();

        // GET: ProductInfoes
        public ActionResult Index()
        {
            return View(db.ProductInfoes.ToList());
        }

        // GET: ProductInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo productInfo = db.ProductInfoes.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        // GET: ProductInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,CategoryName,Units,Price,Discount,ProductImage")] ProductInfo productInfo)
        {
            if (ModelState.IsValid)
            {
                db.ProductInfoes.Add(productInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productInfo);
        }

        // GET: ProductInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo productInfo = db.ProductInfoes.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        // POST: ProductInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,CategoryName,Units,Price,Discount,ProductImage")] ProductInfo productInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productInfo);
        }

        // GET: ProductInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo productInfo = db.ProductInfoes.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        // POST: ProductInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductInfo productInfo = db.ProductInfoes.Find(id);
            db.ProductInfoes.Remove(productInfo);
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
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                WEBUIEntities6 db = new WEBUIEntities6();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + ImageName);
                file.SaveAs(physicalPath);
                ProductInfo student = new ProductInfo();
                student.ProductName = Request.Form["ProductName"];
                student.CategoryName = Request.Form["CategoryName"];
                student.Units = int.Parse(Request.Form["Units"]);
                student.Price = int.Parse(Request.Form["Price"]);
                student.Discount = Request.Form["Discount"];

                student.ProductImage = ImageName;
                db.ProductInfoes.Add(student);
                db.SaveChanges();

            }
            return RedirectToAction("../ProductInfoes/Index/");
        }
    }
}
