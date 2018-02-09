using System.Collections.Generic;

namespace CalcDB.Repositories
{
    public interface IRepository<T>
        where T : IEntity
    {
        T Get(long Id);

        void Save(T result);

        void Delete(long Id);

        IList<T> GetAll();
    }
}
