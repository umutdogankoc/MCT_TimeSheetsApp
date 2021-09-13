using DataAccessLayer;
using MCT_TimeSheetsApp.Models.Home.Time_Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceLayer;
using MCT_TimeSheetsApp.Models.Home.Dashboard;

namespace MCT_TimeSheetsApp.Engine
{
    public class PageFillingEngine
    {
        public TimeSheetPageModel FillResourceTimeSheetPage(MCT_Teknoloji_A_Ş__Resource currentResource)
        {

            TimeSheetPageModel model = new TimeSheetPageModel()
            {
                ResourceTimeSheetHeaders = new TimeSheetHeaderService().GetDescendingList(currentResource.No_),
            }; 
            return model;
        }

        public TimeSheetPageModel FillTimeSheetLinePage(MCT_Teknoloji_A_Ş__Time_Sheet_Header timeSheetHeader)
        {
            List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> headerLines = new TimeSheetLineService().GetByCode(timeSheetHeader.No_);
            JobService jobService = new JobService();

            foreach (MCT_Teknoloji_A_Ş__Time_Sheet_Line line in headerLines)
            {
                if (jobService.GetById(line.Job_No_)!=null)
                {
                    line.JobDescription = jobService.GetById(line.Job_No_).Description;

                }
            }

            TimeSheetPageModel model = new TimeSheetPageModel()
            {
                ResourceTimeSheetLines = headerLines,
                CurrentTimeSheetHeader = timeSheetHeader,
            };

            List<MCT_Teknoloji_A_Ş__Time_Sheet_Detai> timeSheetLineDetails = new List<MCT_Teknoloji_A_Ş__Time_Sheet_Detai>();
            TimeSheetDetailService detailService = new TimeSheetDetailService();

            foreach (MCT_Teknoloji_A_Ş__Time_Sheet_Line lines in headerLines)
            {
                for (DateTime i = timeSheetHeader.Starting_Date; i < timeSheetHeader.Ending_Date.AddDays(1); i=i.AddDays(1))
                {
                    MCT_Teknoloji_A_Ş__Time_Sheet_Detai lineDetail = detailService.Get(lines.Time_Sheet_No_, lines.Line_No_, i);

                    if (lineDetail!=null)
                    {
                        timeSheetLineDetails.Add(lineDetail);
                    }
                    else
                    {
                        MCT_Teknoloji_A_Ş__Time_Sheet_Detai newDetail = new MCT_Teknoloji_A_Ş__Time_Sheet_Detai()
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

        public DashboardPageModel FillDashboardPage(MCT_Teknoloji_A_Ş__Resource currentResouce)
        {
            TimeSheetLineService timeSheetLineService = new TimeSheetLineService();

            DashboardPageModel model = new DashboardPageModel()
            {
                TimeSheetProjectQty = timeSheetLineService.GetAll().Count(),
                ApprovedTimeSheetQty = timeSheetLineService.GetApprovedTimeSheets(currentResouce).Count(),
                OpenTimeSheetQty = timeSheetLineService.GetOpenTimeSheetLines(currentResouce).Count(),
                SubmittedTimeSheetQty = timeSheetLineService.GetSubmittedTimeSheets(currentResouce).Count(),
                RejectedTimeSheetQty = timeSheetLineService.GetRejectedTimeSheets(currentResouce).Count(),
                PostedTimeSheetQty = timeSheetLineService.GetPostedTimeSheetLines(currentResouce).Count(),
            };
            return model;
        }

        public List<JobPlanningLinesPageModel> FillTimeSheetJobPlanningLines(MCT_Teknoloji_A_Ş__Resource resource,DateTime startDate,DateTime endDate)
        {
            JobPlanningLineService jobPlanningLineService = new JobPlanningLineService();
            JobService jobService = new JobService();
            JobTaskService jobTaskService = new JobTaskService();

            List<MCT_Teknoloji_A_Ş__Job_Planning_Line> lines = jobPlanningLineService.GetJobPlanningLines(resource.No_, startDate, endDate);
            List<JobPlanningLinesPageModel> jobPlanningList = new List<JobPlanningLinesPageModel>();

            foreach (MCT_Teknoloji_A_Ş__Job_Planning_Line line in lines)
            {

                JobPlanningLinesPageModel model = new JobPlanningLinesPageModel()
                {
                    JobNo = line.Job_No_,
                    JobTaskNo = line.Job_Task_No_,
                    JobDescription = jobService.GetById(line.Job_No_).Description,
                    Description = line.Description,
                    PlanningDate = line.Planning_Date,
                    JobTaskDescription = jobTaskService.Get(line.Job_No_, line.Job_Task_No_).Description,
                };

                jobPlanningList.Add(model);
            }
            return jobPlanningList;

        }

        public List<MCT_Teknoloji_A_Ş__Work_Type> FillWorkTypes()
        {
            WorkTypeService workTypeService = new WorkTypeService();
            return workTypeService.GetAll();
        }
    }
}