namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAY.vwTaxTableItem")]
    public partial class vwTaxTableItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxTableItemId { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal FromAmount { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal ToAmount { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Rate { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxTableRef { get; set; }

        public decimal? PartialAmount { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal InLineAmount { get; set; }
    }
}
