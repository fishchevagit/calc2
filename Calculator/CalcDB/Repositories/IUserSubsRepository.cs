using CalcDB.Models;
using System.Collections.Generic;

namespace CalcDB.Repositories
{
    public interface IUserSubsRepository  : IRepository<UserSubs>
    {
        void DeleteBySubs(long IdSubs, User user);
    }
}
