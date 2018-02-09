using CalcDB.Repositories;

namespace CalcDB.Models
{
    public class Role : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
