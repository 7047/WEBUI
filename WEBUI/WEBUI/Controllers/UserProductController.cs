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
    public class UserProductController : Controller
    {
        private WEBUIEntities6 db = new WEBUIEntities6();

        // GET: UserProduct
        public ActionResult Index()
        {
            return View(db.ProductInfoes.ToList());
        }

        // GET: UserProduct/Details/5
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

        // GET: UserProduct/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UserProduct/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ProductName,CategoryName,Units,Price,Discount,ProductImage")] ProductInfo productInfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ProductInfoes.Add(productInfo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(productInfo);
        //}

        //// GET: UserProduct/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductInfo productInfo = db.ProductInfoes.Find(id);
        //    if (productInfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productInfo);
        //}

        //// POST: UserProduct/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,ProductName,CategoryName,Units,Price,Discount,ProductImage")] ProductInfo productInfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(productInfo).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(productInfo);
        //}

        //// GET: UserProduct/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductInfo productInfo = db.ProductInfoes.Find(id);
        //    if (productInfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productInfo);
        //}

        //// POST: UserProduct/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ProductInfo productInfo = db.ProductInfoes.Find(id);
        //    db.ProductInfoes.Remove(productInfo);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
