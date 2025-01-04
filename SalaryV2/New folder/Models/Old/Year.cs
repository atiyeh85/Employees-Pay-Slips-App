namespace SalaryV2.Models.Old
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Year
    {
        public int YearId { get; set; }

        [StringLength(4)]
        public string YearTitle { get; set; }
    }
}
