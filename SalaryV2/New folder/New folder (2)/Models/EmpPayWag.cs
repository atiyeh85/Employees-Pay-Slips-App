namespace SalaryV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ray.EmpPayWag")]
    public partial class EmpPayWag
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Year { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Mnt { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Period { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmpId { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Row { get; set; }

        public short? Flag { get; set; }

        public short? PayCodId { get; set; }

        [StringLength(100)]
        public string PayCodTit { get; set; }

        [Column(TypeName = "money")]
        public decimal? PayVal { get; set; }

        public short? DedCodId { get; set; }

        [StringLength(100)]
        public string DedCodTit { get; set; }

        [Column(TypeName = "money")]
        public decimal? DedVal { get; set; }

        public short? ExtCodId { get; set; }

        [StringLength(100)]
        public string ExtCodTit { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExtVal { get; set; }

        [StringLength(100)]
        public string ExtValDsc { get; set; }

        public byte? MazId { get; set; }

        [StringLength(45)]
        public string Maz { get; set; }

        [Column(TypeName = "money")]
        public decimal? HokmVal { get; set; }

        public byte? BankAcntTyp { get; set; }

        [StringLength(20)]
        public string Acnt { get; set; }

        public int? Bank { get; set; }

        [StringLength(20)]
        public string BankCardNo { get; set; }

        public byte? SentByEmail { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? Branch { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(100)]
        public string AllBranch { get; set; }

        public virtual Emp Emp { get; set; }
    }
}
