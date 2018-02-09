using CalcDB.Repositories;
using System.Collections.Generic;
using System;

namespace CalcDB.Models
{
   

    /// <summary>
    /// Операции подписки
    /// </summary>
    public class SubsOperations : IEntity
    {
        public virtual long Id { get; set; }

        public virtual long SubsId { get; set; }
        public virtual Subscription Subscription { get; set; }

        public virtual long OperationId { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
