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

        public IList<StudyTopic> Topics { get; set; }

        [ForeignKey("Id")]
        public virtual StudyReport Report { get; set; }

        [ForeignKey("Client")]
        public string ClientUserName { get; set; }

        [ForeignKey("ClientUserName")]
        public Client Client { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeUserName { get; set; }

        [ForeignKey("EmployeeUserName")]
        public Client Employee { get; set; }
    }
}
