using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DataAccess.Interface
{
    public interface IDatabase<T>
    {
        T Insert(T obj);
        T Update(T obj);
        bool Delete(int codigo);
        T Get(int codigo);
        List<T> List();
    }
}
