using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocketSystemAPI.Models
{
    
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public int UserType { get; set; }

        public User(int id, string fullName, string iDNumber, int userType)
        {
            Id = id;
            FullName = fullName;
            IDNumber = iDNumber;
            UserType = userType;
        }

        public List<Case> Cases { get; set;}
    }
}
