using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalaryV2.parsasms;

namespace SalaryV2.utility
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
            string password = "";
            string[] senderNumbers = { "" };
            string[] recipientNumbers = { Phone };
            //string[] recipientNumbersAdmin = { "" };
            string[] messageBodies = { message };

            date = DateTime.Now;
            date = DateTime.Now.AddMinutes(2);
            string[] senddate = { date.ToString() };
            int[] messageClasses = { };
            long[] MessageIDs = { };
            parsasms.v2 ps = new parsasms.v2();
            MessageIDs = ps.SendSMS(username, password, senderNumbers, recipientNumbers, messageBodies, null, null, null);

        }
             public static void SendSmSCode(string tel, string Name,string code)
        {
            string name = Name;
            string Phone = tel;
            DateTime date;
            string message = " " + "همکار گرامی " + name +" "+ "شناسه امنیتی شما " + code.ToString()+" "+"می باشد."+ "   سازمان فناوری اطلاعات و ارتباطات شهرداری قزوین";
            string username = "shahrdariqazvin_fava";
            string password = "";
            string[] senderNumbers = { "" };
            string[] recipientNumbers = { Phone };
            //string[] recipientNumbersAdmin = { "" };
            string[] messageBodies = { message };

            date = DateTime.Now;
            date = DateTime.Now.AddMinutes(2);
            string[] senddate = { date.ToString() };
            int[] messageClasses = { };
            long[] MessageIDs = { };
            parsasms.v2 ps = new parsasms.v2();
            MessageIDs = ps.SendSMS(username, password, senderNumbers, recipientNumbers, messageBodies, null, null, null);

        }
        public static string GenerateString()
        {
            Random rand = new Random();

            const string Alphabet =
           "123456789";
            int size = 6;
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }

    }
}