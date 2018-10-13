using DocketSystemAPI.Models;

namespace DocketSystemAPI.Services
{
    public interface ISMSService
    {
        string SendSMS(SMS sms);
    }
}