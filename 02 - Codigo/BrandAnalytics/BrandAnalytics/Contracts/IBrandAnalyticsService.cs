using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Contracts
{
    [ServiceContract]
    public interface IBrandAnalyticsService
    {
        [OperationContract]
        int RequestStudy(string userName, string mark);

        [OperationContract]
        string GetState(int token);

        [OperationContract]
        void CancelStudy(int token);

        [OperationContract]
        void SpyTopics(string userName, int token, string[] topics, TimeSpan duration);

        [OperationContract]
        void RepeatSpyTopics(string userName, int token, string[] topics, TimeSpan duration);

        [OperationContract]
        void Finalize(int token);
    }
}
