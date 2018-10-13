using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocketSystemAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocketSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [Produces("application/json")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private static Random random = new Random();
        private DocketDBContext db;

        public AdminController(DocketDBContext context)
        {
            db = context;
        }
        // GET: api/Admin
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        // GET: api/Admin/5
        [HttpGet("{idNo}", Name = "Get")]
        public User Get(string idNo)
        {
            User user = db.Users.FirstOrDefault(e => idNo == e.IDNumber);

            if (db.Users.Any())
            {
                if(user.UserType == UserTypes.CAPTURE)
                {
                    user.Victims = db.Victims.Where(e => e.CaptureIdNo == user.IDNumber).ToList();
                    user.Cases = db.Cases.Where(e => e.CapturerId == user.IDNumber).ToList();
                }
                else
                {
                    user.Cases = db.Cases.Where(e => e.CapturerId == user.IDNumber).ToList();
                }

                return user;
            }
            else
            {
                return null;
            }
        }

        //// POST: api/Admin
        //[HttpPost]
        //public void Post([FromBody] User value)
        //{
        //    string password = Secrecy.HashPassword(value.Password);
        //    db.Users.Add(new Models.User(0,value.FullName,value.IDNumber,value.UserType,password));

        //    db.SaveChanges();
        //}

        [HttpPost]
        [Route("AddCapturer")]
        public void Post([FromBody] UserViewModel value)
        {
            string password = Secrecy.HashPassword(value.Password);
            db.Users.Add(new Models.User(0, value.FullName, value.IDNumber, value.UserType, password));

            db.SaveChanges();
        }

        [HttpPost]
        [Route("ReportCase")]
        public void Post([FromBody] CaseViewModel value)
        {
            //db.Users.Add(new Models.User(0, value.FullName, value.IDNumber, value.UserType, password));

            Random random = new Random();
            string randomPassword = random.Next(500, 5000).ToString();//Generate a random password

            value.VictimPassword = Secrecy.HashPassword(randomPassword);
            string caseNo = RandomString(9);
            //Send Case No and Password to the Victim

            //Add a case
            //Get Capturer 
            User capturer = db.Users.FirstOrDefault(e => e.IDNumber == value.CapturerIdNo);

            if (capturer != null)
            {
                // db.Users.FirstOrDefault(e => e.IDNumber == value.CapturerIdNo).Cases.Add(new Case(0, caseNo, DateTime.Now, value.Description, value.Media, value.VictimID, "", value.CaseType, value.VictimFullName, value.CapturerIdNo, Status.CASE_PENDING));

                capturer.AddNewCase(new Case(0, caseNo, DateTime.Now, value.Description, value.Media, value.VictimID, "", value.CaseType, value.VictimFullName, value.CapturerIdNo, Status.CASE_PENDING));

                capturer.addNewVictims(new victim(0, value.VictimFullName, value.VictimID, value.VictimPassword, value.VictimAddress, value.VictimGender, value.VictimCellNo, value.CapturerIdNo));

                //db.Users.FirstOrDefault(e => e.IDNumber == value.CapturerIdNo).Victims.Add(new victim(0,value.VictimFullName, value.VictimID, value.VictimPassword,value.VictimAddress, value.VictimGender, value.VictimCellNo));

                db.SaveChanges();
            }
            //Add User 
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // PUT: api/Admin/5
        //[HttpPut("{idNo}")]
        //public void Put(int idNo, [FromBody] string value)
        //{

        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
