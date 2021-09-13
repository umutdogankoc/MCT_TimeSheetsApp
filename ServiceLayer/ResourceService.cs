using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class ResourceService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Resource>
    {
        public MCT_Teknoloji_A_Ş__Resource Delete(MCT_Teknoloji_A_Ş__Resource param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Resource> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Resource.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Resource> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Resource GetById(string param)
        {
            return GetAll().Where(p => p.No_ == param).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__Resource Insert(MCT_Teknoloji_A_Ş__Resource param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Resource Update(MCT_Teknoloji_A_Ş__Resource param)
        {
            throw new NotImplementedException();
        }
    }
}
