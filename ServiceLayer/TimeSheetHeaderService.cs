using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class TimeSheetHeaderService : BaseService, IRepository<Time_Sheet_Header>
    {
        public Time_Sheet_Header Delete(Time_Sheet_Header param)
        {
            throw new NotImplementedException();
        }

        public List<Time_Sheet_Header> GetAll()
        {
            return Database.Time_Sheet_Header.ToList();
        }

        public List<Time_Sheet_Header> GetByCode(string param)
        {
            return GetAll().Where(p => p.Resource_No_ == param).ToList();
        }

        public Time_Sheet_Header GetById(string param)
        {
            return GetAll().Where(p => p.No_ == param).SingleOrDefault();
        }

        public Time_Sheet_Header Insert(Time_Sheet_Header param)
        {
            throw new NotImplementedException();
        }

        public Time_Sheet_Header Update(Time_Sheet_Header param)
        {
            throw new NotImplementedException();
        }

        public IOrderedEnumerable<Time_Sheet_Header> GetDescendingList(string param)
        {
            return GetByCode(param).OrderByDescending(P => P.No_);
        }

        public Time_Sheet_Header GetBySystemId(Guid param)
        {
            return GetAll().Where(p => p.C_systemId == param).SingleOrDefault();
        }
    }
}
