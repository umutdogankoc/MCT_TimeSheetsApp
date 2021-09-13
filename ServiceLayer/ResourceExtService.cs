using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class ResourceExtService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Resource_Ext>
    {
        public MCT_Teknoloji_A_Ş__Resource_Ext Delete(MCT_Teknoloji_A_Ş__Resource_Ext param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Resource_Ext> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__Resource_Ext.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Resource_Ext> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Resource_Ext GetById(string param)
        {
            return GetAll().Where(p => p.No_ == param).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__Resource_Ext Insert(MCT_Teknoloji_A_Ş__Resource_Ext param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Resource_Ext Update(MCT_Teknoloji_A_Ş__Resource_Ext param)
        {
            throw new NotImplementedException();
        }
    }
}
