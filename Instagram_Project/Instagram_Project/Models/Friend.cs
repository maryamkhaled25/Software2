using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Instagram_Project.Models
{
    public class Friend
    {
        [Key]
        public int FriendsID { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual Account Accounts { get; set; }
    }
}
