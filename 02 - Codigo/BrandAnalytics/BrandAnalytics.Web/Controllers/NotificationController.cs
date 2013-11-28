using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandAnalytics.Data.Models;

namespace BrandAnalytics.Web.Controllers
{
    public class NotificationController : Controller
    {
        //
        // GET: /Notification/

        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            using (var ctx = new BrandAnalyticsDB())
            {
                var user = ctx.Clients.FirstOrDefault(c => c.UserName == userName);
                if (user != null)
                {
                    var list = user.Notifications.ToList();

                    return View(list);
                }
            }

            return View();
        }

        //
        // GET: /Study/Delete/5

        public ActionResult Delete(int id)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var model = ctx.Notifications
                    .Where(s => s.Id == id)
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
                    var model = ctx.Notifications
                        .Where(s => s.Id == id)
                        .FirstOrDefault();

                    ctx.Notifications.Remove(model);

                    ctx.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
