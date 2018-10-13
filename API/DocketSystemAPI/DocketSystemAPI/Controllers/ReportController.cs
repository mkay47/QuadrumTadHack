using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocketSystemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocketSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private DocketDBContext db;

        // GET: api/Reports
        public ReportController(DocketDBContext context)
        {
            db = context;
        }

        //All Case reported in the system
        [Route("GetAllReports")]
        [HttpGet]
        public IEnumerable<Report> GetAllReports()
        {
            return db.Reports.ToList();
        }

        //All Victim Reports
        [Route("GetVictimAllReports")]
        [HttpGet]
        public IEnumerable<Report> GetVictimAllReports(string victimID)
        {
            return db.Reports.Where(e => e.VictimIDNo == victimID);
        }

        // POST: api/Report
        [Route("PostReport")]
        [HttpPost]
        public void PostReport([FromBody] Report value)
        {
            //Get the victim
            db.Victims.FirstOrDefault(e => e.IDNumber == value.VictimIDNo).AddNewReport(value);
            db.SaveChanges();
        }
    }
}
