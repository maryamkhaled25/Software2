using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projecttt.Models
{
    public class Reply
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        public int CommentID { get; set; }

        [ForeignKey("CommentID")]
        public virtual Comment Comment { get; set; }

    }
}