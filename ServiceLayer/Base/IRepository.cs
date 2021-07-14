using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Base
{
   public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> GetByCode(string param);
        T GetById(string param);
        T Insert(T param);
        T Update(T param);
        T Delete(T param);
    }
}
