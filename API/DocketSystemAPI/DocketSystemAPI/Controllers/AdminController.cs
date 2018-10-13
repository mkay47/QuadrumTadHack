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
            return db.Users.Where(e => e.UserType == UserTypes.CAPTURE);
        }

        // GET: api/Admin/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(string id)
        {
            return db.Users.FirstOrDefault(e => e.UserType == UserTypes.CAPTURE && id == e.IDNumber);
        }

        // POST: api/Admin
        [HttpPost]
        public void Post([FromBody] User value)
        {
            db.Users.AddAsync(new Models.User(0, value.FullName, value.IDNumber, value.UserType));
            db.Database.CommitTransaction();
        }

        // PUT: api/Admin/5
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