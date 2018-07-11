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
    public class InsuranceInfromationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InsuranceInfromations
        public ActionResult Index()
        {
            var insuranceInfromation = db.InsuranceInfromation.Include(i => i.Driver);
            return View(insuranceInfromation.ToList());
        }

        // GET: InsuranceInfromations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceInfromation insuranceInfromation = db.InsuranceInfromation.Find(id);
            if (insuranceInfromation == null)
            {
                return HttpNotFound();
            }
            return View(insuranceInfromation);
        }

        // GET: InsuranceInfromations/Create
        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(db.Driver, "DriverId", "FirstName");
            return View();
        }

        // POST: InsuranceInfromations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsuranceInformationId,DriverId,InsuranceProvider,Expiration_Date")] InsuranceInfromation insuranceInfromation)
        {
            if (ModelState.IsValid)
            {
                db.InsuranceInfromation.Add(insuranceInfromation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverId = new SelectList(db.Driver, "DriverId", "FirstName", insuranceInfromation.DriverId);
            return View(insuranceInfromation);
        }

        // GET: InsuranceInfromations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceInfromation insuranceInfromation = db.InsuranceInfromation.Find(id);
            if (insuranceInfromation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(db.Driver, "DriverId", "FirstName", insuranceInfromation.DriverId);
            return View(insuranceInfromation);
        }

        // POST: InsuranceInfromations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsuranceInformationId,DriverId,InsuranceProvider,Expiration_Date")] InsuranceInfromation insuranceInfromation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuranceInfromation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverId = new SelectList(db.Driver, "DriverId", "FirstName", insuranceInfromation.DriverId);
            return View(insuranceInfromation);
        }

        // GET: InsuranceInfromations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceInfromation insuranceInfromation = db.InsuranceInfromation.Find(id);
            if (insuranceInfromation == null)
            {
                return HttpNotFound();
            }
            return View(insuranceInfromation);
        }

        // POST: InsuranceInfromations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsuranceInfromation insuranceInfromation = db.InsuranceInfromation.Find(id);
            db.InsuranceInfromation.Remove(insuranceInfromation);
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
