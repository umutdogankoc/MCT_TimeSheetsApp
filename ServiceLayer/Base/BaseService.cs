using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer.Base
{    public class BaseServiceLive
    {
        public BaseServiceLive()
        {
            if (db==null)
            {
                db = new mct2016Entities();
            }
        }

        private mct2016Entities db;

        public mct2016Entities Database
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