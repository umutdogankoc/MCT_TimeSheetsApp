using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class MCTTimeSheetAppSetupService : BaseServiceLive
    {

        public MCT_Teknoloji_A_Ş__MCTTimeSheetAppSetup Get()
        {
            return Database.MCT_Teknoloji_A_Ş__MCTTimeSheetAppSetup.FirstOrDefault();
        }

    }
}
