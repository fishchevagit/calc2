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
    public class NHOperResultRepository : NHBaseRepository<OperationResult>, IOperResultRepository
    {
        public IEnumerable<OperationResult> GetByOperation(long Id)
        {
            using (var session = Helper.OpenSession())
            {
                return session.QueryOver<OperationResult>()
                        .And(it => it.Operation.Id == Id)
                    .List();
            }
        }

        public IEnumerable<OperationResult> GetByUsername(string username)
        {
            using (var session = Helper.OpenSession())
            {
                return session.QueryOver<OperationResult>()
                    .JoinQueryOver(it => it.Author)
                        .And(it => it.Login == username)
                    .List();
            }
        }
    }
}
