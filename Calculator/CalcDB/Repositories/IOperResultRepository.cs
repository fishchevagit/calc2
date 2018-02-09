using CalcDB.Models;
using System.Collections.Generic;

namespace CalcDB.Repositories
{
    public interface IOperResultRepository : IRepository<OperationResult>
    {
        IEnumerable<OperationResult> GetByOperation(long Id);

        IEnumerable<OperationResult> GetByUsername(string username);
    }
}
