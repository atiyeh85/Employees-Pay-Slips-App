namespace SalaryV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractType")]
    public partial class ContractType
    {
        [Key]
        public int Contid { get; set; }

        [StringLength(500)]
        public string Title { get; set; }
    }
}
