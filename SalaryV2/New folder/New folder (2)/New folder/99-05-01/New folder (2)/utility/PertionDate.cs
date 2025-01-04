using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salaryv2.utility
{
    public class PertionDate
    {
        public static string Today()
        {
            DateTime dt = DateTime.Now;

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();

            return p.GetYear(dt).ToString() + "/" + p.GetMonth(dt).ToString("0#") + "/" + p.GetDayOfMonth(dt).ToString("0#");
        }

        public static string CurrentMonth()
        {
            DateTime dt = DateTime.Now;

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();

            return Convert.ToString( p.GetMonth(dt).ToString());
             
    }
        public static string CurrentYear()
        {
            DateTime dt = DateTime.Now;

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();

            return Convert.ToString(p.GetYear(dt)) ;
        }
        public static int CurrentDay()
        {
            DateTime dt = DateTime.Now;

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();

            return p.GetDayOfMonth(dt);
        }
    }
}