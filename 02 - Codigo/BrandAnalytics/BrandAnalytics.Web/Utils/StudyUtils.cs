using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandAnalytics.Data.Models;
using BrandAnalytics.Web.Models;

namespace BrandAnalytics.Web.Utils
{
    public class StudyUtils
    {
        public static StudyModel TranslateStudie(Study study)
        {
            using (var service = new BrandAnalyticsClient.BrandAnalyticsServiceClient())
            {
                var res = new StudyModel()
                {
                    Id = study.Id,
                    Mark = study.Mark,
                    Duration = study.Duration,
                    State = study.State.ToString()
                };

                try
                {
                    res.State = service.GetState(study.Id);
                    res.Running = true;
                }
                catch { res.Running = false; }

                return res;
            }
        }
    }
}