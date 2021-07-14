using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCT_TimeSheetsApp.Models.Login
{
    public class LoginPostResponseModel:BaseResponseModel  
    {
        public string RedirectUrl { get; set; }
    }
}