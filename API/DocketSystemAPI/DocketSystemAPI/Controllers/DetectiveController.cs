using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocketSystemAPI.Models;
using DocketSystemAPI.Orchestrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocketSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectiveController : ControllerBase
    {
        private DocketDBContext db;
        private readonly IAdminOrchestration _AdminOrchestration;

        public DetectiveController(DocketDBContext context, IAdminOrchestration adminOrchestration)
        {
            db = context;
            _AdminOrchestration = adminOrchestration;

        }
        //GET: api/Detective
        [Route("/GetAll")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.Where(e => e.UserType == UserTypes.DETECTIVE).ToList();
        }

        //GET: api/Detective/55252
        [Route("GetDetective")]
        [HttpGet]
        public User Get(string idNo)
        {
            User user = db.Users.Where(e => e.UserType == UserTypes.DETECTIVE && idNo == e.IDNumber).FirstOrDefault();
            if (user != null)
            {
                user.Cases = db.Cases.Where(e => e.DetectiveID == idNo).ToList();
            }

            return user;
        }

        [Route("GetCase")]
        [HttpGet]
        public Case GetCase(string idNo, string caseNo)
        {
            User user = db.Users.Where(e => e.UserType == UserTypes.DETECTIVE && idNo == e.IDNumber).FirstOrDefault();
            if (user != null)
            {
                return db.Cases.FirstOrDefault(e => e.DetectiveID == idNo && e.CaseNo == caseNo);
            }

            return null;
        }

        [Route("GetAllCases")]
        [HttpGet]
        public IEnumerable<Case> GetAllCases(string idNo)
        {
            User user = db.Users.Where(e => e.UserType == UserTypes.DETECTIVE && idNo == e.IDNumber).FirstOrDefault();
            if (user != null)
            {
                return db.Cases.Where(e => e.DetectiveID == idNo).ToList();
            }

            return null;
        }

        [Route("GetPendingCases")]
        [HttpGet]
        public IEnumerable<Case> GetPendingCases(string idNo)
        {
            User user = db.Users.Where(e => e.UserType == UserTypes.DETECTIVE && idNo == e.IDNumber).FirstOrDefault();
            if (user != null)
            {
                return db.Cases.Where(e => e.DetectiveID == idNo && e.Status == Status.CASE_PENDING).ToList();
            }

            return null;
        }

        [Route("GetCompletedCases")]
        [HttpGet]
        public IEnumerable<Case> GetCompletedCases(string idNo)
        {
            User user = db.Users.Where(e => e.UserType == UserTypes.DETECTIVE && idNo == e.IDNumber).FirstOrDefault();
            if (user != null)
            {
                return db.Cases.Where(e => e.DetectiveID == idNo && e.Status == Status.CASE_COMPLETED).ToList();
            }

            return null;
        }

        [Route("GetActiveCases")]
        [HttpGet]
        public IEnumerable<Case> GetActiveCases(string idNo)
        {
            User user = db.Users.Where(e => e.UserType == UserTypes.DETECTIVE && idNo == e.IDNumber).FirstOrDefault();
            if (user != null)
            {
                return db.Cases.Where(e => e.DetectiveID == idNo && e.Status == Status.CASE_ACTIVE).ToList();
            }

            return null;
        }

        //// POST: api/Detective
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/Detective/5
        //Update Case 
        [Route("UpdateCaseStatus")]
        [HttpPut]
        public void Put(int status, string caseNo)
        {
            Case updateCase = db.Cases.FirstOrDefault(e => e.CaseNo == caseNo);   

            if(updateCase != null)
            {
                updateCase.Status = status;
                db.SaveChanges();

                string userID = db.Cases.FirstOrDefault(e => e.CaseNo == caseNo).VictimID;

                //Get user with the Case
                victim victim = db.Victims.FirstOrDefault(e => e.IDNumber == userID);

                //send Message
                string decryp = "0027" + victim.CellNO.Substring(1, victim.CellNO.Length - 1);
                sendMessage("Your Case has been detected", decryp, "Update");
            }
        }

        private void sendMessage(string message, string number, string subject)
        {
            _AdminOrchestration.SendSMS(new SMS
            {
                Body = message,
                Number = number,
                Subject = subject
            });
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
