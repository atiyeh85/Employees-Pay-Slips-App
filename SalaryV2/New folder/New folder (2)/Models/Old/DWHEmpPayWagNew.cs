namespace SalaryV2.Models.Old
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ray.DWHEmpPayWagNew")]
    public partial class DWHEmpPayWagNew
    {
        public Guid ID { get; set; }

        public int? F1SequenceNumber { get; set; }

        public long? a1 { get; set; }

        [StringLength(25)]
        public string a2 { get; set; }

        [StringLength(25)]
        public string a3 { get; set; }

        [StringLength(25)]
        public string b6 { get; set; }

        [StringLength(15)]
        public string e1 { get; set; }

        [StringLength(15)]
        public string a4 { get; set; }

        public int? a5 { get; set; }

        [StringLength(150)]
        public string d9 { get; set; }

        public int? a6 { get; set; }

        [StringLength(100)]
        public string d8 { get; set; }

        public short? a7 { get; set; }

        [StringLength(100)]
        public string d7 { get; set; }

        public byte? c9 { get; set; }

        [StringLength(45)]
        public string d6 { get; set; }

        public int? d1 { get; set; }

        public int? d2 { get; set; }

        [StringLength(40)]
        public string d3 { get; set; }

        public byte? a8 { get; set; }

        [Column(TypeName = "money")]
        public decimal? a9 { get; set; }

        public byte? b1 { get; set; }

        [StringLength(20)]
        public string b2 { get; set; }

        public int? b3 { get; set; }

        public short? b4 { get; set; }

        [StringLength(100)]
        public string b5 { get; set; }

        [Column(TypeName = "money")]
        public decimal? f1 { get; set; }

        public short? b8 { get; set; }

        [StringLength(100)]
        public string b7 { get; set; }

        [Column(TypeName = "money")]
        public decimal? f2 { get; set; }

        public short? c7 { get; set; }

        [StringLength(100)]
        public string b9 { get; set; }

        [Column(TypeName = "money")]
        public decimal? c1 { get; set; }

        public int? c3 { get; set; }

        public short? c4 { get; set; }

        public byte? c5 { get; set; }

        [StringLength(30)]
        public string e2 { get; set; }

        [Column(TypeName = "money")]
        public decimal? c2 { get; set; }

        public short? c8 { get; set; }

        [StringLength(1)]
        public string c6 { get; set; }

        public byte? d4 { get; set; }

        public int? d5 { get; set; }

        [StringLength(50)]
        public string e3 { get; set; }

        [StringLength(20)]
        public string e4 { get; set; }

        [StringLength(60)]
        public string e5 { get; set; }

        public byte? e6 { get; set; }
    }
}
