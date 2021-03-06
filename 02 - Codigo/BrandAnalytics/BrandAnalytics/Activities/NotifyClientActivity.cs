﻿using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandAnalytics.Data.Enums;
using BrandAnalytics.Data.Models;

namespace BrandAnalytics.Activities
{
    public class NotifyClientActivity : CodeActivity
    {
        public InArgument<int> StudyId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (var ctx = new BrandAnalyticsDB())
            {
                var id = StudyId.Get(context);

                var study = ctx.Studies.FirstOrDefault(s => s.Id == id);
                if (study != null && study.State != StudyState.Canceled)
                {
                    study.Client.Notifications.Add(new Notification()
                    {
                        Subject = string.Format("Study {0}", study.Mark),
                        Body = string.Format("Study {0} id, {1} mark in state {2}", study.Id, study.Mark, study.State)
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