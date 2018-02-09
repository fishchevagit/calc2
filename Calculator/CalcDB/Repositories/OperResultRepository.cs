using System.Collections.Generic;
using CalcDB.Models;

namespace CalcDB.Repositories
{
    public class OperResultRepository : BaseRepository<OperationResult>, IOperResultRepository
    {
        public IEnumerable<OperationResult> GetByOperation(long Id)
        {
            return null;
        }

        public IEnumerable<OperationResult> GetByUsername(string username)
        {
            return ExecQuery(" [AuthorId] in (SELECT [Id] from [dbo].[User] WHERE "+
                "[Status] in (1, 4)  AND " +
                $"([Login] = N'{username}' OR [Email] = N'{username}') "
                + " )");
        }
    }
}
