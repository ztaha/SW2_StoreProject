using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SW2_StoreProject.Models;

namespace SW2_StoreProject.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("StoreConnection")
        { }

        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}