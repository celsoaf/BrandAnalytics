using BrandAnalytics.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrandAnalytics.Web.Models
{
    public class StudyClientModel
    {
        public int Id { get; set; }

        [Required]
        public string Mark { get; set; }

        public string State { get; set; }

        public TimeSpan? Duration { get; set; }

        public bool Running { get; set; }
    }
}