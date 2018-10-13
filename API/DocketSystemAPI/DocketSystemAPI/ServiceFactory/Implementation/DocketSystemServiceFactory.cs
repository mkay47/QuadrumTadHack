using DocAPI.Admin_Models.Auth;
using DocketSystemAPI.Common.Services;

namespace DocketSystemAPI.ServiceFactory
{
    public class DocketSystemServiceFactory : IDockerSystemServiceFactory
    {
        private readonly string _BaseUrl;
        private readonly APIOptions _Options;

        public DocketSystemServiceFactory(APIOptions options)
        {
            _Options = options;
            _BaseUrl = options.Base_url;
        }

        public T GetClient<T>()
        {
            dynamic client = default(T);

            //TODO: will need to be implemented
            //var authBytes = Encoding.ASCII.GetBytes($"{options.username}:{options.password}".ToCharArray());
            //var authString = Convert.ToBase64String(authBytes);
            client = new VOIPServiceRestClient(_BaseUrl);

            return (T)client;
        }
    }
}