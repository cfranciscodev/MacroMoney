using MacroMoney.Business.Entities;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace MacroMoney.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MacroMoneyContext : DbContext
    {
        public MacroMoneyContext()
            : base("name=MacroMoneyContext")
        {
            Database.SetInitializer<MacroMoneyContext>(null);
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Account>()
                .Property(e => e.StartingBalance)
                .HasPrecision(19, 4);
        }
    }
}
