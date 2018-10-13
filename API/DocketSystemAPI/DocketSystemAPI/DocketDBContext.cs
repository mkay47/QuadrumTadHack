using DocketSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocketSystemAPI
{
    public class DocketDBContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Victim> Victims { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DocketDBContext(DbContextOptions<DocketDBContext> options) : base(options)
        {
        }
    }
}