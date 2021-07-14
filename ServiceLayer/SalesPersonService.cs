using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class SalesPersonService : BaseService, IRepository<Salesperson_Purchaser>
    {
        public Salesperson_Purchaser Delete(Salesperson_Purchaser param)
        {
            throw new NotImplementedException();
        }

        public List<Salesperson_Purchaser> GetAll()
        {
            return Database.Salesperson_Purchaser.ToList();
        }

        public List<Salesperson_Purchaser> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public Salesperson_Purchaser GetById(string param)
        {
            return GetAll().Where(p => p.Code == param).SingleOrDefault();
        }

        public Salesperson_Purchaser Insert(Salesperson_Purchaser param)
        {
            throw new NotImplementedException();
        }

        public Salesperson_Purchaser Update(Salesperson_Purchaser param)
        {
            throw new NotImplementedException();
        }
    }
}
