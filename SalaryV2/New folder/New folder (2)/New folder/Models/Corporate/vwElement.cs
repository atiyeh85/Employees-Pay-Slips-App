namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAY.vwElement")]
    public partial class vwElement
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ElementId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Title_En { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Class { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Type { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NormalType { get; set; }

        public int? AccountRef { get; set; }

        [StringLength(120)]
        public string AccountCode { get; set; }

        [StringLength(250)]
        public string AccountTitle { get; set; }

        [StringLength(250)]
        public string AccountTitle_En { get; set; }

        public bool? HasDl { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DlType { get; set; }

        public int? PaymentAccountRef { get; set; }

        [StringLength(120)]
        public string PaymentAccountCode { get; set; }

        [StringLength(250)]
        public string PaymentAccountTitle { get; set; }

        [StringLength(250)]
        public string PaymentAccountTitle_En { get; set; }

        public bool? PaymentHasDl { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentDlType { get; set; }

        public bool? InsuranceCoverage { get; set; }

        public bool? Taxable { get; set; }

        public bool? UnrelatedToWorkingTime { get; set; }

        public bool? CalculateForMinWorkingTime { get; set; }

        public int? CalculateForMinBase { get; set; }

        public decimal? Coefficient { get; set; }

        public decimal? FixPoint { get; set; }

        public int? DenominatorsType { get; set; }

        public decimal? Denominators { get; set; }

        public bool? SavingRemainder { get; set; }

        public bool? IsActive { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Creator { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastModifier { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime LastModificationDate { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DisplayOrder { get; set; }
    }
}
