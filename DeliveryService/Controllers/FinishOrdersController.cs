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
    public class FinishOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FinishOrders
        public ActionResult Index()
        {
            var finishOrder = db.FinishOrder.Include(f => f.Customer);
            return View(finishOrder.ToList());
        }

        // GET: FinishOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishOrder finishOrder = db.FinishOrder.Find(id);
            if (finishOrder == null)
            {
                return HttpNotFound();
            }
            return View(finishOrder);
        }

        // GET: FinishOrders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName");
            return View();
        }

        // POST: FinishOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinishOrderId,CustomerId,Yes")] FinishOrder finishOrder)
        {
            if (ModelState.IsValid)
            {
                db.FinishOrder.Add(finishOrder);
                db.SaveChanges();
                return RedirectToAction("DriverHome", "Drivers");
            }

            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", finishOrder.CustomerId);
            return View(finishOrder);
        }

        // GET: FinishOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishOrder finishOrder = db.FinishOrder.Find(id);
            if (finishOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", finishOrder.CustomerId);
            return View(finishOrder);
        }

        // POST: FinishOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinishOrderId,CustomerId,Yes")] FinishOrder finishOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finishOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", finishOrder.CustomerId);
            return View(finishOrder);
        }

        // GET: FinishOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishOrder finishOrder = db.FinishOrder.Find(id);
            if (finishOrder == null)
            {
                return HttpNotFound();
            }
            return View(finishOrder);
        }

        // POST: FinishOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinishOrder finishOrder = db.FinishOrder.Find(id);
            db.FinishOrder.Remove(finishOrder);
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
