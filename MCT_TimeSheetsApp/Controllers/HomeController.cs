using DataAccessLayer;
using MCT_TimeSheetsApp.Engine;
using MCT_TimeSheetsApp.Models._Layout;
using MCT_TimeSheetsApp.Models.Home.Time_Sheets;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MCT_TimeSheetsApp.Controllers
{
    public class HomeController : Controller
    {
        private MCT_Teknoloji_A_Ş__Resource GetSessionResource()
        {
            return new ResourceService().GetById((Session["ResourceSession"] as MCT_Teknoloji_A_Ş__Resource).No_);
        }

        public HomeLayoutModel PopulateHomeLayout()
        {
            HomeLayoutModel homeLayout = new HomeLayoutModel()
            {
                SessionResource = GetSessionResource(),
            };
            return homeLayout;
        }

        // GET: Home
        public ActionResult Dashboard()
        {
            HomeLayoutModel homeLayout = PopulateHomeLayout();
            homeLayout.DashboradPageModel = new PageFillingEngine().FillDashboardPage(GetSessionResource());
            return View(homeLayout);
        }

        public ActionResult TimeSheets()
        {
            PageFillingEngine pageFillingEngine = new PageFillingEngine();
            HomeLayoutModel homeLayout = PopulateHomeLayout();
            homeLayout.ResourceTimeSheetPageModel = pageFillingEngine.FillResourceTimeSheetPage(GetSessionResource());
            return View(homeLayout);
        }

        public ActionResult TimeSheetLines(Guid TimeSheetId)
        {
            PageFillingEngine pageFillingEngine = new PageFillingEngine();
            HomeLayoutModel homeLayout = PopulateHomeLayout();
            MCT_Teknoloji_A_Ş__Time_Sheet_Header currentHeader = new TimeSheetHeaderService().GetBySystemId(TimeSheetId);
            homeLayout.ResourceTimeSheetPageModel = pageFillingEngine.FillTimeSheetLinePage(currentHeader);
            homeLayout.ResourceTimeSheetPageModel.JobPlanningLines = pageFillingEngine.FillTimeSheetJobPlanningLines(GetSessionResource(),Convert.ToDateTime(currentHeader.Starting_Date),Convert.ToDateTime(currentHeader.Ending_Date));
            homeLayout.ResourceTimeSheetPageModel.Work_Types = pageFillingEngine.FillWorkTypes();

            return View(homeLayout);
           
        }
            

        public ActionResult Logout()
        {
            if (Session["ResourceSession"]!=null)
            {
                Session["ResourceSession"] = null;
            }
            return RedirectToAction("Login", "Login");
        }

    }
}