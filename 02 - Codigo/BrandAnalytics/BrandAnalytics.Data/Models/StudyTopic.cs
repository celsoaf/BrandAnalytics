using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Data.Models
{
    public class StudyTopic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int StudyId { get; set; }

        public string Name { get; set; }

        [ForeignKey("StudyId")]
        public virtual Study Study { get; set; }
    }
}
