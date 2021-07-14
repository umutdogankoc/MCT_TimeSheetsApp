using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using UtiltyLayer;

namespace MCT_TimeSheetsApp.Engine
{
    public class LoginEngine
    {
        public class EmailSenderEngine : Controller
        {
            public bool SendPasswordResetEmail(Resource resource,MCTTimeSheetAppSetup setup,MCTSPWebLoginCredentials user)
            {
                string resetUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Login/ResetPassword?Id=" + user.C_systemId+ "&EmailRedirected=true";
                try
                {
                    SendEmail sendEmail = new SendEmail();
                    string subject = "Business Central Customer Portal Password Reset";
                    string emailbody = System.IO.File.ReadAllText(Path.Combine(HttpRuntime.AppDomainAppPath, "EmailTemplates/ForgotPassTemplate.html"));
                    emailbody = emailbody.Replace("Forgot_Pass_NameSurname", resource.Name);
                    emailbody = emailbody.Replace("Validation_Link", resetUrl);
                    emailbody = emailbody.Replace("Company_Email", setup.MCTTimeSheetAppAdminEmail);
                    string cc = null;
                    sendEmail.Send(resource.Education, subject, emailbody, cc, null);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }

        }

    }
}