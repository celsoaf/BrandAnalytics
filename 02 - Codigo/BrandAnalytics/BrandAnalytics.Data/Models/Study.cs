using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
