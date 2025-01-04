using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalaryV2.Models;

namespace SalaryV2.Controllers
{
    public class EmpPayWagQazvinsController : Controller
    {
        private Storedb db = new Storedb();
        private Models.Corporate.CorporateDB CorDB = new Models.Corporate.CorporateDB();
        private Models.Old.OldStoredb DB = new Models.Old.OldStoredb();
        private List<EmpVm> _Employees;

        [AllowAnonymous]
        public ActionResult Search()
        {
            Session["Login"] = null;
            Session["e1"] = null;
            ViewBag.Contid = new SelectList(db.ContractTypes, "Contid", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Search(Search Smodel, int? Contid)
        {
            Models.Log log = new Models.Log();
            log.IpAddress = utility.IpAddress.GetUserIP();
            if (Contid == 1)
            {
                if (ModelState.IsValid)
                {
                    var id = db.RandomNumbers.Where(r => r.acnt == Smodel.b2 && r.NationCode == Smodel.e1).FirstOrDefault();
                    if (id != null)
                    {
                        if (id.SequrityCode != Smodel.SequrityCode)
                        {
                            ViewBag.Message = "  شناسه امنیتی اشتباه وارد شده است دوباره تلاش کنید  ";
                        }
                        else
                        {
                            try
                            {
                                var EmployeeList = CorDB.vwPersonnels.Where(e => e.IdentificationCode == Smodel.e1 & e.AccountNo == Smodel.b2).FirstOrDefault();

                                if (null == EmployeeList)
                                {
                                    return View();
                                }
                                Session["Login"] = true;

                                Session["e1"] = EmployeeList.IdentificationCode;

                                log.Time = DateTime.Now.ToShortTimeString();
                                log.Date = utility.PertionDate.Today();
                                log.NationCode = Smodel.e1;
                                log.Acnt = Smodel.b2;
                                log.Type = "ورود";
                                db.Logs.Add(log);
                                db.SaveChanges();
                                Session["Login"] = EmployeeList.AccountNo;
                                return RedirectToAction("Print", "vwCalculations", new { id = EmployeeList.PartyRef, e1 = EmployeeList.IdentificationCode });
                            }
                            catch (Exception e)
                            {

                                throw;
                            }
                        }
                    }
                    ViewBag.Contid = new SelectList(db.ContractTypes, "Contid", "Title");
                    ViewBag.Message = "موردی یافت نشد ،اطلاعات وارد شده صحیح نمیباشد.";
                }
                ViewBag.Contid = new SelectList(db.ContractTypes, "Contid", "Title");
                return View();
            }
            else if (Contid == 2)
            {
                if (ModelState.IsValid)
                {
                    var id = db.RandomNumbers.Where(r => r.acnt == Smodel.b2 && r.NationCode == Smodel.e1).FirstOrDefault();
                    if (id != null)
                    {
                        if (id.SequrityCode != Smodel.SequrityCode)
                        {
                            ViewBag.Message = "  شناسه امنیتی اشتباه وارد شده است دوباره تلاش کنید  ";
                        }
                        else
                        {
                            try
                            {
                                var Date = utility.PertionDate.Today();
                                var year = int.Parse(Date.Substring(0, 4));
                                var EmployeeList = db.EmpPayWagQazvins.Where(e => e.NationCode == Smodel.e1 && e.Acnt==Smodel.b2).ToList();
                               
                                TempData["EmployeeList"] = EmployeeList;
                                var Employeeinf = EmployeeList.FirstOrDefault();
                                TempData["Employeeinf"] = Employeeinf;

                                //if (EmployeeList.Count <= 0 || EmployeeList.Count == null)
                                //{
                                //    return View();
                                //}
                                Session["Login"] = true;
                                Session["e1"] = EmployeeList.Select(em => em.NationCode);
                                ViewBag.EmployeeInfo = EmployeeList;
                                log.Time = DateTime.Now.ToShortTimeString();
                                log.Date = utility.PertionDate.Today();
                                log.NationCode = Smodel.e1;
                                log.Acnt = Smodel.b2;
                                log.Type = "ورود";
                                db.Logs.Add(log);
                                db.SaveChanges();
                                Session["Login"] =Employeeinf.Acnt;
                                var Activebank =Employeeinf.Acnt ;
                                return RedirectToAction("Print", new { id = Activebank, e1 = Employeeinf.NationCode });

                            }
                            catch (Exception e)
                            {

                                throw;
                            }
                        }
                    }
                    ViewBag.Contid = new SelectList(db.ContractTypes, "Contid", "Title");
                    ViewBag.Message = "موردی یافت نشد ،اطلاعات وارد شده صحیح نمیباشد.";
                }
            }
            ViewBag.Contid = new SelectList(db.ContractTypes, "Contid", "Title");

            return View();
        }
        // GET: EmpPayWagQazvins
        public ActionResult Index()
        {
            return View(db.EmpPayWagQazvins.ToList());
        }

        [AllowAnonymous]
        public ActionResult Print(int? YearId, int? MonthId, string id = "", string e1 = "")
        {
            dynamic model = new ExpandoObject();
            ViewBag.MessageMonthNull = null;
            ViewBag.IsNew = true;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(e1))
            {
                return RedirectToAction("search");
            }
            var yearTo = db.Years.Where(y => y.YearId == YearId).FirstOrDefault();
            var MonthTo = db.Months.Where(y => y.MonthId == MonthId).FirstOrDefault();
            if (YearId != null)
            {
                int YearTitleint = int.Parse(yearTo.YearTitle);
                if (YearTitleint <= 1398)
                {
                    ViewBag.IsNew = false;
                    if (YearId.HasValue && YearId.Value != 0 && MonthId.HasValue && MonthId.Value != 0)
                    {
                        var Emo = DB.DWHEmpPayWagNews.Where(d => d.b2 == id && d.e1 == e1).AsQueryable();
                        var ggo = Convert.ToInt16(yearTo.YearTitle);
                        var ddo = Convert.ToByte(MonthTo.Caption);
                        Emo = Emo.Where(e => e.c4 == ggo && e.c5 == ddo);
                        if (Emo != null)
                        {
                            ViewBag.EmployeeName = DB.DWHEmpPayWagNews.Where(d => d.b2 == id && d.e1 == e1 && d.c5 == ddo && d.c4 == ggo).FirstOrDefault();
                            if (ViewBag.EmployeeName == null)
                            {
                                var EmployeeName = DB.DWHEmpPayWagNews.Where(d => d.b2 == id && d.e1 == e1).OrderByDescending(d => d.c4).ThenByDescending(d => d.c5).FirstOrDefault();
                                if (EmployeeName!=null)
                                {
                                    ViewBag.d3 = EmployeeName.d3;
                                    ViewBag.b2 = EmployeeName.b2;
                                    ViewBag.e1 = EmployeeName.e1;
                                    ViewBag.a1 = EmployeeName.a1;
                                    ViewBag.a2 = EmployeeName.a2;
                                    ViewBag.a3 = EmployeeName.a3;
                                    ViewBag.b6 = EmployeeName.b6;
                                    ViewBag.a4 = EmployeeName.a4;
                                    ViewBag.d9 = EmployeeName.d9;
                                    ViewBag.a8 = EmployeeName.a8;
                                    ViewBag.e6 = EmployeeName.e6;
                                    ViewBag.MessageMonthNull = "اطلاعاتی در مورد ماه وارد شده در سیستم موجود نمی باشد.";

                                }
                                else
                                {
                                ViewBag.MessageMonthNull = "شماره حساب و یا کد ملی اشتباه وارد شده یا در سیستم موجود نمی باشد.";
                                    ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", YearId);
                                    ViewBag.MonthId = new SelectList(db.Months.OrderByDescending(m => m.Caption), "MonthId", "MonthTitle", MonthId);
                                    return View(model);
                                }
                            }
                            model.Emo = Emo.ToList();
                            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", YearId);
                            ViewBag.MonthId = new SelectList(db.Months.OrderByDescending(m => m.Caption), "MonthId", "MonthTitle", MonthId);
                            return View(model);
                        }
                        else
                        {
                            ViewBag.MessageMonthNull = null;
                            Emo = Emo.Where(e => e.c4 == ggo && e.c5 == ddo).OrderByDescending(d => d.c4).ThenByDescending(d => d.c5);
                            var eee = DB.DWHEmpPayWagNews.Where(d => d.b2 == id && d.e1 == e1).OrderByDescending(d => d.c4).ThenByDescending(d => d.c5).FirstOrDefault();
                            ViewBag.EmployeeName = DB.DWHEmpPayWagNews.Where(d => d.b2 == id && d.e1 == e1).OrderByDescending(d => d.c4).ThenByDescending(d => d.c5).FirstOrDefault();
                            ViewBag.old = true;

                            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", YearId);
                            ViewBag.MonthId = new SelectList(db.Months.OrderByDescending(m => m.Caption), "MonthId", "MonthTitle", MonthId);
                            return View(model);
                        }
                    }
                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(e1))
                    {
                        return RedirectToAction("search");
                    }
                }
            }
            ViewBag.IsNew = true;
            var YearNow = utility.PertionDate.CurrentYear();
            var MonthNow = utility.PertionDate.CurrentMonth();
            var yearT = db.Years.Where(y => y.YearId == YearId).FirstOrDefault();
            var MonthT = db.Months.Where(y => y.MonthId == MonthId).FirstOrDefault();
            var yyy = db.Years.Where(y => y.YearTitle == YearNow).FirstOrDefault();
            var mmm = db.Months.Where(y => y.Caption == MonthNow).FirstOrDefault();
            var yy = yyy.YearId;
            var mm = mmm.MonthId;
            var mmStr = mm.ToString();
            var hh = db.Months.ToList();
            var EmployeeList = (List<EmpPayWagQazvin>)TempData["EmployeeList"];
            var MyModle = EmployeeList.Select(s => new EmpVm()
            {
                Acnt =  s.Acnt ,
                FullName = s.Name + " " + s.Fmly,
                Fthr = s.Fthr,
                DedCodTit = s.DedCodTit,
                DedVal = s.DedVal,
                PayCodTit = s.PayCodTit,
                PayVal = s.PayVal,
                ExtCodTit = s.ExtCodTit,
                ExtVal = s.ExtVal,
                NationCode = s.NationCode,
                InsId = s.InsId,
                Branch = db.Branch.Where(b => b.Branch1 == s.Branch).Select(b => b.BranchDsc).FirstOrDefault(),
                Year = s.Year,
                Mnt = s.Mnt,
                EmpId = s.EmpId
            }).ToList();
            var Employee = MyModle.Where(m => m.Acnt == id).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt).FirstOrDefault();
            var lastM = Convert.ToString(Employee.Mnt);
            var lastY = Convert.ToString(Employee.Year);
            var LastYy = db.Years.Where(y => y.YearTitle == lastY).FirstOrDefault();
            var LastMm = db.Months.Where(y => y.Caption == lastM).FirstOrDefault();
            var Em = MyModle.Where(m => m.Acnt == id && m.NationCode == e1).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt).AsQueryable();

