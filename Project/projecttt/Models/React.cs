using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projecttt.Models
{
    public class React
    {
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual Account Account { get; set; }

       public int ImageID { get; set; }
       [ForeignKey("ImageID")]
       public virtual Image Image { get; set; }


        public long NumberOfLikes { get; set; }

        public long NumberOfDisLikes { get; set; }

    }
}