using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UtiltyLayer.WSConnectionResponse;

namespace UtiltyLayer
{
    public class CreateWSConnection
    {
        public WsConnectionResponseModel CreateConnection(string ConnName)
        {
            WsConnectionResponseModel model = new WsConnectionResponseModel();

            string strcon = ConfigurationManager.ConnectionStrings[ConnName].ConnectionString;
            if (strcon == "")
            {
                model.ConnError = "Web service connection is not successful";
                model.State = false;
                model.binding = null;
                model.endpointAddress = null;
                model.Username = null;
                model.Password = null;
            }
            else
            {
                BasicHttpBinding _binding = new BasicHttpBinding();
                _binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
                _binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                EndpointAddress endpointAddress = new EndpointAddress(new Uri(strcon));

                model.binding = _binding;
                model.endpointAddress = endpointAddress;
                model.State = true;
                model.ConnSuccess = "Web service connection successfull.";
                model.Username = ConfigurationManager.AppSettings["WSUsername"];
                model.Password = ConfigurationManager.AppSettings["WSPassword"];
            }
            return model;
        }

    }
}
