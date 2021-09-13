using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class TimeSheetHeaderService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Time_Sheet_Header>
    {
        public MCT_Teknoloji_A_Ş__Time_Sheet_Header Delete(MCT_Teknoloji_A_Ş__Time_Sheet_Header param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Header> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Time_Sheet_Header.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Header> GetByCode(string param)
        {
            return GetAll().Where(p => p.Resource_No_ == param).ToList();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Header GetById(string param)
        {
            return GetAll().Where(p => p.No_ == param).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Header Insert(MCT_Teknoloji_A_Ş__Time_Sheet_Header param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Header Update(MCT_Teknoloji_A_Ş__Time_Sheet_Header param)
        {
            throw new NotImplementedException();
        }

        public IOrderedEnumerable<MCT_Teknoloji_A_Ş__Time_Sheet_Header> GetDescendingList(string param)
        {
            return GetByCode(param).OrderByDescending(P => P.No_);
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Header GetBySystemId(Guid param)
        {
            return GetAll().Where(p => p.C_systemId == param).SingleOrDefault();
        }
    }
}
