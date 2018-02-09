using CalcDB.Models;
using System.Collections.Generic;

namespace CalcDB.Repositories
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        IList<Subscription> GetByUser(User user);
    }
}
