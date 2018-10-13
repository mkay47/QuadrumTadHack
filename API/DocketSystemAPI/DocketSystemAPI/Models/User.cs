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
        public string Password { get; set; }

        public List<Case> Cases { get; set; }
        public List<Victim> Victims { get; set; }

        public User(int id, string fullName, string iDNumber, int userType, string password)
        {
            Id = id;
            FullName = fullName;
            IDNumber = iDNumber;
            UserType = userType;
            Password = password;
        }

        public void AddNewCase(Case newCase)
        {
            if (Cases == null)
            {
                Cases = new List<Case>
                {
                    newCase
                };
            }
            else
            {
                Cases.Add(newCase);
            }
        }

        public void addNewVictims(Victim victim)
        {
            if (Victims == null)
            {
                Victims = new List<Victim>();
                Victims.Add(victim);
            }
            else
            {
                Victims.Add(victim);
            }
        }
    }
}