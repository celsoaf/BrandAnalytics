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

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        [ForeignKey("Id")]
        public virtual StudyReport Report { get; set; }

        [ForeignKey("Client")]
        public string ClientUserName { get; set; }

        [ForeignKey("ClientUserName")]
        public Client Client { get; set; }
    }
}
