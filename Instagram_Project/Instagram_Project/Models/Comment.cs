using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Instagram_Project.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public string Text { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual Account Accounts { get; set; }

        public ICollection<Reply> Replies { get; set; }

        public int ImageID { get; set; }
        [ForeignKey("ImageID")]
        public virtual Image Images { get; set; }

    }
}
