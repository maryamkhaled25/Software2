using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projecttt.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DBCS")
        {
        }
             public DbSet<Account> Accounts { get; set; }
             public DbSet<Comment> comments { get; set; }
             public DbSet<Reply> Replies { get; set; }
             public DbSet<Image> Images { get; set; }


    }
}