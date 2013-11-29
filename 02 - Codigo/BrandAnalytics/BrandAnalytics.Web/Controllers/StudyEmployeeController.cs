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
            var model = new StudySubmitModel() { Id = id, Duration = 10 };

            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(StudySubmitModel model)
        {
            if (ModelState.IsValid)
            {
                using (var service = new BrandAnalyticsClient.BrandAnalyticsServiceClient())
                {
                    service.SpyTopics(model.Id, User.Identity.Name, model.Topics, model.Duration);

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Repeat(int id)
        {
            var model = new StudySubmitModel() { Id = id, Duration = 10 };

            return View(model);
        }

        [HttpPost]
        public ActionResult Repeat(StudySubmitModel model)
        {
            if (ModelState.IsValid)
            {
                using (var service = new BrandAnalyticsClient.BrandAnalyticsServiceClient())
                {
                    service.RepeatSpyTopics(model.Id, User.Identity.Name, model.Topics, model.Duration);

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public ActionResult Finalize(int id)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var model = ctx.Studies
                    .Where(s => s.Id == id)
                    .Select(StudyUtils.TranslateStudie)
                    .FirstOrDefault();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Finalize(int id, FormCollection collection)
        {
            using (var service = new BrandAnalyticsClient.BrandAnalyticsServiceClient())
            {
                service.Finalize(id);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
