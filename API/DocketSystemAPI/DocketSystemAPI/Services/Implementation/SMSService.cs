using DocketSystemAPI.Common.Services;
using DocketSystemAPI.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DocketSystemAPI.Services
{
    public class SMSService : ISMSService
    {
        private readonly IVOIPServiceRestClient _RestClient;

        public SMSService(IVOIPServiceRestClient voipServiceRestClient)
        {
            _RestClient = voipServiceRestClient;
        }

        public string SendSMS(SMS sms)
        {
            var msg = JsonConvert.SerializeObject(sms);

            var request = new RestRequest("")
            {
                RequestFormat = DataFormat.Json
            };

            request.AddQueryParameter("number", sms.Number);
            request.AddQueryParameter("subject", sms.Subject);
            request.AddQueryParameter("body", sms.Body);

            var response = _RestClient.Post(request);

            return response.Content;
        }
    }
}