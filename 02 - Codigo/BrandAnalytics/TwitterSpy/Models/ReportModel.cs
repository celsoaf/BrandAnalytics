using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TwitterSpy.Models
{
    [DataContract]
    public class ReportModel
    {
        [DataMember]
        public IList<string> Topics { get; set; }
        [DataMember]
        public int Tweets { get; set; }
        [DataMember]
        public int Authors { get; set; }
        [DataMember]
        public IList<string> Terms { get; set; }
    }
}