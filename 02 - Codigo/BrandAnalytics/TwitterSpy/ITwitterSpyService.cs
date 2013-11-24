using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TwitterSpy
{
    [ServiceContract]
    public interface ITwitterSpyService
    {
        [OperationContract]
        int SpyTopics(string topic, DateTime start, DateTime end);
    }
}
