using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPart.Services
{
    public interface IService<T> where T : class
    {
        void Add(T viewModel);
        T Get(int id);
        IEnumerable<T> Get();
        void Update(T viewModel);
        void Delete(int id);
        int IsExists(T model);
        int IsExists(int id);
    }
}
