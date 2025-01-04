using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Salaryv2.Parsasms;

namespace Salaryv2.utility
{
    public class SmSSender
    {
        public static void SendSmS(string tel, string Name)
        {
            string name = Name;
            string Phone = tel;
            DateTime date;
            string message = " " + "همکار گرامی " + name +" "+ "ورود شما به سامانه دریافت فیش حقوقی با موفقیت انجام شد. " +  "   سازمان آمار و فناوری اطلاعات شهرداری قزوین";
            string username = "shahrdariqazvin_fava";
            string password = "fava281";
            string[] senderNumbers = { "30002309" };
            string[] recipientNumbers = { Phone };
            //string[] recipientNumbersAdmin = { "09366434536" };
            string[] messageBodies = { message };

            date = DateTime.Now;
            date = DateTime.Now.AddMinutes(2);
            string[] senddate = { date.ToString() };
            int[] messageClasses = { };
            long[] MessageIDs = { };
            //Parsasms.v2 ps = new Parsasms.v2();
            //MessageIDs = ps.SendSMS(username, password, senderNumbers, recipientNumbers, messageBodies, null, null, null);

        }
             public static void SendSmSCode(string tel, string Name,string code)
        {
            string name = Name;
            string Phone = tel;
            DateTime date;
            string message = " " + "همکار گرامی " + name +" "+ "شناسه امنیتی شما " + code.ToString()+ "   سازمان فناوری اطلاعات و ارتباطات شهرداری قزوین";
            string username = "shahrdariqazvin_fava";
            string password = "fava281";
            string[] senderNumbers = { "30002309" };
            string[] recipientNumbers = { Phone };
            //string[] recipientNumbersAdmin = { "09366434536" };
            string[] messageBodies = { message };

            date = DateTime.Now;
            date = DateTime.Now.AddMinutes(2);
            string[] senddate = { date.ToString() };
            int[] messageClasses = { };
            long[] MessageIDs = { };
            Parsasms.v2 ps = new Parsasms.v2();
            MessageIDs = ps.SendSMS(username, password, senderNumbers, recipientNumbers, messageBodies, null, null, null);

        }
     
    }
}