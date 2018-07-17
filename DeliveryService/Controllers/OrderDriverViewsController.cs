using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliveryService.Controllers
{
    public class OrderDriverViewsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: OrderDriverViews
        public ActionResult Index()
        {
            return View(db.OrderDriverView);
        }

        public ActionResult Accept()
        {
            return View();
        }
    }
}