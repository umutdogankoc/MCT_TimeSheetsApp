using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class JobService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Job>
    {
        public MCT_Teknoloji_A_Ş__Job Delete(MCT_Teknoloji_A_Ş__Job param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Job> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Job.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Job> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job GetById(string param)
        {
            return GetAll().Where(p => p.No_ == param).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__Job Insert(MCT_Teknoloji_A_Ş__Job param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job Update(MCT_Teknoloji_A_Ş__Job param)
        {
            throw new NotImplementedException();
        }
    }
}
