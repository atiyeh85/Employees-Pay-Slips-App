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

        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<vwParty> vwParties { get; set; }
        public virtual DbSet<vwShred> vwShreds { get; set; }
        public virtual DbSet<vwShredItem> vwShredItems { get; set; }
        public virtual DbSet<vwShredRemaining> vwShredRemainings { get; set; }
        public virtual DbSet<vwCalculation> vwCalculations { get; set; }
        public virtual DbSet<vwContract> vwContracts { get; set; }
        public virtual DbSet<vwElement> vwElements { get; set; }
        public virtual DbSet<vwElementItem> vwElementItems { get; set; }
        public virtual DbSet<vwPersonnel> vwPersonnels { get; set; }

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

            modelBuilder.Entity<vwShred>()
                .Property(e => e.DLCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwShred>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwShred>()
                .Property(e => e.InterestAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwShred>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwShred>()
                .Property(e => e.RemainedAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwShred>()
                .Property(e => e.PenaltyRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwShred>()
                .Property(e => e.PenaltyAmount)
                .HasPrecision(38, 4);

            modelBuilder.Entity<vwShred>()
                .Property(e => e.InterestAccountCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwShred>()
                .Property(e => e.PenaltyAccountCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwShredItem>()
                .Property(e => e.Amount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<vwShredItem>()
                .Property(e => e.InterestAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwShredItem>()
                .Property(e => e.PenaltyAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwShredRemaining>()
                .Property(e => e.InterestPenaltyTotalAmount)
                .HasPrecision(38, 4);

            modelBuilder.Entity<vwShredRemaining>()
                .Property(e => e.InterestPenaltyRemainingAmount)
                .HasPrecision(38, 4);

            modelBuilder.Entity<vwShredRemaining>()
                .Property(e => e.InterestPenaltyTotalReceivedAmount)
                .HasPrecision(38, 4);

            modelBuilder.Entity<vwShredRemaining>()
                .Property(e => e.ShredTotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwShredRemaining>()
                .Property(e => e.ShredTotalReceivedAmount)
                .HasPrecision(38, 4);

            modelBuilder.Entity<vwShredRemaining>()
                .Property(e => e.ShredRemainingAmount)
                .HasPrecision(38, 4);

            modelBuilder.Entity<vwCalculation>()
                .Property(e => e.DLCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwCalculation>()
                .Property(e => e.Value)
                .HasPrecision(24, 4);

            modelBuilder.Entity<vwCalculation>()
                .Property(e => e.BranchCostCenterDLCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwContract>()
                .Property(e => e.NonTaxableAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwContract>()
                .Property(e => e.InsuranceBranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwContract>()
                .Property(e => e.SupportingInsuranceBranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwContract>()
                .Property(e => e.TaxBranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwContract>()
                .Property(e => e.CostCenterCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwContract>()
                .Property(e => e.PersonnelCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwContract>()
                .Property(e => e.BonusSum)
                .HasPrecision(38, 4);

            modelBuilder.Entity<vwContract>()
                .Property(e => e.LeakageSum)
                .HasPrecision(38, 4);

            modelBuilder.Entity<vwElement>()
                .Property(e => e.AccountCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwElement>()
                .Property(e => e.PaymentAccountCode)
                .IsUnicode(false);

            modelBuilder.Entity<vwElement>()
                .Property(e => e.Coefficient)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwElement>()
                .Property(e => e.FixPoint)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwElement>()
                .Property(e => e.Denominators)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwElementItem>()
                .Property(e => e.Coefficient)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwPersonnel>()
                .Property(e => e.InsuranceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<vwPersonnel>()
                .Property(e => e.SupportInsuranceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<vwPersonnel>()
                .Property(e => e.DLCode)
                .IsUnicode(false);
        }
    }
}
