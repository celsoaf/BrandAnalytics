using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandAnalytics.Data.Models;

namespace BrandAnalytics.Web.Controllers
{
    public class ReportController : Controller
    {
        private BrandAnalyticsDB context = new BrandAnalyticsDB();

        //
        // GET: /Report/

        public ActionResult Index(int id)
        {
            var model = context.Studies.FirstOrDefault(s => s.Id == id);

            View(model);

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            context.Dispose();

            base.Dispose(disposing);
        }
    }
}
