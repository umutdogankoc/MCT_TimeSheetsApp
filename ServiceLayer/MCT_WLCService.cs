using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class MCT_WLCService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials>
    {
        public MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials Delete(MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials> GetAll()
        {
            return Database.MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials GetById(string param)
        {
            return GetAll().Where(p => p.ResourceNo == param).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials Insert(MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials Update(MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials param)
        {
            MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials updateUser = GetById(param.ResourceNo);
            updateUser = param;
            Database.SaveChanges();
            return param;
        }

        public MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials CheckLogin(string userName, string Password)
        {
            return GetAll().Where(p => p.UserName == userName && p.Password == Password).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials GetBySystemId(string param)
        {
            return GetAll().Where(p => p.C_systemId.ToString() == param).SingleOrDefault();
        }

        public MCT_Teknoloji_A_Ş__MCTSPWebLoginCredentials GetByUsername(string param)
        {
            return GetAll().Where(p => p.UserName == param).SingleOrDefault();
        }
    }
}
