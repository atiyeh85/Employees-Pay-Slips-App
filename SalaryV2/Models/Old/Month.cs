namespace SalaryV2.Models.Old
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Month
    {
        public int MonthId { get; set; }

        [StringLength(10)]
        public string MonthTitle { get; set; }

        [StringLength(2)]
        public string Caption { get; set; }
    }
}
