using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TwitterSpy.Models
{
    [DataContract]
    public class ReportTermModel
    {
        [DataMember]
        public string Term { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}