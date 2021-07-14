using DataAccessLayer;
using MCT_TimeSheetsApp.Models.Home.Time_Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceLayer;

namespace MCT_TimeSheetsApp.Engine
{
    public class PageFillingEngine
    {
        public TimeSheetPageModel FillResourceTimeSheetPage(Resource currentResource)
        {

            TimeSheetPageModel model = new TimeSheetPageModel()
            {
                ResourceTimeSheetHeaders = new TimeSheetHeaderService().GetDescendingList(currentResource.No_),
            }; 
            return model;
        }

        public TimeSheetPageModel FillTimeSheetLinePage(Time_Sheet_Header timeSheetHeader)
        {
            List<Time_Sheet_Line> headerLines = new TimeSheetLineService().GetByCode(timeSheetHeader.No_);
            TimeSheetPageModel model = new TimeSheetPageModel()
            {
                ResourceTimeSheetLines = headerLines,
                CurrentTimeSheetHeader = timeSheetHeader,
            };

            List<Time_Sheet_Detail> timeSheetLineDetails = new List<Time_Sheet_Detail>();
            TimeSheetDetailService detailService = new TimeSheetDetailService();

            foreach (Time_Sheet_Line lines in headerLines)
            {
                List<Time_Sheet_Detail> timeSheetDetail = detailService.GetByLineNo(timeSheetHeader.No_, lines.Line_No_);
                timeSheetLineDetails.AddRange(timeSheetDetail);
            }
            model.ResourceTimeSheetLineDetails = timeSheetLineDetails;
            return model;
        }
    }
}