using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BrandAnalytics.Data.Enums;

namespace BrandAnalytics.Contracts
{
    [ServiceContract]
    public interface IBrandAnalyticsClientService
    {
        [OperationContract]
        int RequestStudy(string userName, string mark);

        [OperationContract]
        StudyState GetState(int token);

        [OperationContract]
        void CancelStudy(int token);
    }
}
