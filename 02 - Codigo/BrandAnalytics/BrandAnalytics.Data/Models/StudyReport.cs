using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Data.Models
{
    public class StudyReport
    {
        [Key]
        public int Id { get; set; }
        public int Tweets { get; set; }
        public int Authors { get; set; }
        public virtual IList<StudyTermReport> Terms { get; set; }

        [ForeignKey("Id")]
        public virtual Study Study { get; set; }
    }
}
