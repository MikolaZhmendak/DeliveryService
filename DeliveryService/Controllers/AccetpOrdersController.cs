using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class AccetpOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccetpOrders
        public ActionResult Index()
        {
            return View(db.AccetpOrder.ToList());
        }

        // GET: AccetpOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccetpOrder accetpOrder = db.AccetpOrder.Find(id);
            if (accetpOrder == null)
            {
                return HttpNotFound();
            }
            return View(accetpOrder);
        }

        // GET: AccetpOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccetpOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccetpOrderId,Yes,No")] AccetpOrder accetpOrder)
        {
            if (ModelState.IsValid)
            {
                db.AccetpOrder.Add(accetpOrder);
                db.SaveChanges();
                return RedirectToAction("OrderDriverViews", "Drivers");
            }

            return View(accetpOrder);
        }

        // GET: AccetpOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccetpOrder accetpOrder = db.AccetpOrder.Find(id);
            if (accetpOrder == null)
            {
                return HttpNotFound();
            }
            return View(accetpOrder);
        }

        // POST: AccetpOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccetpOrderId,Yes,No")] AccetpOrder accetpOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accetpOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accetpOrder);
        }

        // GET: AccetpOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccetpOrder accetpOrder = db.AccetpOrder.Find(id);
            if (accetpOrder == null)
            {
                return HttpNotFound();
            }
            return View(accetpOrder);
        }

        // POST: AccetpOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccetpOrder accetpOrder = db.AccetpOrder.Find(id);
            db.AccetpOrder.Remove(accetpOrder);
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
