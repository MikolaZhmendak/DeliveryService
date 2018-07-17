﻿using System;
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
    public class EmployersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
    
     public ActionResult AcceptedOrders()
        {
            var completedOrders = db.OrderDriverView.Find();
            return View(completedOrders);
        }

      public ActionResult Home()
        {
            return View();
        }
        // GET: Employers
        public ActionResult Index()
        {
            return View(db.Employer.ToList());
        }
        public ActionResult DriversView()
        {
            List<BackgroundCheck> driverCheck = db.BackgroundCheck.ToList();
            BackgroundViewModel backgroundVM = new BackgroundViewModel();
            List<BackgroundViewModel> backgroundListVm = driverCheck.Select(x => new BackgroundViewModel { FirstName = x.Driver.FirstName, LastName = x.Driver.LastName, PhoneNumber = x.Driver.PhoneNumber, InsuranceProvider = x.InsuranceProvider, ExpirationDate = x.ExpirationDate, DrivingLicence = x.DrivingLicence, LicenceState = x.LicenceState, VehicleType = x.VehicleType, VehicleYear = x.VehicleYear, Date_of_Birth = x.Date_of_Birth, Ssn = x.Ssn }).ToList();
            return View(backgroundListVm);
        }
        // GET: Employers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // GET: Employers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LasttName,PhoneNumber")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Employer.Add(employer);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(employer);
        }

        // GET: Employers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // POST: Employers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LasttName,PhoneNumber")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employer);
        }

        // GET: Employers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employer employer = db.Employer.Find(id);
            db.Employer.Remove(employer);
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
