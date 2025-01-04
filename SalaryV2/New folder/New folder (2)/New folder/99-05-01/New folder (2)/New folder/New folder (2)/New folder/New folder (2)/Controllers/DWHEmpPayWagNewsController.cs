using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Salaryv2.Models;

namespace Salaryv2.Controllers
{
    public class DWHEmpPayWagNewsController : Controller
    {
        
        private Storedb db = new Storedb();
        // GET: DWHEmpPayWagNews
        private List<EmpVm> _Employees;
           
        [AllowAnonymous]
        public ActionResult Search()
        {
            Session["Login"] = null;
            Session["e1"] = null;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Search(Search Smodel)
        {
            Log log = new Log();
            log.IpAddress = utility.IpAddress.GetUserIP();
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
                            //var Employee = db.EmpPayWagAndEmpInfoByDateVs.Where(p =>(p.ActiveBank==1)== model.b2 && p.NationCode == model.e1).FirstOrDefault();
                            var EmployeeList = db.EmpPayWagAndEmpInfoByDateVs.Where(e=>e.NationCode==Smodel.e1).ToList() ;
                            var Modle = EmployeeList.Select(s => new EmpVm()
                            {
                                Acnt = s.ActiveBank == 1 ? s.Acnt : s.Acnt2  ,
                                FullName = s.Name + " " + s.Fmly,
                                Fthr =s.Fthr,
                                CrnGrp=s.CrnGrp,
                              DedCodTit  =s.DedCodTit,
                              DedVal=  s.DedVal,
                              PayCodTit=  s.PayCodTit,
                              PayVal=  s.PayVal,
                              ExtCodTit=s.ExtCodTit,
                              ExtVal=s.ExtVal,
                              NationCode=s.NationCode,
                              InsId=s.InsId,
                                CrnExtGrop = s.CrnExtGrop,
                                MonthTitle=db.Months.Where(m=>m.MonthId==s.Mnt).Select(m=>m.MonthTitle).FirstOrDefault(),
                                Branch = db.Branches.Where(b=>b.Branch1==s.Branch).Select(b=>b.BranchDsc).FirstOrDefault(),
                                Year = s.Year,
                                EmpId = s.EmpId,

                                Mnt = s.Mnt,
                            }).ToList();

                            var Employee = Modle.Where(m => m.Acnt == Smodel.b2 && m.NationCode == Smodel.e1).FirstOrDefault();
                            if (null == Employee)
                            {
                                return View();
                            }
                            Session["Login"] = true;

                            Session["e1"] = Employee.NationCode;
                            var EmployeeInfo = Modle.Where(m => m.Acnt == Smodel.b2 && m.NationCode == Smodel.e1).ToList();
                            ViewBag.EmployeeInfo = EmployeeInfo;
                            log.Time = DateTime.Now.ToShortTimeString();
                            log.Date = utility.PertionDate.Today();
                            log.NationCode = Smodel.e1;
                            log.Acnt = Smodel.b2;
                            log.Type = "ورود";
                            db.Logs.Add(log);
                            db.SaveChanges();
                            Session["Login"] = Employee.Acnt;
                            return RedirectToAction("Print", new { id = Employee.Acnt, e1 = Employee.NationCode });

                        }
                        catch (Exception e)
                        {

                            throw;
                        }
                    }
                }
                ViewBag.Message = "موردی یافت نشد ،اطلاعات وارد شده صحیح نمیباشد.";

            }
            return View();
        }

        public ActionResult Print(int? YearId, int? MonthId, string id = "", string e1 = "")
        {
            ViewBag.MessageMonthNull = null;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(e1))
            {
                return RedirectToAction("search");
            }
            var jjj = TempData["ispdf"];

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

            var EmployeeList = db.EmpPayWagAndEmpInfoByDateVs.Where(e => e.NationCode ==e1).ToList();
            var Modle = EmployeeList.Select(s => new EmpVm()
            {
                Acnt = s.ActiveBank == 1 ? s.Acnt : s.Acnt2,
                FullName = s.Name +" "+s.Fmly  ,
                Fthr = s.Fthr,
                CrnGrp = s.CrnGrp,
                CrnExtGrop=s.CrnExtGrop,
                DedCodTit = s.DedCodTit,
                DedVal = s.DedVal,
                PayCodTit = s.PayCodTit,
                PayVal = s.PayVal,
                ExtCodTit = s.ExtCodTit,
                ExtVal = s.ExtVal,
                NationCode = s.NationCode,
                InsId = s.InsId,
                Branch = db.Branches.Where(b => b.Branch1 == s.Branch).Select(b => b.BranchDsc).FirstOrDefault(),
                Year=s.Year,
                Mnt=s.Mnt,
                EmpId=s.EmpId

            }).ToList();

            var Employee = Modle.Where(m => m.Acnt ==id ).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt).FirstOrDefault();
            var lastM = Convert.ToString(Employee.Mnt);
            var lastY = Convert.ToString(Employee.Year);
            var LastYy = db.Years.Where(y => y.YearTitle == lastY).FirstOrDefault();
            var LastMm = db.Months.Where(y => y.Caption == lastM).FirstOrDefault();
            var Em =  Modle.Where(m => m.Acnt == id && m.NationCode == e1).OrderByDescending(d => d.Year).ThenByDescending(d => d.Mnt).AsQueryable();

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
                    return View(Em.ToList());
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
                var Mnt =Convert.ToString( Employee.Mnt);
               
                ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();
                return View(Em.ToList());
            }
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", yy);

            ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", mm);
           

            ViewBag.e7 = db.Months.Where(m => m.MonthId == mm).Select(m => m.MonthTitle).FirstOrDefault();
            return View(Em.ToList());
        }
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
            var EmployeeList = db.EmpPayWagAndEmpInfoByDateVs.Where(e => e.NationCode == e1).ToList();
            var Modle = EmployeeList.Select(s => new EmpVm()
            {
                Acnt = s.ActiveBank == 1 ? s.Acnt : s.Acnt2,
                FullName = s.Name + " " + s.Fmly,
                Fthr = s.Fthr,
                CrnGrp = s.CrnGrp,
                CrnExtGrop = s.CrnExtGrop,
                DedCodTit = s.DedCodTit,
                DedVal = s.DedVal,
                PayCodTit = s.PayCodTit,
                PayVal = s.PayVal,
                ExtCodTit = s.ExtCodTit,
                ExtVal = s.ExtVal,
                NationCode = s.NationCode,
                InsId = s.InsId,
                Branch = db.Branches.Where(b => b.Branch1 == s.Branch).Select(b => b.BranchDsc).FirstOrDefault(),
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
        public ActionResult GeneratePDF(string c5,string id = "", string e1 = "", string c4 = "" )
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
        public ActionResult _pdf(int? YearId, int? MonthId, string id = "", string e1 = "")
        {
            var Modle = DetailsEm(YearId, MonthId, id, e1);
            return View(Modle.ToList());
        }
        
        // GET: DWHEmpPayWagNews/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpPayWagAndEmpInfoByDateV empPayWagAndEmpInfoByDateV = db.EmpPayWagAndEmpInfoByDateVs.Find(id);
            if (empPayWagAndEmpInfoByDateV == null)
            {
                return HttpNotFound();
            }
            return View(empPayWagAndEmpInfoByDateV);
        }

        // GET: DWHEmpPayWagNews/Create
       

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
