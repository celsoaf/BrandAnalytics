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
        void SpyTopics(int token, string[] topics, TimeSpan duration);
        void RepeatSpyTopics(int token, string[] topics, TimeSpan duration);
        void Finalize(int token);
    }
}
