using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models.Home.Time_Sheets
{
    public class TimeSheetPageModel
    {
        public IOrderedEnumerable<MCT_Teknoloji_A_Ş__Time_Sheet_Header> ResourceTimeSheetHeaders { get; set; }
        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> ResourceTimeSheetLines { get; set; }
        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Detai> ResourceTimeSheetLineDetails { get; set; }
        public MCT_Teknoloji_A_Ş__Time_Sheet_Header CurrentTimeSheetHeader { get; set; }
        public List<JobPlanningLinesPageModel> JobPlanningLines { get; set; }
        public List<MCT_Teknoloji_A_Ş__Work_Type> Work_Types { get; set; }
    }
}