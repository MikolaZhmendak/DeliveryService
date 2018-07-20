using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryService.Models;
using Microsoft.AspNet.Identity;

namespace DeliveryService.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        public ActionResult CustomerHome()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View(db.Restaurant.ToList());
        }

        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<Restaurant> RestaurantList = new List<Restaurant>();
            if (SearchBy == "ZipCode")
            {
                try
                {
                    int Zip = Convert.ToInt32(SearchValue);
                    RestaurantList = db.Restaurant.Where(x => x.ZipCode == Zip || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not A Valid ZipCode", SearchValue);

                }
                return Json(RestaurantList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                RestaurantList = db.Restaurant.Where(x => x.Name.Contains(SearchValue) || SearchValue == null).ToList();
                return Json(RestaurantList, JsonRequestBehavior.AllowGet);
            }
         }

        

       
        // GET: Customers
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var customer = db.Customer.Where(x => x.UserId == currentUserId).ToList();
            return View(db.Customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,Address,City,State,PostalCode,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {

                customer.UserId = User.Identity.GetUserId();
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("NewCustomer");
            }

            return View(customer);
        }


        public ActionResult NewCustomer()
        {
            return View();
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,Address,City,State,PostalCode,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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
