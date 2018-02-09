using CalcDB.Repositories;
using CalcDB.Models;
using NHibernate.Criterion;
using System.Linq;

namespace CalcDB.NHibernate.Repositories
{
    public class NHUserRepository : NHBaseRepository<User>, IUserRepository
    {
        public bool Check(string login, string password)
        {
            using (var session = Helper.OpenSession())
            {
                var query = session.QueryOver<User>();
                query.And(u => u.Password == password);
                query.And(u => u.Status == UserStatus.Active || u.Status == UserStatus.System);
                query.And(u => u.Login == login || u.Email == login);

                return query.RowCount() == 1;
            }
        }

        public User GetByLogin(string login)
        {
            /*using (var session = Helper.OpenSession())
            {
                var criteria = session.CreateCriteria<User>();
                criteria.Add(
                    Restrictions.Or(
                        Restrictions.Eq("Email", login),
                        Restrictions.Eq("Login", login)
                    ));

                return criteria.UniqueResult<User>();
                //не верно возвращает юзера
            }*/
            using (var session = Helper.OpenSession())
            {
                return session.QueryOver<User>()
                    .And(u => u.Login == login || u.Email == login)
                    .SingleOrDefault();
            }
            // 😠
        }

        public static User AdminUser()
        {
            using (var session = Helper.OpenSession())
            {
                return session.QueryOver<User>()
                    .And(u => u.Status == UserStatus.System)
                    .SingleOrDefault();
            }
        }
    }
}
