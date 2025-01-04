namespace SalaryV2.Models.Old
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RandomNumber
    {
        [Key]
        public int RandId { get; set; }

        [StringLength(50)]
        public string SequrityCode { get; set; }

        [StringLength(50)]
        public string e1 { get; set; }

        [StringLength(50)]
        public string e4 { get; set; }

        [StringLength(50)]
        public string b2 { get; set; }

        [StringLength(50)]
        public string ComputerName { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [StringLength(50)]
        public string EditDate { get; set; }

        [StringLength(50)]
        public string EditTime { get; set; }

        [StringLength(50)]
        public string a2 { get; set; }

        [StringLength(50)]
        public string a3 { get; set; }

        [StringLength(50)]
        public string b6 { get; set; }

        public bool? C4 { get; set; }

        public bool? c5 { get; set; }
    }
}
