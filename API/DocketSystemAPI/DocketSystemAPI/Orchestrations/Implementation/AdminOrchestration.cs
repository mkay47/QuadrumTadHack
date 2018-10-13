using DocketSystemAPI.Models;
using DocketSystemAPI.Services;

namespace DocketSystemAPI.Orchestrations
{
    public class AdminOrchestration : IAdminOrchestration
    {
        private readonly ISMSService _AdminService;

        public AdminOrchestration(ISMSService adminService)
        {
            _AdminService = adminService;
        }

        public string SendSMS(SMS sms)
        {
            var ok = _AdminService.SendSMS(sms); ;

            return ok;
        }
    }
}