using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Instagram_Project.Models
{
    public class Reply
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

     
    }
}