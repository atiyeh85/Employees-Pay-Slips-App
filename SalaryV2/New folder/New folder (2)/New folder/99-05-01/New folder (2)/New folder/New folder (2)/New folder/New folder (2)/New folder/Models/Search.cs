﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salaryv2.Models
{
    public class Search
    {
        
        [DisplayName("شماره حساب")]
        [StringLength(20)]
        [Required(ErrorMessage = "پر کردن شماره حساب  اجباریست ")]
        public string b2 { get; set; }
        [DisplayName("کد ملی ")]
        [StringLength(10, ErrorMessage = "فیلد کد ملی  باید 10 رقمی باشد", MinimumLength = 10)]
        [Required(ErrorMessage = "پر کردن کد ملی اجباریست ")]
        public string e1 { get; set; }
        [DisplayName("شناسه امنیتی  ")]

        [Required(ErrorMessage = "پر کردن شناسه امنیتی  اجباریست ")]
        public string SequrityCode { get; set; }

    }
}