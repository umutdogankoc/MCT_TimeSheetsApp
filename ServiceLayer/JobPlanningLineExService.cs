using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class JobPlanningLineExService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext>
    {
        public MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext Delete(MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext.ToList();

        }

        public List<MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext GetById(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext Insert(MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext Update(MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Job_Planning_Line_Ext Get(string param1, string param2, int param3)
        {
            return GetAll().Where(p => p.Job_No_ == param1 && p.Job_Task_No_ == param2 && p.Line_No_ == param3).SingleOrDefault();
        }
    }
}
