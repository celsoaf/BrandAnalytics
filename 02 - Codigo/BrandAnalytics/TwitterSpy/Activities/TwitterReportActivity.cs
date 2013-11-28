using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterSpy.Models;

namespace TwitterSpy.Activities
{
    public class TwitterReportActivity : CodeActivity
    {
        public InArgument<List<TopicModel>> TopicModels { get; set; }
        public OutArgument<ReportModel> Report { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var topics = TopicModels.Get(context);

            var report = new ReportModel()
            {
                Topics = topics.Select(t => t.Topic).ToList(),
                Tweets = topics.Sum(t => t.Tweets)
            };

            report.Authors = topics.SelectMany(t => t.Authors)
                                    .Distinct()
                                    .Count();

            report.Terms = topics.SelectMany(t => t.Terms)
                                    .GroupBy(t => t.Term)
                                    .Select(t => new ReportTermModel()
                                    {
                                        Term = t.Key,
                                        Count = t.Sum(t1 => t1.Count)
                                    })
                                    .OrderByDescending(t => t.Count)
                                    .Take(10)
                                    .ToList();

            Report.Set(context, report);
        }
    }
}