            if (YearId.HasValue && YearId.Value != 0 && MonthId.HasValue && MonthId.Value != 0)
            {

                yy = yearT.YearId;
                mm = MonthT.MonthId;
                var gg = Convert.ToInt16(yearT.YearTitle);
                var dd = Convert.ToByte(MonthT.Caption);
                Em = Em.Where(e => e.Year == gg && e.Mnt == dd);
                if (Em != null)
                {
                    ViewBag.EmployeeName = Em.FirstOrDefault();
                    if (ViewBag.EmployeeName == null)
                    {

                        ViewBag.d3 = /*Employee.d3*/"";
                        ViewBag.b2 = Employee.Acnt;
                        ViewBag.e1 = Employee.NationCode;
                        ViewBag.a1 = Employee.EmpId;
                        ViewBag.a2 = Employee.FullName;
                        //ViewBag.a3 = Employee.a3;
                        ViewBag.b6 = Employee.Fthr;
                        ViewBag.a4 = Employee.InsId;
                        ViewBag.d9 = Employee.Branch;
                        ViewBag.a8 = Employee.CrnGrp;
                        ViewBag.e6 = Employee.CrnExtGrop;
                        ViewBag.e8 = Employee.Year;
                        var Mnt = Convert.ToString(dd);

                        ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();

                        ViewBag.MessageMonthNull = "اطلاعاتی در مورد ماه وارد شده در سیستم موجود نمی باشد.";

                    }
                }
                else
                {
                    ViewBag.MessageMonthNull = null;
                    Em = Em.Where(e => e.Year == gg && e.Mnt == dd).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt);
                    //var eee = db.DWHEmpPayWagNews.Where(d => d.b2 == id && d.e1 == e1).OrderByDescending(d => d.c4).ThenByDescending(d => d.c5).FirstOrDefault();
                    ViewBag.EmployeeName = Employee;
                    model.Em = Em.ToList();
                    return View(model);
                }
            }
            else
            {
                ViewBag.MessageMonthNull = null;
                ViewBag.EmployeeName = Employee;
                Em = Em.Where(d => d.Year == Employee.Year && d.Mnt == Employee.Mnt);
                ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", LastYy.YearId);
                ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", LastMm.MonthId);
                ViewBag.b2 = id;
                ViewBag.e1 = e1;
                var Mnt = Convert.ToString(Employee.Mnt);
                model.Em = Em.ToList();
                ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();
                return View(model);
            }
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", yy);

            ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", mm);

            model.Em = Em.ToList();
            ViewBag.e7 = db.Months.Where(m => m.MonthId == mm).Select(m => m.MonthTitle).FirstOrDefault();
            return View(model);
        }


        [AllowAnonymous]
        public List<EmpVm> DetailsEm(int? YearId, int? MonthId, string id = "", string e1 = "")
        {
            var YearNow = utility.PertionDate.CurrentYear();
            var MonthNow = utility.PertionDate.CurrentMonth();
            var yearT = db.Years.Where(y => y.YearId == YearId).FirstOrDefault();
            var MonthT = db.Months.Where(y => y.MonthId == MonthId).FirstOrDefault();
            var yyy = db.Years.Where(y => y.YearTitle == YearNow).FirstOrDefault();
            var mmm = db.Months.Where(y => y.Caption == MonthNow).FirstOrDefault();
            var yy = yyy.YearId;
            var mm = mmm.MonthId;
            var EmployeeList = db.EmpPayWagQazvins.Where(e => e.NationCode == e1).ToList();
            var Modle = EmployeeList.Select(s => new EmpVm()
            {
                Acnt = s.Acnt ,
                FullName = s.Name + " " + s.Fmly,
                Fthr = s.Fthr,
                //CrnGrp = s.CrnGrp,
                //CrnExtGrop = s.CrnExtGrop,
                DedCodTit = s.DedCodTit,
                DedVal = s.DedVal,
                PayCodTit = s.PayCodTit,
                PayVal = s.PayVal,
                ExtCodTit = s.ExtCodTit,
                ExtVal = s.ExtVal,
                NationCode = s.NationCode,
                InsId = s.InsId,
                Branch = db.Branch.Where(b => b.Branch1 == s.Branch).Select(b => b.BranchDsc).FirstOrDefault(),
                Year = s.Year,
                Mnt = s.Mnt,
                EmpId = s.EmpId

            }).ToList();
            var Employee = Modle.Where(m => m.Acnt == id).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt).FirstOrDefault();
            var lastM = Convert.ToString(Employee.Mnt);
            var lastY = Convert.ToString(Employee.Year);
            var LastYy = db.Years.Where(y => y.YearTitle == lastY).FirstOrDefault();
            var LastMm = db.Months.Where(y => y.Caption == lastM).FirstOrDefault();
            var Em = Modle.Where(m => m.Acnt == id && m.NationCode == e1).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt).AsQueryable();

            if (YearId.HasValue && YearId.Value != 0 && MonthId.HasValue && MonthId.Value != 0)
            {

                yy = yearT.YearId;
                mm = MonthT.MonthId;
                var gg = Convert.ToInt16(yearT.YearTitle);
                var dd = Convert.ToByte(MonthT.Caption);
                Em = Em.Where(e => e.Year == gg && e.Mnt == dd);
                if (Em != null)
                {
                    ViewBag.EmployeeName = Em.FirstOrDefault();
                    if (ViewBag.EmployeeName == null)
                    {

                        ViewBag.d3 = /*Employee.d3*/"";
                        ViewBag.b2 = Employee.Acnt;
                        ViewBag.e1 = Employee.NationCode;
                        ViewBag.a1 = Employee.EmpId;
                        ViewBag.a2 = Employee.FullName;
                        ViewBag.b6 = Employee.Fthr;
                        ViewBag.a4 = Employee.InsId;
                        ViewBag.d9 = Employee.Branch;
                        ViewBag.a8 = Employee.CrnGrp;
                        ViewBag.e6 = Employee.CrnExtGrop;
                        ViewBag.e8 = Employee.Year;
                        var Mnt = Convert.ToString(dd);

                        ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();

                        ViewBag.MessageMonthNull = "اطلاعاتی در مورد ماه وارد شده در سیستم موجود نمی باشد.";

                    }
                }
                else
                {
                    ViewBag.MessageMonthNull = null;
                    Em = Em.Where(e => e.Year == gg && e.Mnt == dd).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt);
                    ViewBag.EmployeeName = Employee;
                    _Employees = new List<EmpVm>()
                    ;
                    _Employees.AddRange(Em);
                    //foreach (var item in Em)
                    //{
                    //    _Employees.Add(item);
                    //}
                    return _Employees;
                }
            }
            else
            {
                ViewBag.MessageMonthNull = null;
                ViewBag.EmployeeName = Employee;
                Em = Em.Where(d => d.Year == Employee.Year && d.Mnt == Employee.Mnt);
                ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", LastYy.YearId);
                ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", LastMm.MonthId);
                ViewBag.b2 = id;
                ViewBag.e1 = e1;
                var Mnt = Convert.ToString(Employee.Mnt);

                ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();
                //foreach (var item in Em)
                //{
                //    _Employees.Add(item);
                //}
                //return _Employees;
                _Employees = new List<EmpVm>()
                   ;
                _Employees.AddRange(Em);
            }
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", yy);

            ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", mm);


            ViewBag.e7 = db.Months.Where(m => m.MonthId == mm).Select(m => m.MonthTitle).FirstOrDefault();
            //foreach (var item in Em)
            //{
            //    _Employees.Add(item);


            //}
            _Employees = new List<EmpVm>()
                   ;
            _Employees.AddRange(Em);
            return _Employees;
        }

        [AllowAnonymous]
        public ActionResult GeneratePDF(string c5, string id = "", string e1 = "", string c4 = "")
        {
            if (!User.Identity.IsAuthenticated)
            {

                if (Convert.ToString(Session["Login"]) != id.ToString())
                {
                    return RedirectToAction("search");
                }
            }
            var yyy = db.Years.Where(y => y.YearTitle == c4).FirstOrDefault();
            var mmm = db.Months.Where(y => y.Caption == c5).FirstOrDefault();
            var yy = yyy.YearId;
            var mm = mmm.MonthId;

            var createpdf = new Rotativa.ActionAsPdf("_pdf", new { id = id, YearId = yy, MonthId = mm, e1 = e1, ispdf = true });
            Session["Login"] = id.ToString();
            return createpdf;
        }
        [AllowAnonymous]
        public ActionResult _pdf(int? YearId, int? MonthId, string id = "", string e1 = "")
        {
            var Modle = DetailsEm(YearId, MonthId, id, e1);
            return View(Modle.ToList());
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
