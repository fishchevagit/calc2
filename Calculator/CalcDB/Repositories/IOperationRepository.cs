using CalcDB.Models;
using System.Collections.Generic;

namespace CalcDB.Repositories
{
    public interface IOperationRepository : IRepository<Operation>
    {
        Operation GetOrCreate(string name);
        IList<Operation> GetBySubscription(Subscription subs);
    }
}
