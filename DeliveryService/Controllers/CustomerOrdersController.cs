using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryService.Models;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Stripe;


namespace DeliveryService.Controllers
{
    public class CustomerOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Stripe()
        {
            var PublishableKey = ConfigurationManager.AppSettings["pk_test_c1nYrefZZ9bdIDYx1qebUDkW"];
            ViewBag.PublishableKey = "pk_test_c1nYrefZZ9bdIDYx1qebUDkW";

            return View();
        }

        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            StripeConfiguration.SetApiKey("sk_test_qr62mLZFuJTOcHMbasoeZlgX");

            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 800,
                Description = "Item Charge",
                Currency = "usd",
            CustomerId = customer.Id

            });

        return View();
    }
        public ActionResult Payment()
        {
            return View();
        }

        // GET: CustomerOrders
        public ActionResult Index()
        {
            return View(db.CustomerOrder.ToList());
        }

       

        // GET: CustomerOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrder.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // GET: CustomerOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerId,RestaurantName,ItemOrdered,Quantity,Date_of_Order,CurbeSide,WalkIn,Tips")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                db.CustomerOrder.Add(customerOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerOrder);
        }

        // GET: CustomerOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrder.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // POST: CustomerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,RestaurantName,ItemOrdered,Quantity,Date_of_Order,CurbeSide,WalkIn,Tips")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerOrder);
        }

        // GET: CustomerOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrder.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // POST: CustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerOrder customerOrder = db.CustomerOrder.Find(id);
            db.CustomerOrder.Remove(customerOrder);
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
