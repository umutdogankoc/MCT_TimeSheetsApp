using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class SalesPersonService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Salesperson_Purchaser>
    {
        public MCT_Teknoloji_A_Ş__Salesperson_Purchaser Delete(MCT_Teknoloji_A_Ş__Salesperson_Purchaser param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Salesperson_Purchaser> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Salesperson_Purchaser.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Salesperson_Purchaser> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Salesperson_Purchaser GetById(string param)
        {
            return GetAll().Where(p => p.Code == param).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__Salesperson_Purchaser Insert(MCT_Teknoloji_A_Ş__Salesperson_Purchaser param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Salesperson_Purchaser Update(MCT_Teknoloji_A_Ş__Salesperson_Purchaser param)
        {
            throw new NotImplementedException();
        }
    }
}
