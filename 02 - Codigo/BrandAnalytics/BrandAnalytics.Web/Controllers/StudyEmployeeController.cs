using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandAnalytics.Data.Models;
using BrandAnalytics.Web.Models;
using BrandAnalytics.Web.Utils;

namespace BrandAnalytics.Web.Controllers
{
    public class StudyEmployeeController : Controller
    {
        //
        // GET: /Study/

        public ActionResult Index()
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var list = ctx.Studies.Select(StudyUtils.TranslateStudie).ToList();

                return View(list);
            }
        }

    }
}
