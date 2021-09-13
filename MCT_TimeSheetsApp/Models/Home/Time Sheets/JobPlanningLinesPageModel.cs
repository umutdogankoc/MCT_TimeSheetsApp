using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models.Home.Time_Sheets
{
    public class JobPlanningLinesPageModel
    {
        public string JobNo { get; set; }
        public string JobDescription { get; set; }
        public string JobTaskNo { get; set; }
        public string JobTaskDescription { get; set; }
        public DateTime PlanningDate { get; set; }
        public string Description { get; set; }
    }
}