using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandAnalytics.Data.Enums;

namespace BrandAnalytics.Data.Models
{
    public class Study
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Mark { get; set; }

        public StudyState State { get; set; }

        public TimeSpan? Duration { get; set; }

        public virtual IList<StudyTopic> Topics { get; set; }

        [ForeignKey("Id")]
        public virtual StudyReport Report { get; set; }

        public virtual Client Client { get; set; }

        public virtual Client Employee { get; set; }
    }
}
