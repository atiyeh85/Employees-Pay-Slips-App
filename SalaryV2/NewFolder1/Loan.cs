namespace SalaryV2.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAY.Loan")]
    public partial class Loan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoanID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Title_En { get; set; }

        public bool IsActive { get; set; }

        public int Version { get; set; }

        public int Creator { get; set; }

        public DateTime CreationDate { get; set; }

        public int LastModifier { get; set; }

        public DateTime LastModificationDate { get; set; }
    }
}
