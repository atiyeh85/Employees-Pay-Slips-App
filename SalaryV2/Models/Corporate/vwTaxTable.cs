namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAY.vwTaxTable")]
    public partial class vwTaxTable
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxTableId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string Title_En { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxGroupRef { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Creator { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastModifier { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime LastModificationDate { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(250)]
        public string TaxGroupTitle { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(250)]
        public string TaxGroupTitle_En { get; set; }
    }
}
