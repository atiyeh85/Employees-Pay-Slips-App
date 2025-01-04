namespace SalaryV2.Models
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
        public string NationCode { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string acnt { get; set; }

        [StringLength(150)]
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
        public string Lname { get; set; }

        [StringLength(50)]
        public string Fname { get; set; }

        [StringLength(50)]
        public string Father { get; set; }
    }
}
