using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandAnalytics.Models
{
    public class ReportModel
    {
        public IList<string> Topics { get; set; }
        public int Tweets { get; set; }
        public int Authors { get; set; }
        public IList<string> Terms { get; set; }
    }
}