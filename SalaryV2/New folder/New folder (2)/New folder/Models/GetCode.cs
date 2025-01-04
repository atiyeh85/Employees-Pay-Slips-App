using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaryV2.Models
{
    public class GetCode
    {
        [Key]
        public int id { get; set; }

        [DisplayName("شماره حساب")]
        [StringLength(20)]
        [Required(ErrorMessage = "پر کردن شماره حساب  اجباریست ")]
        public string b2 { get; set; }

        [StringLength(10, ErrorMessage = "فیلد کد ملی  باید 10 رقمی باشد", MinimumLength = 10)]
        [DisplayName("کد ملی ")]
        [Required(ErrorMessage = "پر کردن کد ملی اجباریست ")]
        public string e1 { get; set; }
        [Required(ErrorMessage = "پر کردن نوع قرارداد  اجباریست ")]
        public int Contid { get; set; }





    }
}