using CalcDB.Models;
using System.Collections.Generic;

namespace CalcDB.Repositories
{
    public interface IUserSubsRepository  : IRepository<UserSubs>
    {
         UserSubs UserSubsByIdUserIdSubs(long IdSubs, User user);
    }
}
