using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lunchhunters
{
    public interface IRepository<T>
    {
        IQueryable<T> GetQuery();
        T Create();
        void Save(T row);
        void Delete(T row);
    }
}
