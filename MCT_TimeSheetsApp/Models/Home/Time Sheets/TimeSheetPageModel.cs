using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models.Home.Time_Sheets
{
    public class TimeSheetPageModel
    {
        public IOrderedEnumerable<Time_Sheet_Header> ResourceTimeSheetHeaders { get; set; }
        public List<Time_Sheet_Line> ResourceTimeSheetLines { get; set; }
        public List<Time_Sheet_Detail> ResourceTimeSheetLineDetails { get; set; }
        public Time_Sheet_Header CurrentTimeSheetHeader { get; set; }
    }
}