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
    public class NHUserSubsRepository : NHBaseRepository<UserSubs>, IUserSubsRepository
    {
        public UserSubs UserSubsByIdUserIdSubs(long IdSubs, User user)
        {
            using (var session = Helper.OpenSession())
            {
               
                var query = session.QueryOver<UserSubs>();
                query.And(us => us.User.Id == user.Id);

                query.And(us => us.Subscription.Id == IdSubs);
               

                return query.SingleOrDefault();

                
            }
           
        }

       

        UserSubs IRepository<UserSubs>.Get(long Id)
        {
            throw new NotImplementedException();
        }

        IList<UserSubs> IRepository<UserSubs>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
