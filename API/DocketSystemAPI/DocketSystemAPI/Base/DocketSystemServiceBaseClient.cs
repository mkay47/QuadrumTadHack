using RestSharp;
using System.Net;

namespace DocketSystemAPI.Common.Services
{
    public abstract class DocketSystemServiceBaseClient : RestClient
    {
        public DocketSystemServiceBaseClient()
        {
        }

        public DocketSystemServiceBaseClient(string baseUrl)
            : base(baseUrl)
        {
        }

        public DocketSystemServiceBaseClient(string baseUrl, string authString)
            : base(baseUrl)
        {
            //TODO: will need to be implemented
            //ServicePointManager.UseNagleAlgorithm = true;
            //this.AddDefaultHeader("Authorization", $"Basic {authString}");
        }
    }
}