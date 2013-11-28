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
    public class NotifyStateActivity : CodeActivity
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
                    var emailService = new EmailService();

                    switch (study.State)
                    {
                        case StudyState.Initial:
                            break;
                        case StudyState.Waiting:
                            break;
                        case StudyState.Collecting:
                            emailService.Send(study.Client.Email,
                                string.Format("Study {0} in state {1}", study.Mark, study.State),
                                string.Format("Body"));
                            break;
                        case StudyState.Collected:
                            emailService.Send(study.Employee.Email,
                                string.Format("Study {0} in state {1}", study.Mark, study.State),
                                string.Format("Body"));
                            break;
                        case StudyState.Finished:
                            emailService.Send(study.Client.Email,
                                string.Format("Study {0} in state {1}", study.Mark, study.State),
                                string.Format("Body"));
                            break;
                        case StudyState.Canceled:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}