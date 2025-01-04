namespace SalaryV2.Models.Old
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        public int LogId { get; set; }

        [StringLength(50)]
        public string ComputerName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [StringLength(50)]
        public string b2 { get; set; }

        [StringLength(50)]
        public string e1 { get; set; }

        public short? c4 { get; set; }

        public byte? c5 { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }

        public bool? IsPrint { get; set; }

        [StringLength(50)]
        public string d3 { get; set; }

        [StringLength(50)]
        public string d8 { get; set; }

        public bool? Isok { get; set; }

        public bool? IpEdit { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string d9 { get; set; }
    }
}
