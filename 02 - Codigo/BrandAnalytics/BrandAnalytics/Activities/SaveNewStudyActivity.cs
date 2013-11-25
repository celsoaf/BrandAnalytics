using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandAnalytics.Data.Models;
using BrandAnalytics.Data.Enums;

namespace BrandAnalytics.Activities
{
    public class SaveNewStudyActivity : CodeActivity
    {
        public InArgument<string> UserName { get; set; }
        public InOutArgument<string> Mark { get; set; }
        public OutArgument<int> StudyId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var userName = UserName.Get(context);
                var mark = Mark.Get(context);

                var client = ctx.Clients.FirstOrDefault(c => c.UserName == userName);
                if (client != null)
                {
                    var study = new Study()
                    {
                        Mark = mark,
                        State = StudyState.Waiting
                    };

                    client.Studies.Add(study);

                    ctx.SaveChanges();

                    StudyId.Set(context, study.Id);
                }
            }
        }
    }
}