using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocketSystemAPI.SOAPConnection
{
    public class MTNSOAPConnection
    {
        private readonly IConfiguration _config;

        public MTNSOAPConnection(IConfiguration config)
        {
            _config = config;
        }

        public MTNSOAPConnection Connect()
        {
            var mtnsoapConnection = new MTNSOAPConnection();
            iOSPLUSSoapClient.Endpoint.Address = new EndpointAddress(_config.GetSection("WSDLEndpoint").Value);
            BasicHttpsBinding binding = new BasicHttpsBinding { MaxReceivedMessageSize = int.MaxValue };
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            iOSPLUSSoapClient.Endpoint.Binding = binding;
            return iOSPLUSSoapClient;
        }
    }
}