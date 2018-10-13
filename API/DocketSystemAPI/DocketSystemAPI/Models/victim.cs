using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocketSystemAPI.Models
{
    public class Victim
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string CellNO { get; set; }
        public string CaptureIdNo { get; set; }

        public Victim(int id, string fullName, string iDNumber, string password, string address, string gender, string cellNO, string CaptureIdNo)
        {
            Id = id;
            FullName = fullName;
            IDNumber = iDNumber;
            Password = password;
            Address = address;
            Gender = gender;
            CellNO = cellNO;
            this.CaptureIdNo = CaptureIdNo;
        }
    }
}