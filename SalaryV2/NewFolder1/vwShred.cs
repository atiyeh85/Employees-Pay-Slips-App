namespace SalaryV2.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GNR.vwShred")]
    public partial class vwShred
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShredID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Key { get; set; }

        public string Target { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TargetRef { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DLRef { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(40)]
        public string DLCode { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(250)]
        public string DLTitle { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(250)]
        public string DLTitle_En { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal Amount { get; set; }

        public decimal? InterestAmount { get; set; }

        [Key]
        [Column(Order = 10)]
        public decimal TotalAmount { get; set; }

        [Key]
        [Column(Order = 11)]
        public decimal RemainedAmount { get; set; }

        public decimal? PenaltyRate { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CurrencyRef { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrecisionCount { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Creator { get; set; }

        [Key]
        [Column(Order = 15)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastModifier { get; set; }

        [Key]
        [Column(Order = 17)]
        public DateTime LastModificationDate { get; set; }

        [Key]
        [Column(Order = 18)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(40)]
        public string CurrencyTitle { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(40)]
        public string CurrencyTitle_En { get; set; }

        [Key]
        [Column(Order = 21)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CurrencyPrecisionCount { get; set; }

        [Key]
        [Column(Order = 22)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RPType { get; set; }

        public int? ShredItemCount { get; set; }

        public int? NotPaidShredItemCount { get; set; }

        public decimal? PenaltyAmount { get; set; }

        public int? InterestAccountSLRef { get; set; }

        [StringLength(120)]
        public string InterestAccountCode { get; set; }

        [StringLength(250)]
        public string InterestAccountTitle { get; set; }

        public int? PenaltyAccountSLRef { get; set; }

        [StringLength(120)]
        public string PenaltyAccountCode { get; set; }

        [StringLength(250)]
        public string PenaltyAccountTitle { get; set; }
    }
}
