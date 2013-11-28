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

        public ActionResult Submit(int id)
        {
            var model = new StudySubmitModel() { Id = id };

            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(StudySubmitModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //using (var service = new BrandAnaliticsEmployee.BrandAnalyticsClientServiceClient())
                    //{
                    //    var token = service.;

                    //    return RedirectToAction("Index");
                    //}
                }
            }
            catch
            {
            }


            return View(model);
        }

        public ActionResult Repeat(int id)
        {
            return View();
        }

        public ActionResult Finalize(int id)
        {
            return View();
        }
    }
}
