using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocketSystemAPI.Models
{
    public class Case
    {
        [Key]
        public int Id { get; set; }
        public string CaseNo { get; set; }
        public DateTime Ddate { get; set; }
        public string Descripotion { get; set; }
        public string Media { get; set; }
        public string VictimID { get; set; }
        public string DetectiveID { get; set; }
        public string CaseType { get; set; }
        public string VictimFullName { get; set; }
        public string CapturerId { get; set; }
    }
}
