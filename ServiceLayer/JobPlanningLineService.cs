using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ServiceLayer.Base;

namespace ServiceLayer
{
    public class JobPlanningLineService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Job_Planning_Line>
    {
        public MCT_Teknoloji_A_Ş__Job_Planning_Line Delete(MCT_Teknoloji_A_Ş__Job_Planning_Line param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Job_Planning_Line> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Job_Planning_Line.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Job_Planning_Line> GetByCode(string param)
        {
            return GetAll().Where(p => p.Job_No_ == param).ToList();
        }

        public MCT_Teknoloji_A_Ş__Job_Planning_Line GetById(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Planning_Line Insert(MCT_Teknoloji_A_Ş__Job_Planning_Line param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Planning_Line Update(MCT_Teknoloji_A_Ş__Job_Planning_Line param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Job_Planning_Line> GetJobPlanningLines(string param1,DateTime date1,DateTime date2)
        {
            List<MCT_Teknoloji_A_Ş__Job_Planning_Line> resourceLines = GetResourceJobPlanningLines(param1);
            return resourceLines.Where(p => p.Planning_Date >= date1 && p.Planning_Date <= date2).ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Job_Planning_Line> GetResourceJobPlanningLines(string param)
        {
            return GetAll().Where(p => p.Type == 0 && p.No_ == param).ToList();
        }
    }
}
