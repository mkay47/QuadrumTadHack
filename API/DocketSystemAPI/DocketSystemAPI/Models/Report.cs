using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocketSystemAPI.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string CaseNo { get; set; }
        public string VictimIDNo { get; set; } 
    }
}
