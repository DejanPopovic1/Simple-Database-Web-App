using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace MyApplication.Models
{
    //public class DB_Entities : DbContext
    //{
    //    public DB_Entities() : base("Authentication") { }
    //    public DbSet<MainPageModel> MainModels { get; set; }
    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        Database.SetInitializer<DB_Entities>(null);//This is initially commented out but I changed the DB since
    //        //modelBuilder.Entity<User>().ToTable("Users");
    //        modelBuilder.Entity<MainPageModel>().ToTable("Users");
    //        modelBuilder.Entity<MainPageModel>().ToTable("Info");
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //        base.OnModelCreating(modelBuilder);
    //    }
    //}

    public class DB_Entities : DbContext
    {
        public DB_Entities() : base("Authentication") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Info> Infos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DB_Entities>(null);//This is initially commented out but I changed the DB since
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Info>().ToTable("Info");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}