using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer.Base
{
    public class BaseService
    {
        public BaseService()
        {
            if (db==null)
            {
                db = new MCT_Entities();
            }
        }

        private MCT_Entities db;

        public MCT_Entities Database
        {
            get 
            {
                return db;
            }

            set 
            {
                db = value;
            }
        }
    }
}
