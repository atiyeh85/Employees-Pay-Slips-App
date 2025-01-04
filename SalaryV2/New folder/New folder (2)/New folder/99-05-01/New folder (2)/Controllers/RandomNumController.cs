using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salaryv2.Models;

namespace Salaryv2.Controllers
{
    [Authorize]
    public class RandomNumController : ControllerBase
    {
        private Storedb db = new Storedb();
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

        private object GenerateString()
        {
            throw new NotImplementedException();
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
