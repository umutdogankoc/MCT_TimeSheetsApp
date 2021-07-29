using MCT_TimeSheetsApp.Models.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;
using DataAccessLayer;
using UtiltyLayer;
using UtiltyLayer.WSConnectionResponse;
using System.Threading;
using System.Globalization;

namespace MCT_TimeSheetsApp.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update
        public ActionResult UpdateResourceTimeSheet(UpdateResourceTimeSheetBaseModel[] model)
        {
            TimeSheetDetailService detailService = new TimeSheetDetailService();
            UpdateResourceTimeSheetResponseModel response = new UpdateResourceTimeSheetResponseModel();

            CreateWSConnection createWSConnection = new CreateWSConnection();
            WsConnectionResponseModel connModel = createWSConnection.CreateConnection("TimeSheetWS");

            foreach (UpdateResourceTimeSheetBaseModel baseModel in model)
            {
                Time_Sheet_Detail time_Sheet_Detail = detailService.Get(baseModel.HeaderNo, Convert.ToInt32(baseModel.LineNo), Convert.ToDateTime(baseModel.Date));

                if (time_Sheet_Detail == null)
                {
                    //create
                    if (connModel.State == true)
                    {
                        using (TimeSheetWS.TimeSheetAppWebService_PortClient timeSheetAppWebService = new TimeSheetWS.TimeSheetAppWebService_PortClient(connModel.binding, connModel.endpointAddress))
                        {
                            timeSheetAppWebService.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(connModel.Username, connModel.Password);
                            timeSheetAppWebService.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                            try
                            {

                                string wsAnswer = timeSheetAppWebService.InsertTimeSheetDetail(baseModel.HeaderNo, Convert.ToInt32(baseModel.LineNo), baseModel.Date, Convert.ToDecimal(baseModel.Value));
                                response.State = true;
                                response.SuccessMessage = wsAnswer;

                            }
                            catch (Exception ex)
                            {
                                response.State = false;
                                response.ErrorMessage = ex.Message;
                                response.ErrorCode = "Err_10000";

                            }
                        }
                    }
                    else
                    {
                        response.State = false;
                        response.ErrorMessage = connModel.ConnError;
                        response.ErrorCode = "Err_10001";
                    }

                }
                else
                {

                }
            }
            return Json(response);
        }
    }
}