using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class WorkTypeService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Work_Type>
    {
        public MCT_Teknoloji_A_Ş__Work_Type Delete(MCT_Teknoloji_A_Ş__Work_Type param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Work_Type> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Work_Type.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Work_Type> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Work_Type GetById(string param)
        {
            return GetAll().Where(p => p.Code == param).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__Work_Type Insert(MCT_Teknoloji_A_Ş__Work_Type param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Work_Type Update(MCT_Teknoloji_A_Ş__Work_Type param)
        {
            throw new NotImplementedException();
        }
    }
}
