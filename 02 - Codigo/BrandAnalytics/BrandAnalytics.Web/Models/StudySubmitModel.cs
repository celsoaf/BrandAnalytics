using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandAnalytics.Web.Models
{
    public class StudySubmitModel
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public List<string> Topics { get; set; }
    }
}