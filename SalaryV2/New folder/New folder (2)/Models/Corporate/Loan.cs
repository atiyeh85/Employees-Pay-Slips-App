using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryV2.Models.Corporate
{
    public class Loan
    {
        public decimal TotalAmount { get; set; }
        public string Target { get; set; }
        public decimal RemainedAmount { get; set; }
       
    }
    public class LoanVm
    {
        public decimal TotalAmount { get; set; }
        public string Target { get; set; }
        public int PerMonth { get; set; }
        public decimal RemainedAmount { get; set; }

    }
}