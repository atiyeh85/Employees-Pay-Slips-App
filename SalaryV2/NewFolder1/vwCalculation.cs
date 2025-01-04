namespace SalaryV2.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAY.vwCalculation")]
    public partial class vwCalculation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CalculationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ElementRef { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string ElementTitle { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string ElementTitle_En { get; set; }

        public int? PersonnelRef { get; set; }

        [StringLength(250)]
        public string DLTitle { get; set; }

        [StringLength(250)]
        public string DLTitle_En { get; set; }

        [StringLength(40)]
        public string DLCode { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal Value { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ElementType { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ElementClass { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Type { get; set; }

        public int? BranchRef { get; set; }

        public int? BranchDLRef { get; set; }

        public int? BranchCostCenterDLRef { get; set; }

        [StringLength(250)]
        public string BranchCostCenterDLTitle { get; set; }

        [StringLength(40)]
        public string BranchCostCenterDLCode { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Month { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; set; }

        public int? ContractRef { get; set; }

        public int? VoucherRef { get; set; }

        public int? VoucherNumber { get; set; }

        public DateTime? VoucherDate { get; set; }

        public int? DlRef { get; set; }

        public int? ElementAccountRef { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ElementDlType { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ElementNormalType { get; set; }

        public int? ElementPaymentAccountRef { get; set; }

        public int? ElementPaymentDlType { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ElementDisplayOrder { get; set; }

        [StringLength(250)]
        public string AccountNo { get; set; }

        [StringLength(250)]
        public string BankTitle { get; set; }

        [StringLength(250)]
        public string BankTitle_En { get; set; }

        [StringLength(250)]
        public string BranchTitle { get; set; }

        [StringLength(250)]
        public string BranchTitle_En { get; set; }

        [StringLength(250)]
        public string AccountTypeTitle { get; set; }

        [StringLength(250)]
        public string AccountTypeTitle_En { get; set; }
    }
}
