using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Instagram_Project.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required, MinLength(3), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        public string FName { get; set; }

        [Required, MinLength(3), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        public string LName { get; set; }

        [Required, MinLength(10), MaxLength(11), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        public string Mobile { get; set; }

        [EmailAddress, Index(IsUnique = true), Column(TypeName = "VARCHAR"), Required]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string ProfileImage { get; set; }
    }
}