using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chatter.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string MessageContent { get; set; }

        //[ForeignKey("UserId")]
        //public string ApplicationUser { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}