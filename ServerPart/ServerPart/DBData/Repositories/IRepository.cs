using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPart.DBData.Repositories
{
   
    public interface IRepository<T> where T:class
    {
        void Create(T model);
        T Get(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Update(T model);
        void Delete(int id);
        int IsExists(T model);
        int IsExists(int id);
    }
}
