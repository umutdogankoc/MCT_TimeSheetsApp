﻿using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class MCTTimeSheetAppSetupService : BaseService
    {

        public MCTTimeSheetAppSetup Get()
        {
            return Database.MCTTimeSheetAppSetup.FirstOrDefault();
        }

    }
}
