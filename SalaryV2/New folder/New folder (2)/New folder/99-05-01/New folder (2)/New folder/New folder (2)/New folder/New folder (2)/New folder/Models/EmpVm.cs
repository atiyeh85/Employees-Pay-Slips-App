using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Salaryv2.Models
{
    public class EmpVm
    {

        public string PayCodTit { get; set; }

        [Column(TypeName = "money")]
        public decimal? PayVal { get; set; }

        public short? DedCodId { get; set; }

        [StringLength(100)]
        public string DedCodTit { get; set; }

        [Column(TypeName = "money")]
        public decimal? DedVal { get; set; }

        public short? ExtCodId { get; set; }
        public long EmpId { get; set; }
        [StringLength(100)]
        public string ExtCodTit { get; set; }
        public string TelMobil { get; set; }
        [Column(TypeName = "money")]
        public decimal? ExtVal { get; set; }

        [StringLength(100)]
        public string ExtValDsc { get; set; }
        public string MonthTitle { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(25)]
        public string Fthr { get; set; }
        [StringLength(15)]
        public string InsId { get; set; }
        [StringLength(20)]
        public string Acnt { get; set; }

        public int? Bank { get; set; }
        public byte? CrnGrp { get; set; }
        [StringLength(15)]
        public string NationCode { get; set; }
        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CrnDeprt { get; set; }
        public string Branch { get; set; }
        public short Year { get; set; }
        public byte Mnt { get; set; }
        public byte? CrnExtGrop { get; set; }
    }
}