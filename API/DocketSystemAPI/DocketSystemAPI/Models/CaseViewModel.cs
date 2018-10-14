using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocketSystemAPI.Models
{
    public class CaseViewModel
    {
        public string Description { get; set; }
        public string Media { get; set; }
        public string CaseType { get; set; }
        public string CapturerIdNo { get; set; }
        public int CaseStatus { get; set; }

        //For user
        public string VictimFullName { get; set; }
        public string VictimID { get; set; }
        public string VictimPassword { get; set; }
        public string VictimAddress { get; set; }
        public string VictimCellNo { get; set; }
        public string VictimGender { get; set; }
    }
}
