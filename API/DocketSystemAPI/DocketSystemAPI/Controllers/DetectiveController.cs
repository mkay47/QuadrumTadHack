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
    public class DetectiveController : ControllerBase
    {
        private DocketDBContext db;

        public DetectiveController(DocketDBContext context)
        {
            db = context;
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
