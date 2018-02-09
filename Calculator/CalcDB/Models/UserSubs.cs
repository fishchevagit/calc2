using CalcDB.Repositories;
using System.Collections.Generic;
using System;

namespace CalcDB.Models
{
    /// <summary>
    /// Подписка
    /// </summary>
    
    /// <summary>
    /// Подписки пользователя
    /// </summary>
    public class UserSubs : IEntity
    {
        public virtual long Id { get; set; }

        public virtual long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual long SubsId { get; set; }
        public virtual Subscription Subscription { get; set; }
    }

   
}
