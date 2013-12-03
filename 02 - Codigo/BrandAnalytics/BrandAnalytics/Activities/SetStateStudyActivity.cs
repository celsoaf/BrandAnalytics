using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandAnalytics.Data.Enums;
using BrandAnalytics.Data.Models;

namespace BrandAnalytics.Activities
{
    public class SetStateStudyActivity : CodeActivity
    {
        public InArgument<int> StudyId { get; set; }
        public InArgument<StudyState> State { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var id = StudyId.Get(context);

                var study = ctx.Studies.FirstOrDefault(s => s.Id == id);
                if (study != null && study.State != StudyState.Canceled)
                {
                    study.State = State.Get(context);
                    ctx.SaveChanges();
                }
            }
        }
    }
}