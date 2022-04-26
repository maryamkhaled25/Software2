using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projecttt.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual Account Account { get; set; }

        [Column(TypeName ="VARCHAR")]
        public string ImageName { get; set; }
    }
}