using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Data.Models
{
    public class Notification
    {
        public Notification()
        {
            Created = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public DateTime Created { get; set; }

        public virtual Client Client { get; set; }
    }
}
