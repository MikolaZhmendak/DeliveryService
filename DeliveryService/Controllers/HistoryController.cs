using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliveryService.Controllers
{
    public class HistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: History
        public ActionResult Index()
        {
            return View(db.CustomerOrder);
        }
    }
}