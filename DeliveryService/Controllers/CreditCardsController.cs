using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliveryService.Controllers
{
    public class CreditCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CreditCards
        public ActionResult Create()
        {
            return View();
        }
        // POST: CustomerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditCardId,CreditCardNumber,CardType,ExparationDate,CVC")] CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                db.CreditCard.Add(creditCard);
                db.SaveChanges();
                return RedirectToAction("Charge");
            }

            return View(creditCard);
        }
    }
}