using BrandAnalytics.Data.Models;
using BrandAnalytics.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            IList<StudyClientModel> list = null;
            using (var ctx = new BrandAnalyticsDB())
            {
                var user = ctx.Clients.FirstOrDefault(c => c.UserName == userName);
                if (user != null)
                {
                    list = user.Studies.Select(TranslateStudie)
                    .ToList();
                }
            }

            return View(list);
        }

        //
        // GET: /Study/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Study/Create

        public ActionResult Create()
        {
            var model = new StudyClientModel();

            return View(model);
        }

        //
        // POST: /Study/Create

        [HttpPost]
        public ActionResult Create(StudyClientModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new BrandAnaliticsClient.BrandAnalyticsClientServiceClient())
                    {
                        var token = service.RequestStudy(User.Identity.Name, model.Mark);

                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
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
                    .Select(TranslateStudie)
                    .FirstOrDefault();

                return View(model);
            }
        }

        //
        // POST: /Study/Delete/5

        [HttpPost]
        public ActionResult Cancel(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Study/Delete/5

        public ActionResult Delete(int id)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var model = ctx.Studies
                    .Where(s => s.Id == id)
                    .Select(TranslateStudie)
                    .FirstOrDefault();

                return View(model);
            }
        }

        //
        // POST: /Study/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var ctx = new BrandAnalyticsDB())
                {
                    var study = ctx.Studies.FirstOrDefault(s => s.Id == id);

                    if (study != null)
                    {
                        if (study.Report != null)
                        {
                            foreach (var item in study.Report.Terms)
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
            catch
            {
                return View();
            }
        }

        public StudyClientModel TranslateStudie(Study study)
        {
            using (var service = new BrandAnaliticsClient.BrandAnalyticsClientServiceClient())
            {
                var res = new StudyClientModel()
                {
                    Id=study.Id,
                    Mark=study.Mark,
                    Start=study.Start,
                    End=study.End,
                    State = study.State.ToString()
                };

                try
                {
                    res.State = service.GetState(study.Id);
                }
                catch { }

                return res;
            }
        }
    }
}
