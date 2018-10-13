using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocketSystemAPI.Models;
using DocketSystemAPI.Orchestrations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocketSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private static Random random = new Random();
        private DocketDBContext db;
        private readonly IAdminOrchestration _AdminOrchestration;

        public AdminController(DocketDBContext context, IAdminOrchestration adminOrchestration)
        {
            db = context;
            _AdminOrchestration = adminOrchestration;
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
                if (user.UserType == UserTypes.CAPTURE)
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
        [Route("AddCase")]
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

                capturer.AddNewCase(new Case(0, caseNo, DateTime.Now, value.Description, value.Media, value.VictimID,RandomAssignACase(), value.CaseType, value.VictimFullName, value.CapturerIdNo, Status.CASE_PENDING));

                capturer.addNewVictims(new Victim(0, value.VictimFullName, value.VictimID, value.VictimPassword, value.VictimAddress, value.VictimGender, value.VictimCellNo, value.CapturerIdNo));

                string content = string.Format("Hi {0} Your Case Number is {1} And use your ID number to check ur case on our system" ,value.VictimFullName , caseNo);

                string decryp = "0027" + value.VictimCellNo.Substring(1, value.VictimCellNo.Length-1);
                sendMessage(content, decryp, "New Case Created");
                db.SaveChanges();
            }
        }

        private string RandomAssignACase()
        {
            string name = "";

            List<User> users = db.Users.Where(e => e.UserType == UserTypes.DETECTIVE).ToList();
            

            if(users.Count > 0)
            {
                int r = random.Next(users.Count);
                name = users[r].IDNumber;
                //Algorithm for random assignment of CASE
            }
           
            return name;
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


        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // PUT: api/Admin/5
        [HttpPut("{idNo}")]
        public void Put(int idNo, [FromBody] string value)
        {

        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}