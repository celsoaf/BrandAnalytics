﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Data.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Read { get; set; }

        public virtual Client Client { get; set; }
    }
}
