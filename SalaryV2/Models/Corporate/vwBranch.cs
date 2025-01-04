namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAY.vwBranch")]
    public partial class vwBranch
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BranchId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BranchPartyRef { get; set; }

        [StringLength(40)]
        public string Code { get; set; }

        [StringLength(40)]
        public string ContractNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdjustmentType { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Creator { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastModifier { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime LastModificationDate { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(40)]
        public string BranchCode { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(250)]
        public string BranchTitle { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(250)]
        public string BranchTitle_En { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BranchDLRef { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NoInsurancePersonsCount { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Type { get; set; }

        public int? CostCenterDLRef { get; set; }

        [StringLength(250)]
        public string CostCenterDLTitle { get; set; }

        [StringLength(40)]
        public string CostCenterDLCode { get; set; }
    }
}
