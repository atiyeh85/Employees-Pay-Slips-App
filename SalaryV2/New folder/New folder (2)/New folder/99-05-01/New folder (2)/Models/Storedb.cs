namespace Salaryv2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Storedb : DbContext
    {
        public Storedb()
            : base("name=Storedb")
        {
        }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<EmpDeprt> EmpDeprts { get; set; }
        public virtual DbSet<RandomNumber> RandomNumbers { get; set; }
        public virtual DbSet<EmpPayWagAndEmpInfoByDateV> EmpPayWagAndEmpInfoByDateVs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Month>()
                .Property(e => e.MonthTitle)
                .IsFixedLength();

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.PayCodTit)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.PayVal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.DedCodTit)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.DedVal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.ExtCodTit)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.ExtVal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.ExtValDsc)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Maz)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.HokmVal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Fmly)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Fthr)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.ShenId)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.ShenSerial)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.ShenDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.BrthDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.WorkId)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.InsId)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.PhisicDesc)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Acnt)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Acnt2)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Adrs)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.EmpBgnDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.EmpDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.CrnGrad)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.OvrPrs)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.OvrVctPrc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.SaveNo)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.YerVactRmnd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.YerSavRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.NationCode)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.MilitaryDue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.CrnEmployRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.RecruitmentNo)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.EvalTotVal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.BankCardNo)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.BankCardNo2)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.RcvDat)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.LastPensionerAssistanceDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.LastPensionerDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.MrgDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.PostCod)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.PortionPrc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.TelMobil)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Sheba1)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.Sheba2)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.RetirmntDocNo)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.RetirmntBrchCod)
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.OutDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.EmpOutDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.HKMENDDAT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpPayWagAndEmpInfoByDateV>()
                .Property(e => e.EBLGDESC)
                .IsUnicode(false);
            modelBuilder.Entity<Branch>()
                .Property(e => e.BranchDsc)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.BranchLDsc)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.DBName)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.PayCrnDat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.AstFrOwner)
                .HasPrecision(25, 0);

            modelBuilder.Entity<Branch>()
                .Property(e => e.AstToOwner)
                .HasPrecision(25, 0);

            modelBuilder.Entity<Branch>()
                .Property(e => e.AstFrCenter)
                .HasPrecision(25, 0);

            modelBuilder.Entity<Branch>()
                .Property(e => e.AstToCenter)
                .HasPrecision(25, 0);

            modelBuilder.Entity<Branch>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.Depart)
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.Mngr)
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.DeprtDesc)
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.DeprtRangeFree)
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.DeprtRelation)
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.CancelDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.CancelDsc)
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.branch_filter_spec)
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.PhotoX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EmpDeprt>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<EmpDeprt>()
                .HasMany(e => e.EmpDeprt1)
                .WithOptional(e => e.EmpDeprt2)
                .HasForeignKey(e => e.MainDeprtId);
        }
    }
}
