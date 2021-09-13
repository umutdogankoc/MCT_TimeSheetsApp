using DataAccessLayer;
using MCT_TimeSheetsApp.Models.Home.Dashboard;
using MCT_TimeSheetsApp.Models.Home.Time_Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models._Layout
{
    public class HomeLayoutModel
    {
        public MCT_Teknoloji_A_Ş__Resource SessionResource { get; set; }
        public TimeSheetPageModel ResourceTimeSheetPageModel { get; set; }
        public DashboardPageModel DashboradPageModel { get; set; }
    }
}