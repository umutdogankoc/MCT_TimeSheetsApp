using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class MCT_WLCService : BaseService, IRepository<MCTSPWebLoginCredentials>
    {
        public MCTSPWebLoginCredentials Delete(MCTSPWebLoginCredentials param)
        {
            throw new NotImplementedException();
        }

        public List<MCTSPWebLoginCredentials> GetAll()
        {
            return Database.MCTSPWebLoginCredentials.ToList();
        }

        public List<MCTSPWebLoginCredentials> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public MCTSPWebLoginCredentials GetById(string param)
        {
            return GetAll().Where(p => p.ResourceNo == param).SingleOrDefault();
        }

        public MCTSPWebLoginCredentials Insert(MCTSPWebLoginCredentials param)
        {
            throw new NotImplementedException();
        }

        public MCTSPWebLoginCredentials Update(MCTSPWebLoginCredentials param)
        {
            MCTSPWebLoginCredentials updateUser = GetById(param.ResourceNo);
            updateUser = param;
            Database.SaveChanges();
            return param;
        }

        public MCTSPWebLoginCredentials CheckLogin(string userName, string Password)
        {
            return GetAll().Where(p => p.UserName == userName && p.Password == Password).SingleOrDefault();
        }

        public MCTSPWebLoginCredentials GetBySystemId(string param)
        {
            return GetAll().Where(p => p.C_systemId.ToString() == param).SingleOrDefault();
        }

        public MCTSPWebLoginCredentials GetByUsername(string param)
        {
            return GetAll().Where(p => p.UserName == param).SingleOrDefault();
        }
    }
}
