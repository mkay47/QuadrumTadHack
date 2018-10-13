using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocketSystemAPI.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("VictimId")]
        public string VictimId { get; set; }

        public string UpdateMessage { get; set; }
        public DateTime Date { get; set; }
        public string DetectiveId { get; set; }
    }
}