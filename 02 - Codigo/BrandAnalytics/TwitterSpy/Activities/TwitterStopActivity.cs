using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterSpy.Models;
using TwitterSpy.Services;

namespace TwitterSpy.Activities
{
    public class TwitterStopActivity : CodeActivity
    {
        public InArgument<ITwitterService[]> Instances { get; set; }
        public OutArgument<ReportModel> Report { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var instances = Instances.Get(context);

            var results = new List<TopicModel>();

            foreach (var item in instances)
            {
                results.Add(item.StopStreaming());
            }

            var report = new ReportModel()
            {
                Topics = results.Select(t => t.Topic).ToList(),
                Authors = results.Sum(t => t.Authors.Count),
                Tweets = results.Sum(t=>t.Tweets)
            };

            report.Terms = results.SelectMany(t => t.Terms)
                                    .GroupBy(t => t.Term)
                                    .OrderBy(t => t.Sum(t1 => t1.Count))
                                    .Take(10)
                                    .Select(t => t.Key)
                                    .ToList();

            Report.Set(context, report);
        }
    }
}