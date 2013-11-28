using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandAnalytics.Data.Models;

namespace BrandAnalytics.Activities
{
    public class SaveReportActivity : CodeActivity
    {
        public InArgument<int> StudyId { get; set; }
        public InArgument<TwitterSpyService.ReportModel> Report { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var id = StudyId.Get(context);

                var study = ctx.Studies.FirstOrDefault(s => s.Id == id);
                if (study != null)
                {
                    if (study.Report == null)
                        study.Report = new StudyReport();

                    var report = Report.Get(context);

                    study.Report.Authors = report.Authors;
                    study.Report.Tweets = report.Tweets;
                    foreach (var item in report.Terms)
                    {
                        study.Report.Terms.Add(new StudyTermReport()
                        {
                            Term = item.Term,
                            Count = item.Count
                        });
                    }

                    study.State = Data.Enums.StudyState.Collected;

                    ctx.SaveChanges();
                }
            }
        }
    }
}