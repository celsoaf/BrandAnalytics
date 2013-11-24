using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using BrandAnalytics.Web.Models;
using WebMatrix.WebData;
using BrandAnalytics.Data.Models;

namespace BrandAnalytics.Web.Utils
{
    public class SimpleMembershipInitializer
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public static void Initialize()
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        public SimpleMembershipInitializer()
        {
            Database.SetInitializer<UsersContext>(null);

            try
            {
                using (var context = new UsersContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }

                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

                AddInitialData();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }

        private void AddInitialData()
        {
            var adminUser = Properties.Settings.Default.AdminUser;

            if (!WebSecurity.UserExists(adminUser))
            {
                WebSecurity.CreateUserAndAccount(adminUser, Properties.Settings.Default.AdminPassword);

                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    using (var ctx = new BrandAnalyticsDB())
                    {
                        ctx.Clients.Add(new Client()
                        {
                            UserName = adminUser,
                            Name = "Administrator",
                            Email = "test@brandanalitics.com"
                        });

                        ctx.SaveChanges();
                    }
                });
            }


            if (!Roles.RoleExists(ApplicationRoles.AuthorizationManage))
                Roles.CreateRole(ApplicationRoles.AuthorizationManage);

            foreach (var item in ApplicationRoles.Roles)
            {
                if (!Roles.IsUserInRole(adminUser, item))
                    Roles.AddUserToRole(adminUser, item);
            }
        }
    }
}