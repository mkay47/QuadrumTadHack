using DocketSystemAPI.Models;

namespace DocketSystemAPI.Orchestrations
{
    public interface IAdminOrchestration
    {
        string SendSMS(SMS sms);
    }
}