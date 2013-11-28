using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterSpy.Models
{
    public class TopicModel
    {
        public TopicModel()
        {
            Authors = new List<string>();
            Terms = new List<TermModel>();
        }

        public string Topic { get; set; }
        public int Tweets { get; set; }
        public IList<string> Authors { get; set; }
        public IList<TermModel> Terms { get; set; }
    }
}