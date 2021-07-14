using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class ResourceService : BaseService, IRepository<Resource>
    {
        public Resource Delete(Resource param)
        {
            throw new NotImplementedException();
        }

        public List<Resource> GetAll()
        {
            return Database.Resource.ToList();
        }

        public List<Resource> GetByCode(string param)
        {
            throw new NotImplementedException();
        }

        public Resource GetById(string param)
        {
            return GetAll().Where(p => p.No_ == param).SingleOrDefault();
        }

        public Resource Insert(Resource param)
        {
            throw new NotImplementedException();
        }

        public Resource Update(Resource param)
        {
            throw new NotImplementedException();
        }
    }
}
