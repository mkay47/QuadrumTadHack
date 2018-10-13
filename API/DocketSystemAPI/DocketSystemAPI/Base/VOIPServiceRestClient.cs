namespace DocketSystemAPI.Common.Services
{
    public class VOIPServiceRestClient : DocketSystemServiceBaseClient, IVOIPServiceRestClient
    {
        public VOIPServiceRestClient()
        { }

        public VOIPServiceRestClient(string baseUrl)
               : base(baseUrl)
        {
        }

        public VOIPServiceRestClient(string baseUrl, string authString)
            : base(baseUrl, authString)
        { }
    }
}