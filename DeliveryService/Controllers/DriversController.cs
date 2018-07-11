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
        public ActionResult Background([Bind(Include = "BackgroundId, DriverId, Date_of_Birth, Ssn")] BackgroundCheck backgroundCheck)
        {
            if (ModelState.IsValid)
            {
                db.BackgroundCheck.Add(backgroundCheck);
                db.SaveChanges();
                return RedirectToAction("Vehicle");
            }
            return View(backgroundCheck);
        }


        public ActionResult Vehicle(int? driverId)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.DriverId = driverId;

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vehicle([Bind(Include = "VehicleId, DriverId, DrivingLicence, LicenceState")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicle.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("InsuranceInformation");
            }
            return View(vehicle);
        }

        public ActionResult InsuranceInformation(int? driverId)
        {
            InsuranceInfromation insuranceInformation = new InsuranceInfromation();
            insuranceInformation.DriverId = driverId;
           

            return View(insuranceInformation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsuranceInformation([Bind(Include = "InsuranceInformationId, DriverId, InsuranceProvider,Expiration_Date")] InsuranceInfromation insuranceInformation)
        {
            if (ModelState.IsValid)
            {
                db.InsuranceInfromation.Add(insuranceInformation);
                db.SaveChanges();
                return RedirectToAction("Welcome");
            }
            return View(insuranceInformation);
        }

        public ActionResult Welcome()

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
