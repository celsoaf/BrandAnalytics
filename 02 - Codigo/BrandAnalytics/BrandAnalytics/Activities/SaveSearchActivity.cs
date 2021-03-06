﻿using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandAnalytics.Data.Enums;
using BrandAnalytics.Data.Models;

namespace BrandAnalytics.Activities
{
    public class SaveSearchActivity : CodeActivity
    {
        public InArgument<int> StudyId { get; set; }
        public InArgument<string> UserName { get; set; }
        public InArgument<string[]> Topics { get; set; }
        public InArgument<TimeSpan> Duration { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var id = StudyId.Get(context);

                var study = ctx.Studies.FirstOrDefault(s => s.Id == id);
                if (study != null && study.State != StudyState.Canceled)
                {
                    var userName = UserName.Get(context);
                    //study.EmployeeUserName = userName;
                    study.Employee = ctx.Clients.FirstOrDefault(c => c.UserName == userName);

                    study.Duration = Duration.Get(context);

                    foreach (var item in study.Topics.ToList())
                    {
                        study.Topics.Remove(item);
                        ctx.Topics.Remove(item);
                    }

                    var topics = Topics.Get(context);
                    foreach (var item in topics)
                        study.Topics.Add(new StudyTopic() { Name = item });


                    study.State = Data.Enums.StudyState.Collecting;

                    ctx.SaveChanges();
                }
            }
        }
    }
}