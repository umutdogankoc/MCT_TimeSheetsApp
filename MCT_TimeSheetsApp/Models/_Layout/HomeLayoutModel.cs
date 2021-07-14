using DataAccessLayer;
using MCT_TimeSheetsApp.Models.Home.Time_Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models._Layout
{
    public class HomeLayoutModel
    {
        public Resource SessionResource { get; set; }
        public TimeSheetPageModel ResourceTimeSheetPageModel { get; set; }
    }
}