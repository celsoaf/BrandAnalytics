using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Data.Models
{
    public class BrandAnalyticsDB : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Study> Studies { get; set; }
    }
}
