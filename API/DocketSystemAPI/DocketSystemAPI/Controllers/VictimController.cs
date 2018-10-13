using DocketSystemAPI.Models;
using DocketSystemAPI.Orchestrations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        private void sendMessage(string message, string number,string subject)
        {
            _AdminOrchestration.SendSMS(new SMS
            {
                Body = message,
                Number = number,
                Subject = subject
            });
        }

        // GET: api/Victims
        [Route("GetAllMyCases")]
        [HttpGet]
        public IEnumerable<Case> GetAllMyCases(string victimId)
        {
            return db.Cases.Where(e => e.VictimID == victimId).ToList();
        }

        [Route("GetAllPedndingCases")]
        [HttpGet]
        public IEnumerable<Case> GetAllPedndingCases(string victimId)
        {
            return db.Cases.Where(e => e.VictimID == victimId && e.Status == Status.CASE_PENDING).ToList();
        }

        [Route("GetAllActiveCases")]
        [HttpGet]
        public IEnumerable<Case> GetAllActiveCases(string victimId)
        {
            return db.Cases.Where(e => e.VictimID == victimId && e.Status == Status.CASE_ACTIVE).ToList();
        }

        [Route("GetAllCompletedCases")]
        [HttpGet]
        public IEnumerable<Case> GetAllCompletedCases(string victimId)
        {
            return db.Cases.Where(e => e.VictimID == victimId && e.Status == Status.CASE_COMPLETED).ToList();
        }

        // GET: api/Victims
        [Route("/GetMyCase")]
        [HttpGet]
        public Case GetMyCase(string victimId, string caseNo)
        {
            return db.Cases.FirstOrDefault(e => e.VictimID == victimId && e.CaseNo == caseNo);
        }

        // POST: api/Detective
        [Route("/ReportCase")]
        [HttpPost]
        public void Post(string CaseNo,string  description)
        {

        }

    }
}