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
    public class DriversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


       
        public ActionResult OrderDriverViews()
        {
            List<CustomerOrder> orderCheck = db.CustomerOrder.Where(x => x.Date_of_Order >= DateTime.Today).ToList();
            
            CustomerOrderViewModel orderVM = new CustomerOrderViewModel();
            List<CustomerOrderViewModel> orderListVM = orderCheck.Select(x => new CustomerOrderViewModel { FirstName = x.Customer.FirstName, LastName = x.Customer.LastName, PhoneNumber = x.Customer.PhoneNumber, RestaurantName = x.RestaurantName, ItemOrdered = x.ItemOrdered, Quantity = x.Quantity, Date_of_Order =x.Date_of_Order,CurbeSide = x.CurbeSide, WalkIn = x.WalkIn, Tips = x.Tips }).ToList();

            return View(orderListVM);
        }

        public ActionResult AcceptedOrder()
        {
            List<CustomerOrder> orderCheck = db.CustomerOrder.Where(x => x.Date_of_Order >= DateTime.Today).ToList();

            CustomerOrderViewModel orderVM = new CustomerOrderViewModel();
            List<CustomerOrderViewModel> orderListVM = orderCheck.Select(x => new CustomerOrderViewModel { FirstName = x.Customer.FirstName, LastName = x.Customer.LastName, PhoneNumber = x.Customer.PhoneNumber, RestaurantName = x.RestaurantName, ItemOrdered = x.ItemOrdered, Quantity = x.Quantity, Date_of_Order = x.Date_of_Order, CurbeSide = x.CurbeSide, WalkIn = x.WalkIn, Tips = x.Tips }).ToList();

            return View(orderListVM);
        }


        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult DriverHome()
        {
            return View();
        }

        // GET: Drivers
        public ActionResult Index()
        {
            return View(db.Driver.ToList());
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Driver.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,FirstName,LastName,PhoneNumber,ZipCode")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Driver.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Background", new { driverId = driver.DriverId });
            }

            return View(driver);
        }


        public ActionResult Background(int? driverId)
        {
            BackgroundCheck backgroundCheck = new BackgroundCheck();
            backgroundCheck.DriverId = driverId;
            return View(backgroundCheck);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Background([Bind(Include = "BackgroundId, DriverId, Date_of_Birth, Ssn, VehicleType, VehicleYear, DrivingLicence, LicenceState, InsuranceProvider, ExpirationDate")] BackgroundCheck backgroundCheck)
        {
            if (ModelState.IsValid)
            {
                db.BackgroundCheck.Add(backgroundCheck);
                db.SaveChanges();
                return RedirectToAction("BackgroundConfirmation");
            }
            return View(backgroundCheck);
        }

        public ActionResult Welcome()

        {
          
            return View();
        }
        public ActionResult BackgroundConfirmation()
        {
            return View();
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Driver.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,FirstName,LastName,PhoneNumber,ZipCode")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Driver.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = db.Driver.Find(id);
            db.Driver.Remove(driver);
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
