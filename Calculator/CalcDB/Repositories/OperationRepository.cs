using System;
using System.Collections.Generic;
using System.Linq;
using CalcDB.Models;

namespace CalcDB.Repositories
{
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public IList<Operation> GetBySubscription(Subscription subs)
        {
            throw new NotImplementedException();
        }

        public Operation GetOrCreate(string name)
        {
            var oper = ExecQuery($"[Name] = N'{name}'").FirstOrDefault();
            if(oper == null)
            {
                oper = new Operation()
                {
                    Name = name
                };
                Save(oper);
            }
            return oper;
        }
    }
}
