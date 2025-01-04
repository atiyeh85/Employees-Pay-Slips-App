using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalaryV2.Models;

namespace SalaryV2.Controllers
{
    [Authorize]
    public class RandomNumController : ControllerBase
    {
        private Storedb db = new Storedb();
        private Models.Corporate.CorporateDB CorDB = new Models.Corporate.CorporateDB();
        // GET: RandomNum
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            var List = db.RandomNumbers.OrderByDescending(o => o.EditDate).ToList();
            return View(db.RandomNumbers.ToList());
        }
        // GET: RandomNum/Details/5
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
        [AllowAnonymous]
        public ActionResult SendCode(int id)
        {

            var List = db.RandomNumbers.Where(r => r.RandId == id).OrderByDescending(o => o.RandId).FirstOrDefault();
            return PartialView("_SendCode", List);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GenerateCode()
        {
            ViewBag.Contid = new SelectList(db.ContractTypes, "Contid", "Title");
            return View();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult GenerateCode(GetCode GetCode)
        {
            if (ModelState.IsValid)
            {
                var Code = GenerateString();
                RandomNumber InsertCode = new RandomNumber();
                if (GetCode.Contid == 1)
                {
                    {
                        var per = CorDB.vwPersonnels.Where(p => p.AccountNo == GetCode.b2 && p.IdentificationCode == GetCode.e1).FirstOrDefault();
                        var empProfile = CorDB.vwParties.Where(p => p.PartyId == per.PartyRef).FirstOrDefault();

                        if (empProfile != null)
                        {
                            if (empProfile.Phone != null)
                            {
                                if (db.RandomNumbers.Where(r => r.NationCode == empProfile.IdentificationCode && r.acnt == per.AccountNo).Count() > 0)
                                {
                                    var InstanceRand = db.RandomNumbers.Where(r => r.NationCode == empProfile.IdentificationCode && r.acnt == per.AccountNo).FirstOrDefault();
                                    InstanceRand.SequrityCode = Code.ToString();
                                    InstanceRand.EditDate = utility.PertionDate.Today();
                                    InsertCode.EditTime = Convert.ToString(DateTime.Now.ToShortTimeString());
                                    InstanceRand.NationCode = empProfile.IdentificationCode;
                                    //InstanceRand.Father = empProfile.na;
                                    InstanceRand.Fname = empProfile.Name;
                                    InstanceRand.Mobile = empProfile.Phone;
                                    InstanceRand.acnt = per.AccountNo;
                                    InstanceRand.Lname = empProfile.LastName;
                                    InstanceRand.Type =Convert.ToString(GetCode.Contid);
                                    InstanceRand.SequrityCode = Code.ToString();
                                    db.Entry(InstanceRand).State = EntityState.Modified;
                                    db.SaveChanges();
                                    utility.SmSSender.SendSmSCode(empProfile.Phone, empProfile.FullName, Code.ToString());
                                    TempData["message"] = "همکار گرامی پیامک حاوی کد شناسه امنیتی برای شما ارسال خواهد شد.......";
                                    return RedirectToAction("search", "EmpPayWagQazvins");
                                }
                                else
                                {
                                    InsertCode.SequrityCode = Code.ToString();
                                    InsertCode.EditDate = utility.PertionDate.Today();
                                    InsertCode.EditTime = Convert.ToString(DateTime.Now.ToShortTimeString());
                                    InsertCode.NationCode = empProfile.IdentificationCode;
                                    InsertCode.Fname = empProfile.Name;
                                    InsertCode.Mobile = empProfile.Phone;
                                    InsertCode.acnt = per.AccountNo;
                                    InsertCode.Lname = empProfile.LastName;
                                    InsertCode.Type = Convert.ToString(GetCode.Contid);

                                    InsertCode.Time = Convert.ToString(DateTime.Now.ToShortTimeString());
                                    InsertCode.Date = utility.PertionDate.Today();
                                    
                                    db.RandomNumbers.Add(InsertCode);
                                    db.SaveChanges();
                                    utility.SmSSender.SendSmSCode(empProfile.Phone, empProfile.FullName, Code.ToString());
                                    TempData["message"] = "همکار گرامی پیامک حاوی کد شناسه امنیتی برای شما ارسال خواهد شد.......";
                                    return RedirectToAction("search", "EmpPayWagQazvins");
                                }

                            }
                            else
                            {
                                TempData["message"] = "  شماره تماس  شما جهت ارسال شناسه امنیتی در ثبت نشده است  .     ";
                                return RedirectToAction("search", "EmpPayWagQazvins");
                            }

                        }
                       
                    }
                }
                else if (GetCode.Contid == 2)
                {


                    var Suser = db.EmpPayWagQazvins.Where(d => d.NationCode == GetCode.e1 && d.Acnt == GetCode.b2).OrderByDescending(y => y.Year).ThenByDescending(y => y.Mnt).FirstOrDefault();

                    var TelMobil = Convert.ToString(Suser.TelMobil);
                    if (string.IsNullOrEmpty(TelMobil))
                    {
                        TempData["message"] = "  شماره تماس  شما جهت ارسال شناسه امنیتی ثبت نشده است  .     ";

                        return RedirectToAction("search", "DWHEmpPayWagNews");
                    }
                    else if (Suser != null)
                    {
                        if (db.RandomNumbers.Where(r => r.NationCode == Suser.NationCode && r.acnt == Suser.Acnt).Count() > 0)
                        {
                            var InstanceRand = db.RandomNumbers.Where(r => r.NationCode == Suser.NationCode && r.acnt == Suser.Acnt).FirstOrDefault();

                            InstanceRand.EditTime = Convert.ToString(DateTime.Now.ToShortTimeString());
                            InstanceRand.EditDate = utility.PertionDate.Today();
                            InstanceRand.NationCode = Suser.NationCode;
                            InstanceRand.Father = Suser.Fthr;
                            InstanceRand.Fname = Suser.Name;
                            InstanceRand.Mobile = Suser.TelMobil;
                            InstanceRand.acnt = Suser.Acnt;
                            InstanceRand.Lname = Suser.Fmly;
                            InstanceRand.SequrityCode = Code.ToString();
                            db.Entry(InstanceRand).State = EntityState.Modified;
                            db.SaveChanges();
                            utility.SmSSender.SendSmSCode(TelMobil, Suser.Name +" "+ Suser.Fmly, Code.ToString());
                            TempData["message"] = "همکار گرامی پیامک حاوی کد شناسه امنیتی برای شما ارسال خواهد شد.......";
                            return RedirectToAction("search", "EmpPayWagQazvins");
                        }
                        else
                        {
                            InsertCode.SequrityCode = Code.ToString();
                            InsertCode.EditDate = utility.PertionDate.Today();
                            InsertCode.EditTime = Convert.ToString(DateTime.Now.ToShortTimeString());
                            InsertCode.NationCode = Suser.NationCode;
                            InsertCode.Father = Suser.Fthr;
                            InsertCode.Fname = Suser.Name;
                            InsertCode.Mobile = Suser.TelMobil;
                            InsertCode.acnt = Suser.Acnt;
                            InsertCode.Lname = Suser.Fmly;

                            InsertCode.Time = Convert.ToString(DateTime.Now.ToShortTimeString());
                            InsertCode.Date = utility.PertionDate.Today();
                            db.RandomNumbers.Add(InsertCode);
                            db.SaveChanges();
                            utility.SmSSender.SendSmSCode(TelMobil, Suser.Name + " " + Suser.Fmly, Code.ToString());
                            TempData["message"] = "همکار گرامی پیامک حاوی کد شناسه امنیتی برای شما ارسال خواهد شد.......";
                            return RedirectToAction("search", "EmpPayWagQazvins");
                        }
                    }
                }
                ViewBag.Contid = new SelectList(db.ContractTypes, "Contid", "Title");
                return View();
            }
            ViewBag.Contid = new SelectList(db.ContractTypes, "Contid", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendCode(RandomNumber RandN)
        {
            if (RandN == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RandomNumber Rand = db.RandomNumbers.Find(RandN.RandId);
            if (Rand == null)
            {
                TempData["message"] = "اطلاعات وارد شده در سیستم موجود نمی باشد  !";
                return Danger("", String.Format("اطلاعات وارد شده در سیستم موجود نمی باشد  !"));
            }
            else
            {
                try
                {
                    var code = utility.SmSSender.GenerateString();
                    var mobile = Convert.ToString(Rand.Mobile);
                    if (string.IsNullOrEmpty(mobile))
                    {
                        TempData["message"] = "برای ارسال شناسه امنیتی شماره تماس  شما در سیستم موجود نمی باشد";
                        return Danger("", String.Format("برای ارسال شناسه امنیتی شماره تماس  شما در سیستم موجود نمیباشد"));
                    }
                    else
                    {
                            var InstanceRand = db.RandomNumbers.Where(r => r.NationCode == Rand.NationCode && r.acnt == Rand.acnt).FirstOrDefault();
                            InstanceRand.EditDate = utility.PertionDate.Today();
                            InstanceRand.EditTime = Convert.ToString(DateTime.Now.ToShortTimeString());
                            InstanceRand.SequrityCode = code.ToString();
                            InstanceRand.Mobile = mobile;
                            InstanceRand.Fname = Rand.Fname;
                            InstanceRand.Lname = Rand.Lname;
                            InstanceRand.Father = Rand.Father;
                            db.Entry(InstanceRand).State = EntityState.Modified;
                            db.SaveChanges();
                            utility.SmSSender.SendSmSCode(mobile, Rand.Fname + " " + Rand.Lname, code.ToString());
                            TempData["message"] = "همکار گرامی پیامک حاوی کد شناسه امنیتی   ارسال خواهد شد.......";
                            return Success("", string.Format(" ارسال پیامک با موفقیت انجام شد!  ", true));
                    }
                }
                catch (Exception)
                {
                    return Danger("", String.Format("ارسال پیامک حاوی کد امنیتی با مشکل مواجه شد", true));
                }
            }
        }
        // GET: RandomNum/Create
        public ActionResult CreateSendCode()
        {
            return PartialView("_CreateSendCode");
        }
        // POST: RandomNum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSendCode(GetCode GetCode)
        {
            var Code = utility.SmSSender.GenerateString();
            if (ModelState.IsValid)
            {
                if (GetCode == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var EmployeeList = db.EmpPayWagAndEmpInfoByDateVs.Where(e => e.NationCode == GetCode.e1).ToList();
                var Modle = EmployeeList.Select(s => new EmpVm()
                {
                    Acnt = s.ActiveBank == 1 ? s.Acnt : s.Acnt2,
                    Fname = s.Name ,
                  Lname=  s.Fmly,
                    Fthr = s.Fthr,
                    Year = s.Year,
                    Mnt = s.Mnt,
                    EmpId = s.EmpId,
                    TelMobil = s.TelMobil,
                    NationCode=s.NationCode

                });
                var Employee = Modle.Where(m => m.Acnt == GetCode.b2).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt).FirstOrDefault();
                if (Employee == null)
                {

                    TempData["message"] = "اطلاعات به درستی وارد نشده است !";

                    return Danger("", String.Format(" اطلاعات به درستی وارد نشده است !", true));
                   
                }
                else
                {
                    var ra = db.RandomNumbers.Where(r => r.acnt == Employee.Acnt && Employee.NationCode == r.NationCode).FirstOrDefault();
                    if (ra==null)
                    {
                        var Rand = new RandomNumber();
                        Rand.Father = Employee.Fthr;
                        Rand.Fname = Employee.Fname;
                        Rand.Lname = Employee.Lname;
                        Rand.Mobile = Employee.TelMobil;
                        Rand.NationCode = Employee.NationCode;
                        Rand.acnt = Employee.Acnt;
                        Rand.SequrityCode = Code;
                        Rand.Date = utility.PertionDate.Today();
                        Rand.Time = DateTime.Now.ToShortTimeString();
                        Rand.EditDate = utility.PertionDate.Today();
                        Rand.EditTime = DateTime.Now.ToShortTimeString();
                        db.RandomNumbers.Add(Rand);
                        db.SaveChanges();
                        if (!string.IsNullOrEmpty(Employee.TelMobil))
                        {
                            utility.SmSSender.SendSmSCode(Employee.TelMobil, Employee.Fname + " " + Employee.Lname, Code.ToString());
                            TempData["message"] = "همکار گرامی پیامک حاوی کد شناسه امنیتی   ارسال خواهد شد.......";
                            return Success("", string.Format(" ارسال پیامک با موفقیت انجام شد!  ", true));
                        }
                        else
                        {
                            TempData["message"] = "    شماره تلفن همراه در سیستم ثبت نشده است  !";
                            return Success("", string.Format(" شماره تلفن همراه در سیستم ثبت نشده است !", true));
                        }
                       
                    }
                    else
                    {
                        TempData["message"] = " اطلاعات وارد شده تکراری است !";
                        return Success("", string.Format(" اطلاعات وارد شده تکراری است !", true));
                    }
                }
            }

            return Success("", string.Format(" اطلاعات وارد شده تکراری است !", true));

        }

       

        // GET: RandomNum/Edit/5
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
        // POST: RandomNum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RandomNumber randomNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(randomNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(randomNumber);
        }

        // GET: RandomNum/Delete/5
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

        // POST: RandomNum/Delete/5
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
