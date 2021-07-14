using DataAccessLayer;
using MCT_TimeSheetsApp.Engine;
using MCT_TimeSheetsApp.Models._Layout;
using ServiceLayer;
using System;
using System.Web.Mvc;

namespace MCT_TimeSheetsApp.Controllers
{
    public class HomeController : Controller
    {
        private Resource GetSessionResource()
        {
            return new ResourceService().GetById((Session["ResourceSession"] as Resource).No_);
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
            Time_Sheet_Header currentHeader = new TimeSheetHeaderService().GetBySystemId(TimeSheetId);
            homeLayout.ResourceTimeSheetPageModel = pageFillingEngine.FillTimeSheetLinePage(currentHeader);
            return View(homeLayout);
        }
    }
}