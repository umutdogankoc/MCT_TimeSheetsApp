using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class TimeSheetLineService : BaseService, IRepository<Time_Sheet_Line>
    {
        public Time_Sheet_Line Delete(Time_Sheet_Line param)
        {
            throw new NotImplementedException();
        }

        public List<Time_Sheet_Line> GetAll()
        {
           return Database.Time_Sheet_Line.ToList();
        }

        public List<Time_Sheet_Line> GetByCode(string param)
        {
            return GetAll().Where(p => p.Time_Sheet_No_ == param).ToList();
        }

        public Time_Sheet_Line GetById(string param)
        {
            throw new NotImplementedException();
        }

        public Time_Sheet_Line Insert(Time_Sheet_Line param)
        {
            throw new NotImplementedException();
        }

        public Time_Sheet_Line Update(Time_Sheet_Line param)
        {
            throw new NotImplementedException();
        }

        public Time_Sheet_Line GetBySystemId(Guid param)
        {
            return GetAll().Where(p => p.C_systemId == param).SingleOrDefault();
        }
    }
}
