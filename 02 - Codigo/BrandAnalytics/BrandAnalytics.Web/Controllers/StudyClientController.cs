using BrandAnalytics.Data.Models;
using BrandAnalytics.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandAnalytics.Web.Utils;

namespace BrandAnalytics.Web.Controllers
{
    [Authorize]
    public class StudyClientController : Controller
    {
        //
        // GET: /Study/

        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            IList<StudyModel> list = null;
            using (var ctx = new BrandAnalyticsDB())
            {
                var user = ctx.Clients.FirstOrDefault(c => c.UserName == userName);
                if (user != null)
                {
                    list = user.Studies.Select(StudyUtils.TranslateStudie)
                    .ToList();
                }
            }

            return View(list);
        }

        //
        // GET: /Study/Details/5

        public ActionResult Details(int id)
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

        //
        // GET: /Study/Create

        public ActionResult Create()
        {
            var model = new StudyModel();

            return View(model);
        }

        //
        // POST: /Study/Create

        [HttpPost]
        public ActionResult Create(StudyModel model)
        {
            if (ModelState.IsValid)
            {
                using (var service = new BrandAnalyticsClient.BrandAnalyticsServiceClient())
                {
                    var token = service.RequestStudy(User.Identity.Name, model.Mark);

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        //
        // GET: /Study/Delete/5

        public ActionResult Cancel(int id)
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

        //
        // POST: /Study/Delete/5

        [HttpPost]
        public ActionResult Cancel(int id, FormCollection collection)
        {
            using (var service = new BrandAnalyticsClient.BrandAnalyticsServiceClient())
            {
                service.CancelStudy(id);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Study/Delete/5

        public ActionResult Delete(int id)
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

        //
        // POST: /Study/Delete/5

        [HttpPost]
        public ActionResult Delete(StudyModel model)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var study = ctx.Studies.FirstOrDefault(s => s.Id == model.Id);

                if (study != null)
                {
                    if (study.Report != null)
                    {
                        foreach (var item in study.Report.Terms.ToList())
                        {
                            ctx.ReportTerms.Remove(item);
                        }
                        ctx.Reports.Remove(study.Report);
                    }
                    ctx.Studies.Remove(study);
                    ctx.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
