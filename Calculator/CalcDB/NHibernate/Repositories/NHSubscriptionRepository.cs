using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcDB.Models;
using NHibernate.Criterion;

namespace CalcDB.NHibernate.Repositories
{
    public class NHSubscriptionRepository : NHBaseRepository<Subscription>, ISubscriptionRepository
    {
        
        public IList<Subscription> GetByUser(User user)
        {
           
            using (var session = Helper.OpenSession())
            {
                User u = null;
                return session.QueryOver<Subscription>()
                        .Fetch(f => f.Users).Eager
                        .JoinAlias(f => f.Users, () => u)
                        .Where(() => u.Id == user.Id)
                        .List();
                
               /* return session.QueryOver<Subscription>()
                   .WithSubquery.Where(ss => ss.Id ==
                       QueryOver.Of<UserSubs>()
                       .Select(us => us.SubsId)
                       .Where(us => us.UserId == user.Id)
                       .As<long>())
                    .List(); */
            }
            
        }
        public Subscription GetByName(string name)
        {
            using (var session = Helper.OpenSession())
            {
                
                return session.QueryOver<Subscription>()
                        .Where(s => s.Name == name)
                        .SingleOrDefault();
            }
        }
    }
}
