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
        [OperationContract]
        void SpyTopics(string userName, int token, string[] topics, TimeSpan duration);

        [OperationContract]
        void RepeatSpyTopics(string userName, int token, string[] topics, TimeSpan duration);

        [OperationContract]
        void Finalize(int token);
    }
}
