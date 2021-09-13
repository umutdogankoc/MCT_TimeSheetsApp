using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class TimeSheetDetailService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Time_Sheet_Detai>
    {
        public MCT_Teknoloji_A_Ş__Time_Sheet_Detai Delete(MCT_Teknoloji_A_Ş__Time_Sheet_Detai param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Detai> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Time_Sheet_Detail.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Detai> GetByCode(string param)
        {
            return GetAll().Where(p => p.Time_Sheet_No_ == param).ToList();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Detai GetById(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Detai Insert(MCT_Teknoloji_A_Ş__Time_Sheet_Detai param)
        {
            throw new NotImplementedException();

        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Detai Update(MCT_Teknoloji_A_Ş__Time_Sheet_Detai param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Detai> GetByLineNo(string param1, int param2)
        {
            return GetByCode(param1).Where(p => p.Time_Sheet_Line_No_ == param2).ToList();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Detai Get(string param1, int param2, DateTime param3)
        {
            return GetByLineNo(param1, param2).Where(p => p.Date == param3).SingleOrDefault();
        }
    }
}
