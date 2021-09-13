using DataAccessLayer;
using MCT_TimeSheetsApp.Models;
using MCT_TimeSheetsApp.Models.Update;
using ServiceLayer;
using System;
using System.Web.Mvc;
using UtiltyLayer;
using UtiltyLayer.WSConnectionResponse;

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

            if (connModel.State == false)
            {
                response.State = false;
                response.ErrorMessage = connModel.ConnError;
                response.ErrorCode = "Err_10001";
                return Json(response);
            }

            foreach (UpdateResourceTimeSheetBaseModel baseModel in model)
            {
                try
                {
                    MCT_Teknoloji_A_Ş__Time_Sheet_Detai time_Sheet_Detail = detailService.Get(baseModel.HeaderNo, Convert.ToInt32(baseModel.LineNo), Convert.ToDateTime(baseModel.Date));

                    if (time_Sheet_Detail == null)
                    {
                        //create

                        using (TimeSheetWS.UDKTimeSheetWS_PortClient timeSheetAppWebService = new TimeSheetWS.UDKTimeSheetWS_PortClient(connModel.binding, connModel.endpointAddress))
                        {
                            timeSheetAppWebService.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(connModel.Username, connModel.Password);
                            timeSheetAppWebService.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                            string wsAnswer = timeSheetAppWebService.InsertTimeSheetDetail(baseModel.HeaderNo, Convert.ToInt32(baseModel.LineNo), baseModel.Date, Convert.ToDecimal(baseModel.Value));
                            response.State = true;
                            response.SuccessMessage = wsAnswer;
                            response.UpdatedLineCount++;
                        }
                    }
                    else
                    {
                        //edit

                        if (time_Sheet_Detail.Quantity != Convert.ToDecimal(baseModel.Value))
                        {
                            using (TimeSheetWS.UDKTimeSheetWS_PortClient timeSheetAppWebService = new TimeSheetWS.UDKTimeSheetWS_PortClient(connModel.binding, connModel.endpointAddress))
                            {
                                timeSheetAppWebService.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(connModel.Username, connModel.Password);
                                timeSheetAppWebService.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                                string wsAnswer = timeSheetAppWebService.UpdateTimeSheetDetail(baseModel.HeaderNo, Convert.ToInt32(baseModel.LineNo), baseModel.Date, Convert.ToDecimal(baseModel.Value));
                                response.State = true;
                                response.SuccessMessage = wsAnswer;
                                response.UpdatedLineCount++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.State = false;
                    response.ErrorMessage = ex.Message;
                    response.ErrorCode = "Err_10000";
                    return Json(response);
                }
            }
            return Json(response);
        }

        public ActionResult CreateNewTimeSheet(CreateTimeSheetModel model)
        {

            CreateWSConnection createWSConnection = new CreateWSConnection();
            WsConnectionResponseModel connModel = createWSConnection.CreateConnection("TimeSheetWS");
            BaseResponseModel response = new BaseResponseModel();

            if (connModel.State == false)
            {
                response.State = false;
                response.ErrorMessage = connModel.ConnError;
                response.ErrorCode = "Err_10001";
                return Json(response);
            }
            
            string sessionResourceNo =  new ResourceService().GetById((Session["ResourceSession"] as MCT_Teknoloji_A_Ş__Resource).No_).No_;
            try
            {
                if (model.StartingDate!=null)
                {
                    using (TimeSheetWS.UDKTimeSheetWS_PortClient timeSheetAppWebService = new TimeSheetWS.UDKTimeSheetWS_PortClient(connModel.binding,connModel.endpointAddress))
                    {
                        timeSheetAppWebService.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(connModel.Username, connModel.Password);
                        timeSheetAppWebService.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                        string wsAnswer = timeSheetAppWebService.CreateTimeSheet(model.StartingDate, sessionResourceNo);
                        response.State = true;
                        response.SuccessMessage = wsAnswer;
                        return Json(response);
                    }
                }
                else
                {
                    response.State = false;
                    response.ErrorMessage = "Start Date cannot be empty.";
                    response.ErrorCode = "Err_20000";
                    return Json(response);


                }
            }
            catch (Exception ex)
            {

                response.State = false;
                response.ErrorMessage = ex.Message;
                response.ErrorCode = "Err_20001";
                return Json(response);

            }
        }

        [HttpPost]
        public ActionResult CreateNewTimeSheetLine(CreateTimeSheetLineModel model)
        {
            CreateWSConnection createWSConnection = new CreateWSConnection();
            WsConnectionResponseModel connModel = createWSConnection.CreateConnection("TimeSheetWS");
            CreateTimeSheetLineResponseModel response = new CreateTimeSheetLineResponseModel();

            if (connModel.State == false)
            {
                response.State = false;
                response.ErrorMessage = connModel.ConnError;
                response.ErrorCode = "Err_10001";
                return Json(response);
            }

            try
            {
                if (model.NewLineJobNo!=null && model.NewLineJobTaskNo !=null)
                {
                    using (TimeSheetWS.UDKTimeSheetWS_PortClient timeSheetAppWebService = new TimeSheetWS.UDKTimeSheetWS_PortClient(connModel.binding, connModel.endpointAddress))
                    {
                        timeSheetAppWebService.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(connModel.Username, connModel.Password);
                        timeSheetAppWebService.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                        string wsAnswer = timeSheetAppWebService.CreateTimeSheetLine(model.NewLineJobNo, model.NewLineJobTaskNo, model.NewLineDescription, model.NewLineWorkType,model.NewTimeSheetLineHeaderNo);
                        TimeSheetHeaderService service = new TimeSheetHeaderService();
                        MCT_Teknoloji_A_Ş__Time_Sheet_Header header = service.GetById(model.NewTimeSheetLineHeaderNo);
                        response.TimeSheetId = header.C_systemId.ToString();
                        response.State = true;
                        response.SuccessMessage = wsAnswer;
                        return Json(response);
                    }
                }
                else
                {
                    response.State = false;
                    response.ErrorMessage = "Job No / Job Task No cannot be empty.";
                    response.ErrorCode = "Err_30000";
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                response.State = false;
                response.ErrorMessage = ex.Message;
                response.ErrorCode = "Err_30001";
                return Json(response);
            }
        }
    }
}