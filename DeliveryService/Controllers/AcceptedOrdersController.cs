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
    public class AcceptedOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AcceptedOrders
        public ActionResult Index()
        {
            var acceptedOrder = db.AcceptedOrder.Include(a => a.Customer).Include(a => a.CustomerOrder);
            return View(acceptedOrder.ToList());
        }

        // GET: AcceptedOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcceptedOrder acceptedOrder = db.AcceptedOrder.Find(id);
            if (acceptedOrder == null)
            {
                return HttpNotFound();
            }
            return View(acceptedOrder);
        }

        // GET: AcceptedOrders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName");
            ViewBag.OrderId = new SelectList(db.CustomerOrder, "OrderId", "RestaurantName");
            return View();
        }

        // POST: AcceptedOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcceptedOrderId,CustomerId,OrderId,Yes,No")] AcceptedOrder acceptedOrder)
        {
            if (ModelState.IsValid)
            {
                db.AcceptedOrder.Add(acceptedOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", acceptedOrder.CustomerId);
            ViewBag.OrderId = new SelectList(db.CustomerOrder, "OrderId", "RestaurantName", acceptedOrder.OrderId);
            return View(acceptedOrder);
        }

        // GET: AcceptedOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcceptedOrder acceptedOrder = db.AcceptedOrder.Find(id);
            if (acceptedOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", acceptedOrder.CustomerId);
            ViewBag.OrderId = new SelectList(db.CustomerOrder, "OrderId", "RestaurantName", acceptedOrder.OrderId);
            return View(acceptedOrder);
        }

        // POST: AcceptedOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcceptedOrderId,CustomerId,OrderId,Yes,No")] AcceptedOrder acceptedOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acceptedOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "FirstName", acceptedOrder.CustomerId);
            ViewBag.OrderId = new SelectList(db.CustomerOrder, "OrderId", "RestaurantName", acceptedOrder.OrderId);
            return View(acceptedOrder);
        }

        // GET: AcceptedOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcceptedOrder acceptedOrder = db.AcceptedOrder.Find(id);
            if (acceptedOrder == null)
            {
                return HttpNotFound();
            }
            return View(acceptedOrder);
        }

        // POST: AcceptedOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcceptedOrder acceptedOrder = db.AcceptedOrder.Find(id);
            db.AcceptedOrder.Remove(acceptedOrder);
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
