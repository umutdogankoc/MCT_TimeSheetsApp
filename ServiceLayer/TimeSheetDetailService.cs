using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class TimeSheetDetailService : BaseService, IRepository<Time_Sheet_Detail>
    {
        public Time_Sheet_Detail Delete(Time_Sheet_Detail param)
        {
            throw new NotImplementedException();
        }

        public List<Time_Sheet_Detail> GetAll()
        {
            return Database.Time_Sheet_Detail.ToList();
        }

        public List<Time_Sheet_Detail> GetByCode(string param)
        {
            return GetAll().Where(p => p.Time_Sheet_No_ == param).ToList();
        }

        public Time_Sheet_Detail GetById(string param)
        {
            throw new NotImplementedException();
        }

        public Time_Sheet_Detail Insert(Time_Sheet_Detail param)
        {
            throw new NotImplementedException();

        }

        public Time_Sheet_Detail Update(Time_Sheet_Detail param)
        {
            throw new NotImplementedException();
        }

        public List<Time_Sheet_Detail> GetByLineNo(string param1, int param2)
        {
            return GetByCode(param1).Where(p => p.Time_Sheet_Line_No_ == param2).ToList();
        }

        public Time_Sheet_Detail Get(string param1, int param2, DateTime param3)
        {
            return GetByLineNo(param1, param2).Where(p => p.Date == param3).SingleOrDefault();
        }
    }
}
