using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TwitterSpy.Models;

namespace TwitterSpy
{
    [ServiceContract]
    public interface ITwitterSpyService
    {
        [OperationContract]
        StudyResult SpyTopics(string[] topics, DateTime start, DateTime end);
    }
}
