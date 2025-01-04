namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GNR.vwShredItem")]
    public partial class vwShredItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShredItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShredRef { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RowNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime UsanceDate { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Amount { get; set; }

        public decimal? InterestAmount { get; set; }

        public decimal? PenaltyAmount { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Status { get; set; }

        public int? PaymentRef { get; set; }

        public int? PaymentNumber { get; set; }

        public int? ReceiptRef { get; set; }

        public int? ReceiptNumber { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? PartySettlementRef { get; set; }

        public int? PartySettlementNumber { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool IsPaid { get; set; }

        public DateTime? PaidDate { get; set; }

        [StringLength(2000)]
        public string PaidDesc { get; set; }
    }
}
