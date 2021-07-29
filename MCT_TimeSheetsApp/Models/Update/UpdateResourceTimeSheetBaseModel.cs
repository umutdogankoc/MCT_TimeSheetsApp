using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models.Update
{
    public class UpdateResourceTimeSheetBaseModel
    {
        public string HeaderNo { get; set; }
        public string LineNo { get; set; }
        public string Date { get; set; }
        public string Value { get; set; }
    }
}