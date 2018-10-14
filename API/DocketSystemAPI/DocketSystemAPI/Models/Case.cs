using Newtonsoft.Json;
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
        public DateTime date { get; set; }
        public string Description { get; set; }
        public string Media { get; set; }
        public string VictimID { get; set; }
        public string DetectiveID { get; set; }
        public string CaseType { get; set; }
        public string VictimFullName { get; set; }
        public string CapturerId { get; set; }
        public int Status { get; set; }

        public Case(int id, string caseNo, DateTime date, string description, string media, string victimID, string detectiveID, string caseType, string victimFullName, string capturerId, int Status)
        {
            Id = id;
            CaseNo = caseNo;
            this.date = date;
            Description = description;
            Media = media;
            VictimID = victimID;
            DetectiveID = detectiveID;
            CaseType = caseType;
            VictimFullName = victimFullName;
            CapturerId = capturerId;
            this.Status = Status;
        }
    }
}
