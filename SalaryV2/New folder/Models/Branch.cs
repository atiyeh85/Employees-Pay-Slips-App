namespace SalaryV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ray.Branch")]
    public partial class Branch
    {
        [Key]
        [Column("Branch")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Branch1 { get; set; }

        [StringLength(40)]
        public string BranchDsc { get; set; }

        [StringLength(40)]
        public string BranchLDsc { get; set; }

        public byte? IsCenter { get; set; }

        [StringLength(100)]
        public string DBName { get; set; }

        [StringLength(8)]
        public string PayCrnDat { get; set; }

        public int? DBBranch { get; set; }

        public byte? AstAccSerial { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AstFrOwner { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AstToOwner { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AstFrCenter { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AstToCenter { get; set; }

        public int? AstFrSettlement { get; set; }

        public int? AstToSettlement { get; set; }

        public int? AstFrCenter2 { get; set; }

        public int? AstToCenter2 { get; set; }

        public int? AstFrCenter3 { get; set; }

        public int? AstToCenter3 { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Guid RowGuid { get; set; }
    }
}
