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
        public static void Initialize()
        {
            Database.SetInitializer<BrandAnalyticsDB>(
                new MigrateDatabaseToLatestVersion<BrandAnalyticsDB, Migrations.Configuration>());
        }

        public BrandAnalyticsDB()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Study>()
                .HasOptional(s => s.Report)
                .WithRequired(r => r.Study);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Studies)
                .WithRequired(s => s.Client);

            modelBuilder.Entity<Study>()
                .HasOptional(s => s.Employee);
        }

        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Study> Studies { get; set; }
        public IDbSet<StudyTopic> Topics { get; set; }
        public IDbSet<StudyReport> Reports { get; set; }
        public IDbSet<StudyTermReport> ReportTerms { get; set; }
        public IDbSet<Notification> Notifications { get; set; }
    }
}
