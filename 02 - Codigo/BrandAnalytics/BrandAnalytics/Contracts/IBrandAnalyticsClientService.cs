﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Contracts
{
    [ServiceContract]
    public interface IBrandAnalyticsClientService
    {
        [OperationContract]
        int RequestStudy(string mark);

        [OperationContract]
        string GetState(int token);

        [OperationContract]
        void CancelStudy(int token);
    }
}