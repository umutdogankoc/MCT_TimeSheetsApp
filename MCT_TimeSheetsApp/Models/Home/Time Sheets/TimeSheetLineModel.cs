using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace MCT_TimeSheetsApp.Models.Home.Time_Sheets
{
    public class TimeSheetLineModel
    {
        public Time_Sheet_Line TimeSheetLine { get; set; }
        public List<Time_Sheet_Detail> TimeSheetLineDetails { get; set; }
    }
}