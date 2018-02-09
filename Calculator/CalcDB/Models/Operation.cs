using CalcDB.Repositories;
using System;
using System.Collections.Generic;

namespace CalcDB.Models
{
    public class Operation : IEntity
    {
        public Operation()
        {
            Subscriptions = new List<Subscription>();
        }
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        [Obsolete("Используйте свойство Owner", true)]
        public virtual long OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual IList<Subscription> Subscriptions { get; set; }
        public virtual void AddSubscription(Subscription subscription)
        {
            Subscriptions.Add(subscription);
            subscription.AddOperation(this);
        }
    }
}
