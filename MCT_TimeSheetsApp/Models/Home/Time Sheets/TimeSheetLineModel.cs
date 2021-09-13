using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace MCT_TimeSheetsApp.Models.Home.Time_Sheets
{
    public class TimeSheetLineModel
    {
        public MCT_Teknoloji_A_Ş__Time_Sheet_Line TimeSheetLine { get; set; }
        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Detai> TimeSheetLineDetails { get; set; }
    }
}