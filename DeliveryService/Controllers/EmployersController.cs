using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryService.Models;
using System.Net.Mail;
using System.Text;

namespace DeliveryService.Controllers
{
    public class EmployersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
    
<<<<<<< HEAD
=======
        
     public JsonResult SendMailToUser()
        {
            bool result = false;
            result = SendEmail("zhmendakm@gmail.com", "Candidate Backgroundcheck Form", "<p>Hello Andy,<br /> I need to run a complete background check for the following candidate.<br/> First Name: If you have any questions please do not hesitate to contact us back. <br />  Regards Delivery Service Inc. </p>");


            return Json(result, JsonRequestBehavior.AllowGet);
        }
>>>>>>> 08eea61174789411d10062775d1b093b90c09d72

       public  ActionResult Email()
        {
<<<<<<< HEAD
            return Redirect("~/index.aspx");
=======
            try
            {

                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
               

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                client.Send(mailMessage);

                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
>>>>>>> 08eea61174789411d10062775d1b093b90c09d72
        }
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
