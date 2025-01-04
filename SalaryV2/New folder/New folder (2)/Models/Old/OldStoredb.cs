namespace SalaryV2.Models.Old
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OldStoredb : DbContext
    {
        public OldStoredb()
            : base("name=OldStoredb")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<RandomNumber> RandomNumbers { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<DWHEmpPayWagNew> DWHEmpPayWagNews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.a2)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.a3)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.b6)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.e1)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.a4)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.d9)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.d8)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.d7)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.d6)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.d3)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.a9)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.b2)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.b5)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.f1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.b7)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.f2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.b9)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.c1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.e2)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.c2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.c6)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.e3)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.e4)
                .IsUnicode(false);

            modelBuilder.Entity<DWHEmpPayWagNew>()
                .Property(e => e.e5)
                .IsUnicode(false);
        }
    }
}
