using DataAccessLayer;
using MCT_TimeSheetsApp.Models.Login;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MCT_TimeSheetsApp.Engine.LoginEngine;

namespace MCT_TimeSheetsApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginCheck(LoginPostModel model)
        {
            MCT_WLCService mCT_WLCService = new MCT_WLCService();
            LoginPostResponseModel response = new LoginPostResponseModel();

            try
            {
                MCTSPWebLoginCredentials loginUser = mCT_WLCService.CheckLogin(model.Username, model.Password);
                if (loginUser!=null)
                {
                    Resource sessionResource = new ResourceService().GetById(loginUser.ResourceNo);
                    if (sessionResource != null)
                    {
                        Session["ResourceSession"] = sessionResource;
                        response.State = true;
                        response.SuccessMessage = "Login Success.Please wait. You are being redirected to your portal..";

                        if (loginUser.ChangePassword==1)
                        {
                            response.RedirectUrl = "/Login/ResetPassword?Id="+loginUser.ResourceNo + "&EmailRedirected=false";
                        }
                        else
                        {
                            response.RedirectUrl = "/Home/Dashboard";
                        }
                        return Json(response);
                    }
                    else
                    {
                        response.State = false;
                        response.ErrorMessage = "SalesPerson is not found. Please contact system administrator";
                        response.ErrorCode = "Err_1000";
                        return Json(response);
                    }
                }
                else
                {
                    response.State = false;
                    response.ErrorMessage = "Invalid username or password. Please try again";
                    response.ErrorCode = "Err_1001";
                    return Json(response);
                }
            }
            catch (Exception ex)
            {

                response.State = false;
                response.ErrorMessage = ex.Message;
                return Json(response);
            }
         
        }
        public ActionResult ResetPassword(string Id,bool EmailRedirected)
        {
            MCTSPWebLoginCredentials ResetPassUser = new MCTSPWebLoginCredentials();

            if (!EmailRedirected)
            {
                 ResetPassUser = new MCT_WLCService().GetById(Id);
            }
            else
            {
                 ResetPassUser = new MCT_WLCService().GetBySystemId(Id);
            }

            if (ResetPassUser!=null)
            {
                ViewData["UserId"] = ResetPassUser.ResourceNo;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        public ActionResult SetNewPassword(NewPasswordModel model)
        {
            MCT_WLCService mCT_WLCService = new MCT_WLCService();
            NewPasswordResponseModel response = new NewPasswordResponseModel();
            try
            {
                MCTSPWebLoginCredentials NewPassUser = mCT_WLCService.GetById(model.UserCode);
                NewPassUser.Password = model.NewPassword;
                NewPassUser.ChangePassword = 0;
                mCT_WLCService.Update(NewPassUser);

                response.SuccessMessage = "Your password is updated. You are being redirected to your dashboard.";
                response.State = true;
                response.RedirectUrl = "/Home/Dashboard";
                return Json(response);
            }
            catch (Exception ex)
            {

                response.State = false;
                response.ErrorMessage = ex.Message;
                return Json(response);
            }
           
        }
        public ActionResult ForgotPass()
        {
            return View();
        }
        public ActionResult SendNewPasswordEmail(PasswordResetModel model)
        {
            NewPasswordResponseModel response = new NewPasswordResponseModel();
            MCT_WLCService loginService = new MCT_WLCService();
            MCTSPWebLoginCredentials passResetUser = loginService.GetByUsername(model.Username);
            EmailSenderEngine emailSenderEngine = new EmailSenderEngine();

            if (passResetUser!=null)
            {
                if (passResetUser.ChangePassword!=1)
                {
                    passResetUser.ChangePassword = 1;
                    loginService.Update(passResetUser);
                }

                Resource passResetResource = new ResourceService().GetById(passResetUser.ResourceNo);
                MCTTimeSheetAppSetup setup = new MCTTimeSheetAppSetupService().Get();
                if (emailSenderEngine.SendPasswordResetEmail(passResetResource, setup,passResetUser))
                {
                    response.RedirectUrl = "/Login/Login";
                    response.State = true;
                    response.SuccessMessage = "A link sent to your email to reset your password. Click here to return login page.";
                    return Json(response);

                }
                else
                {
                    response.State = false;
                    response.ErrorMessage = "We had a problem with sendig email. Please try again later.";
                    return Json(response);

                }
            }
            else
            {
                response.State = false;
                response.ErrorMessage = "Invalid username. Please try again";
                return Json(response);
            }
        }
    }
}