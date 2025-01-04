namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class Contract
    {
        public int? ContractRef { get; set; }
        public string CostCenterTitle { get; set; }
    }
}
