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
        public void DeleteBySubs(long IdSubs, User user)
        {
            using (var session = Helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var obj = session.QueryOver<UserSubs>()
                    .And(us => us.UserId == user.Id)
                    .And(us=>us.SubsId == IdSubs)
                    .SingleOrDefault();
                    
                    if (obj != null)
                    {
                        session.Delete(obj);
                        transaction.Commit();
                    }
                }
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
