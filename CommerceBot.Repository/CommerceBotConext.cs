using CommerceBot.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceBot.Repository
{
    public class CommerceBotConext : DbContext
    {
        public CommerceBotConext()
          : base("name=CommerceBotConext")
        {
        }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Cabana> Cabanas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
