using CalcDB.Repositories;
using System.Collections.Generic;
using System;

namespace CalcDB.Models
{
    /// <summary>
    /// Подписка
    /// </summary>
    public class Subscription : IEntity
    {
        public Subscription()
        {
            Users = new List<User>();
            Operations = new List<Operation>();
        }
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual double Price { get; set; }

        public virtual int Limit { get; set; }

        public virtual IList<User> Users { get;  set; }

        public virtual void AddUser(User user)
        {
            Users.Add(user);
            user.AddSubscription(this);  //?
        }

        public virtual IList<Operation> Operations { get; set; }

        public virtual void AddOperation(Operation operation)
        {
            Operations.Add(operation);
            operation.AddSubscription(this);
        }
    }

  
}
