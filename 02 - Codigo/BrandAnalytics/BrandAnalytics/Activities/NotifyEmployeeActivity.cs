using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandAnalytics.Data.Enums;
using BrandAnalytics.Data.Models;
using BrandAnalytics.Infrastructure.Services;

namespace BrandAnalytics.Activities
{
    public class NotifyEmployeeActivity : CodeActivity
    {
        public InArgument<int> StudyId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var id = StudyId.Get(context);

                var study = ctx.Studies.FirstOrDefault(s => s.Id == id);
                if (study != null)
                {
                    study.Employee.Notifications.Add(new Notification()
                    {
                        Subject = string.Format("Study {0} in state {1}", study.Mark, study.State),
                        Body = string.Format("Study {0} in state {1}", study.Mark, study.State)
                    });
                    //emailService.Send(study.Client.Email,
                    //            string.Format("Study {0} in state {1}", study.Mark, study.State),
                    //            string.Format("Body"));


                    ctx.SaveChanges();
                }
            }
        }
    }
}