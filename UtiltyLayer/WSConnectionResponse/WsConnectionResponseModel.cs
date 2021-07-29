using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace UtiltyLayer.WSConnectionResponse
{
   public class WsConnectionResponseModel
    {
        public BasicHttpBinding binding { get; set; }
        public EndpointAddress endpointAddress { get; set; }
        public string ConnError { get; set; }
        public string ConnSuccess { get; set; }
        public bool State { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
