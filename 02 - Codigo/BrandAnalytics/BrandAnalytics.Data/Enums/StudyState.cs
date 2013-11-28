using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Data.Enums
{
    public enum StudyState
    {
        Initial = 0,
        Waiting = 1,
        Collecting = 2,
        Collected = 3,
        Finished = 4,
        Canceled = 5
    }
}
