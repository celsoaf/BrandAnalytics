using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Contracts
{
    [ServiceContract]
    public interface IBrandAnalyticsInternalService
    {
        void SpyTopics(int studyid, string[] topics, TimeSpan duration);
    }
}
