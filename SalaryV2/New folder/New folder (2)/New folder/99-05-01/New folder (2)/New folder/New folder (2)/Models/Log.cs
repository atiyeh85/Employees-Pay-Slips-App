namespace Salaryv2.Models
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
        public string Date { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [StringLength(50)]
        public string ComputerName { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }

        public bool? IsPrint { get; set; }

        public bool? Isok { get; set; }

        public bool? IpEdit { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string NationCode { get; set; }

        [StringLength(50)]
        public string Acnt { get; set; }
    }
}
