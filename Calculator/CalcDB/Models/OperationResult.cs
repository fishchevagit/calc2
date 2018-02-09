using CalcDB.Repositories;
using System;

namespace CalcDB.Models
{
    public class OperationResult : IEntity
    {
        public virtual long Id { get; set; }

        [Obsolete("", true)]
        public virtual long OperationId { get; set; }

        public virtual Operation Operation { get; set; }

        public virtual string Args { get; set; }

        public virtual double? Result { get; set; }

        /// <summary>
        /// Продолжительность выполнения расчета, мс
        /// </summary>
        public virtual long ExecutionTime { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual string Error { get; set; }

        [Obsolete("", true)]
        public virtual long AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
