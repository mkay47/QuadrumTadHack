using DocketSystemAPI.Models;
using DocketSystemAPI.Orchestrations;
using Microsoft.AspNetCore.Mvc;

namespace DocketSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VictimController : Controller
    {
        private DocketDBContext db;
        private readonly IAdminOrchestration _AdminOrchestration;

        public VictimController(DocketDBContext context, IAdminOrchestration adminOrchestration)
        {
            db = context;
            _AdminOrchestration = adminOrchestration;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var sms = new SMS
            {
                Body = "Hello from controller",
                Number = "0027727509918",
                Subject = "Docket System"
            };
            return Ok(_AdminOrchestration.SendSMS(sms));
        }
    }
}