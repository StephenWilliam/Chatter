using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatter.Models
{
    public class Follow
    {
        [Key]
        public int FollowID { get; set; }
        //foreign key
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser ChatName { get; set; }


    }
}