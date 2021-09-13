using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models.Update
{
    public class CreateTimeSheetLineModel
    {
        public string NewLineJobNo { get; set; }
        public string NewLineJobTaskNo { get; set; }
        public string NewLineDescription { get; set; }
        public string NewLineWorkType { get; set; }
        public string NewTimeSheetLineHeaderNo { get; set; }
    }
}