using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandAnalytics.Web.Utils
{
    public class ApplicationRoles
    {
        public const string AuthorizationManage = "Administrator";

        public static string[] Roles
        {
            get
            {
                var list = new List<string>();

                foreach (var item in typeof(ApplicationRoles).GetFields())
                    list.Add(item.GetValue(null).ToString());

                return list.ToArray();
            }
        }
    }
}