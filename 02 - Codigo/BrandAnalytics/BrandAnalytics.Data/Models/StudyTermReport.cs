﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Data.Models
{
    public class StudyTermReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int StudyId { get; set; }

        public string Term { get; set; }
        public int Count { get; set; }

        [ForeignKey("StudyId")]
        public virtual StudyReport Report { get; set; }
    }
}
