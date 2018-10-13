using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocketSystemAPI.Models
{
    
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public int UserType { get; set; }

        public List<Case> Cases { get; set;}
    }
}
