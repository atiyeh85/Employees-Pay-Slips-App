namespace SalaryV2.NewFolder1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<vwParty> vwParties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vwParty>()
                .Property(e => e.DLCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwParty>()
                .Property(e => e.CommissionRate)
                .HasPrecision(5, 2);

            modelBuilder.Entity<vwParty>()
                .Property(e => e.BrokerOpeningBalance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwParty>()
                .Property(e => e.DiscountRate)
                .HasPrecision(13, 10);

            modelBuilder.Entity<vwParty>()
                .Property(e => e.MaximumCredit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwParty>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<vwParty>()
                .Property(e => e.CustomerRemaining)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwParty>()
                .Property(e => e.PartyFax)
                .IsUnicode(false);
        }
    }
}
