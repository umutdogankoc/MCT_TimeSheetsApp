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
                for (DateTime i = timeSheetHeader.Starting_Date; i < timeSheetHeader.Ending_Date.AddDays(1); i=i.AddDays(1))
                {
                    Time_Sheet_Detail lineDetail = detailService.Get(lines.Time_Sheet_No_, lines.Line_No_, i);

                    if (lineDetail!=null)
                    {
                        timeSheetLineDetails.Add(lineDetail);
                    }
                    else
                    {
                        Time_Sheet_Detail newDetail = new Time_Sheet_Detail()
                        {
                            Time_Sheet_No_ = lines.Time_Sheet_No_,
                            Time_Sheet_Line_No_ = lines.Line_No_,
                            Date = i,
                            Quantity = 0,
                            Posted_Quantity = 0,
                            Status = 0,  
                        };
                        timeSheetLineDetails.Add(newDetail);
                    }
                }
            }
            model.ResourceTimeSheetLineDetails = timeSheetLineDetails;
            return model;
        }

    }
}