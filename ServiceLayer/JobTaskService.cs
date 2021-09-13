using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class JobTaskService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Job_Task>
    {
        public MCT_Teknoloji_A_Ş__Job_Task Delete(MCT_Teknoloji_A_Ş__Job_Task param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Job_Task> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Job_Task.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Job_Task> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Task GetById(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Task Insert(MCT_Teknoloji_A_Ş__Job_Task param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Task Update(MCT_Teknoloji_A_Ş__Job_Task param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Task Get(string param1, string param2)
        {
            return GetAll().Where(p => p.Job_No_ == param1 && p.Job_Task_No_ == param2).SingleOrDefault();
        }
    }
}
