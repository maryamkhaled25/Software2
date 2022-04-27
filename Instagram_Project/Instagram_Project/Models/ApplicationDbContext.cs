using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Instagram_Project.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("DBCS")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Image>Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<React> Reacts { get; set; }
        public DbSet<Friend> Friends { get; set; }
    }
}