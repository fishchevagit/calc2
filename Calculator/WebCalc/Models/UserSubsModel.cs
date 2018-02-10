using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    //WebCalc.Models.UserSubsModel
    public class UserSubsModel
    {
        public IEnumerable<CalcDB.Models.Subscription> Subscriptions { get; set; }
        public IEnumerable<CalcDB.Models.User> Users { get; set; }
        public CalcDB.Models.User currentUser { get; set; }

        public IEnumerable<string> subsString { get; set; }
    }
}