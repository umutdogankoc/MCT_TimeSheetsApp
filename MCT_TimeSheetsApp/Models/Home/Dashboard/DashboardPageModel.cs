using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models.Home.Dashboard
{
    public class DashboardPageModel
    {
        public int TimeSheetProjectQty { get; set; }
        public int OpenTimeSheetQty { get; set; }
        public int SubmittedTimeSheetQty { get; set; }
        public int ApprovedTimeSheetQty { get; set; }
        public int PostedTimeSheetQty { get; set; }
        public int RejectedTimeSheetQty { get; set; }
    }
}