using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salaryv2.Models;

namespace Salaryv2.Content
{
    public class RandomNumbersController : Controller
    {
        private Storedb db = new Storedb();

        // GET: RandomNumbers
        public ActionResult Index()
        {
            return View(db.RandomNumbers.ToList());
        }
        [AllowAnonymous]
        public string GenerateString()
        {
            Random rand = new Random();

            const string Alphabet =
           "0123456789";
            int size = 6;
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }

            return new string(chars);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GenerateCode()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        //public ActionResult GenerateCode(GetCode GetCode)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var Code = GenerateString();
        //        var EmployeeList = db.EmpPayWagAndEmpInfoByDateVs.Take(1000).ToList();
        //        var Modle = EmployeeList.Select(s => new EmpVm()
        //        {
        //            Acnt = s.ActiveBank == 1 ? s.Acnt : s.Acnt2,
        //            FullName = s.Name + " " + s.Fmly,
        //            Fthr = s.Fthr,
        //            CrnGrp = s.CrnGrp,
        //            DedCodTit = s.DedCodTit,
        //            DedVal = s.DedVal,
        //            PayCodTit = s.PayCodTit,
        //            PayVal = s.PayVal,
        //            ExtCodTit = s.ExtCodTit,
        //            ExtVal = s.ExtVal,
        //            NationCode = s.NationCode,
        //            InsId = s.InsId,
        //            CrnExtGrop = s.CrnExtGrop,
        //            MonthTitle = db.Months.Where(m => m.MonthId == s.Mnt).Select(m => m.MonthTitle).FirstOrDefault(),
        //            Branch = db.Branches.Where(b => b.Branch1 == s.Branch).Select(b => b.BranchDsc).FirstOrDefault(),
        //            Year = s.Year,
        //            EmpId = s.EmpId,

        //            Mnt = s.Mnt,
        //        }).AsQueryable();
        //        RandomNumber InsertCode = new RandomNumber();
        //        if (Modle == null)
        //        {
        //            TempData["message"] = "اطلاعات وارد شده صحیح نیست !";

        //            return View();
        //        }
        //        var SearchForMobile = Modle.OrderByDescending(o => o.Year).ThenByDescending(o => o.Mnt).FirstOrDefault();

        //        var mobile = Convert.ToString(SearchForMobile.e4);
        //        if (string.IsNullOrEmpty(mobile))
        //        {
        //            TempData["message"] = "برای ارسال شناسه امنیتی شماره تماس  شما در سیستم موجود نمیباشد";
        //            return RedirectToAction("search", "DWHEmpPayWagNews");

        //        }
        //        else if (Modle != null)
        //        {
        //            if (db.RandomNumbers.Where(r => r.e1 == SearchForMobile.e1 && r.b2 == SearchForMobile.b2).Count() > 0)
        //            {
        //                var InstanceRand = db.RandomNumbers.Where(r => r.e1 == SearchForMobile.e1 && r.b2 == SearchForMobile.b2).FirstOrDefault();
        //                InstanceRand.SequrityCode = Code.ToString();

        //                InstanceRand.EditDate = utility.PertionDate.Today();
        //                InstanceRand.EditTime = Convert.ToString(DateTime.Now.ToShortTimeString());
        //                InstanceRand.a2 = SearchForMobile.a2;
        //                InstanceRand.a3 = SearchForMobile.a3;
        //                InstanceRand.b6 = SearchForMobile.b6;
        //                InstanceRand.e4 = SearchForMobile.e4;
        //                InstanceRand.SequrityCode = Code.ToString();
        //                db.Entry(InstanceRand).State = EntityState.Modified;
        //                db.SaveChanges();
        //                utility.SmSSender.SendSmSCode(mobile, SearchForMobile.a2 + " " + SearchForMobile.a3, Code.ToString());
        //                TempData["message"] = "همکار گرامی پیامک حاوی کد شناسه امنیتی برای شما ارسال خواهد شد.......";

        //                return RedirectToAction("search", "DWHEmpPayWagNews");
        //            }
        //            else
        //            {
        //                InsertCode.a2 = SearchForMobile.a2;
        //                InsertCode.a3 = SearchForMobile.a3;
        //                InsertCode.b6 = SearchForMobile.b6;
        //                InsertCode.b2 = SearchForMobile.b2;
        //                InsertCode.e1 = SearchForMobile.e1;
        //                InsertCode.e4 = SearchForMobile.e4;



        //                InsertCode.Time = Convert.ToString(DateTime.Now.ToShortTimeString());
        //                InsertCode.Date = utility.PertionDate.Today();
        //                InsertCode.SequrityCode = Code.ToString();
        //                db.RandomNumbers.Add(InsertCode);
        //                db.SaveChanges();
        //                utility.SmSSender.SendSmSCode(mobile, SearchForMobile.a2 + " " + SearchForMobile.a3, Code.ToString());
        //                TempData["message"] = "همکار گرامی پیامک حاوی کد شناسه امنیتی برای شما ارسال خواهد شد.......";
        //                return RedirectToAction("search", "DWHEmpPayWagNews");

        //            }
        //        }


        //    }
        //    //return RedirectToAction("search", "DWHEmpPayWagNews");
        //    return View();
        //}
        // GET: RandomNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomNumber randomNumber = db.RandomNumbers.Find(id);
            if (randomNumber == null)
            {
                return HttpNotFound();
            }
            return View(randomNumber);
        }

        // GET: RandomNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RandomNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RandId,SequrityCode,NationCode,ComputerName,Date,Time,EditDate,EditTime,Name,acnt,CrnDeprt")] RandomNumber randomNumber)
        {
            if (ModelState.IsValid)
            {
                db.RandomNumbers.Add(randomNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(randomNumber);
        }

        // GET: RandomNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomNumber randomNumber = db.RandomNumbers.Find(id);
            if (randomNumber == null)
            {
                return HttpNotFound();
            }
            return View(randomNumber);
        }

        // POST: RandomNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RandId,SequrityCode,NationCode,ComputerName,Date,Time,EditDate,EditTime,Name,acnt,CrnDeprt")] RandomNumber randomNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(randomNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(randomNumber);
        }

        // GET: RandomNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomNumber randomNumber = db.RandomNumbers.Find(id);
            if (randomNumber == null)
            {
                return HttpNotFound();
            }
            return View(randomNumber);
        }

        // POST: RandomNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RandomNumber randomNumber = db.RandomNumbers.Find(id);
            db.RandomNumbers.Remove(randomNumber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
