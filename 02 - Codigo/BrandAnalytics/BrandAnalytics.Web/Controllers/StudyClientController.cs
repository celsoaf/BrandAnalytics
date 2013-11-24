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
                    list = user.Studies.Select(s => new StudyClientModel()
                    {
                        Id = s.Id,
                        Mark = s.Mark,
                        Start = s.Start,
                        End = s.End
                    })
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
                    .Select(s => new StudyClientModel()
                    {
                        Id = s.Id,
                        Mark = s.Mark,
                        Start = s.Start,
                        End = s.End
                    })
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
    }
}
