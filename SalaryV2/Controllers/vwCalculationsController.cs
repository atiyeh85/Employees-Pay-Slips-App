using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalaryV2.Models;
using SalaryV2.Models.Corporate;

namespace SalaryV2.Controllers
{
    public class vwCalculationsController : Controller
    {
        private CorporateDB CorDB = new CorporateDB();
        private Storedb db = new Storedb();
        private List<Models.Corporate.vwCalculation> _Employees;

        // GET: vwCalculations
        public ActionResult Index()
        {
            var List = CorDB.vwCalculations.Take(100);
            return View(List);
        }
        [AllowAnonymous]
        public ActionResult Print(int? YearId, int? MonthId, int? id, string e1 = "")
        {
            var EmpProfile = CorDB.vwPersonnels.Where(e => e.PartyRef == id).OrderByDescending(s => s.PersonnelId).FirstOrDefault();
            var EmployeeList = CorDB.vwCalculations.Where(e => e.DLCode == EmpProfile.DLCode && e.Value != 0).OrderByDescending(d => d.Year).ThenByDescending(d => d.Month).ToList();
            var List = CorDB.vwShreds.Where(s => s.DLCode == EmpProfile.DLCode && s.RemainedAmount>0).ToList();


            //var EmpProfile = CorDB.vwPersonnels.Where(e => e.AccountNo == id & e.IdentificationCode == e1).OrderByDescending(s=>s.PersonnelId).FirstOrDefault();
            //var EmployeeList = CorDB.vwCalculations.Where(e => e.DLCode == EmpProfile.DLCode && e.Value != 0).OrderByDescending(d => d.Year).ThenByDescending(d => d.Month).ToList();
            //var List = CorDB.vwShreds.Where(s => s.DLCode == EmpProfile.DLCode).ToList();



            var EmpSorted = EmployeeList.FirstOrDefault();
            var EmpQuerable = EmployeeList.AsQueryable();

            ArrayList Karkerd = new ArrayList();
            ArrayList Add = new ArrayList();
            ArrayList Sub = new ArrayList();
            List<LoanVm> LoanA = new List<LoanVm>();
            ArrayList Total = new ArrayList();
            List<Contract> ContractA = new List<Contract>();
            Contract co = new Contract();

            var YearNow = utility.PertionDate.CurrentYear();
            var MonthNow = utility.PertionDate.CurrentMonth();
            var YNow = db.Years.Where(y => y.YearTitle == YearNow).FirstOrDefault();
            var MNow = db.Months.Where(y => y.Caption == MonthNow).FirstOrDefault();
            var YNowid = YNow.YearId;
            var MNowid = MNow.MonthId;

            decimal TotalAmount = 0;
            var Count = 0;
            var PerMonth = 0;
            var Remind = 0;
            var lastM = Convert.ToString(EmpSorted.Month);
            var lastY = Convert.ToString(EmpSorted.Year);

            var LastYy = db.Years.Where(y => y.YearTitle == lastY).FirstOrDefault();
            var LastMm = db.Months.Where(y => y.Caption == lastM).FirstOrDefault();

            var YearTitle = Convert.ToInt16(LastYy.YearTitle);
            var Caption = Convert.ToByte(LastMm.Caption);
            if (YearId.HasValue && YearId.Value != 0 && MonthId.HasValue && MonthId.Value != 0)
            {

                var Year = db.Years.Where(y => y.YearId == YearId).FirstOrDefault();
                var Month = db.Months.Where(y => y.MonthId == MonthId).FirstOrDefault();
                var mo =int.Parse(Month.Caption);
                var yearInt = int.Parse(Year.YearTitle);
                EmpQuerable = EmpQuerable.Where(e => e.Year == yearInt && e.Month == mo && e.Value != 0);
                EmpSorted = EmpQuerable.OrderByDescending(d => d.Year).ThenByDescending(d => d.Month).FirstOrDefault();

               
                if (EmpQuerable.Count() <= 0)
                {
                    ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", Year.YearId);
                    ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", Month.MonthId);
                    ViewBag.MessageMonthNull = "اطلاعاتی در مورد ماه وارد شده در سیستم موجود نمی باشد.";
                    ViewBag.EmployeeName = EmpSorted;
                    ViewBag.EmpProfile = EmpProfile;
                    ViewBag.e7 = db.Months.Where(m => m.MonthId == Month.MonthId).Select(m => m.MonthTitle).FirstOrDefault();
                    return View();
                }
                foreach (var i in EmpQuerable.Where(m => m.ElementClass == 1 & m.ElementType != 6))
                {
                    Karkerd.Add(i);
                }
                foreach (var j in EmpQuerable.Where(m => m.ElementClass == 3))
                {
                    Sub.Add(j);
                }
                foreach (var k in EmpQuerable.Where(m => m.ElementClass == 2))
                {
                    Add.Add(k);
                }
                foreach (var ite in List)
                {
                    List<vwShredItem> ShredItem = new List<vwShredItem>();
                    var Lo = new LoanVm();
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = new DateTime(Convert.ToInt32(Year.YearTitle), Convert.ToInt32(Month.Caption), 1, pc);
                    var cMo = dt.Month;
                    var cYe = dt.Year;
                    var II = CorDB.vwShredItems.Where(s => s.ShredRef == ite.ShredID).ToList();
                    var Shred = II.Where(c => c.PaymentDate != null).OrderByDescending(c => c.PaymentDate).ToList();
                    foreach (var item in Shred)
                    {
                        DateTime thisDate = Convert.ToDateTime(item.PaymentDate.ToString());
                        var Mo = thisDate.Month;
                        var ye = thisDate.Year;
                        var da = thisDate.Day;
                        if (ye==cYe && Mo==cMo)
                        {
                            ShredItem.Add(item);
                            continue;
                        }
                    }
                    
                    var Coun = 0;
                    var ShItem = ShredItem.FirstOrDefault();
                    if (ShItem != null)
                    {
                        TotalAmount = ite.TotalAmount;
                        Count = CorDB.vwShredItems.Count(s => s.ShredRef == ite.ShredID);

                        PerMonth = (int)ShItem.Amount;
                        var Rem = ShItem.RowNumber * PerMonth;
                        Remind = (int)TotalAmount - Rem;
                        Lo.RemainedAmount = Remind;
                        Lo.Target = ite.Target;
                        Lo.PerMonth = PerMonth;

                        LoanA.Add(Lo);
                        ViewBag.loan = LoanA;

                    }
                }

                var Sanavat = EmpQuerable.Select(s => s.ElementRef == -1517).FirstOrDefault();
                var Mozd = EmpQuerable.Where(s => s.ElementRef == 2048).FirstOrDefault();
                
                if (Sanavat != false)
                {
                    Add.Add(Sanavat);
                }
                var Tax = EmpQuerable.Where(s => s.ElementRef == -390).FirstOrDefault();
                var Insurance = EmpQuerable.Where(s => s.ElementRef == -150).FirstOrDefault();
                ViewBag.Pay = EmpQuerable.Where(s => s.ElementRef == -270).Select(s => s.Value).FirstOrDefault();//خالص پرداختنی
                ViewBag.TotalSalary = EmpQuerable.Where(s => s.ElementRef == -210).Select(s => s.Value).FirstOrDefault();//مجموع حقوق و مزایا
                ViewBag.Remined = EmpQuerable.Where(s => s.ElementRef == -420).Select(s => s.Value).FirstOrDefault();//مانده مرخصی
                Sub.Add(Tax);
                Sub.Add(Insurance);
                var Conid = EmployeeList.FirstOrDefault();
                var ContractInfo = CorDB.vwContracts.Where(s => s.ContractId == Conid.ContractRef).FirstOrDefault();

                co.ContractRef = ContractInfo.ContractId;
                co.CostCenterTitle = ContractInfo.CostCenterTitle;
                ContractA.Add(co);
                ViewBag.ContractA = ContractA;

                ViewBag.b2 = id;
                ViewBag.e1 = e1;
                var Mnt = Convert.ToString(Month.Caption);
                ViewBag.Add = Add;
                ViewBag.Sub = Sub;
                ViewBag.Total = Total;


                ViewBag.Add = Add;
                ViewBag.Sub = Sub;
                ViewBag.Total = Total;

                ViewBag.Karkerd = Karkerd;
                ViewBag.Loan = LoanA;
                ViewBag.EmpProfile = EmpProfile; ViewBag.EmployeeName = EmpSorted;
                TempData["PrintDetail"] = EmpQuerable.ToList();
                ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();
                ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", Year.YearId);
                ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", Month.MonthId);
                return View(EmpQuerable.ToList());
            }
            else
            {
                EmpQuerable = EmpQuerable.Where(d => d.Year == YearTitle && d.Month == Caption);
                foreach (var i in EmpQuerable.Where(m => m.ElementClass == 1 & m.ElementType != 6))
                {
                    Karkerd.Add(i);
                }
                foreach (var j in EmpQuerable.Where(m => m.ElementClass == 3))
                {
                    Sub.Add(j);
                }
                foreach (var k in EmpQuerable.Where(m => m.ElementClass == 2))
                {
                    Add.Add(k);
                }
                foreach (var ite in List)
                {
                    List<vwShredItem> ShredItem = new List<vwShredItem>();
                    var Lo = new LoanVm();

                        var II = CorDB.vwShredItems.Where(s => s.ShredRef == ite.ShredID).ToList();
                    var III = II.Where(c => c.PaymentDate != null).ToList();
                        var ShredItemID = II.Where(c => c.PaymentDate != null).OrderByDescending(c=>c.PaymentDate).Max(c=>c.ShredItemID);
                        var ListPay = II.Where(c => c.ShredItemID == ShredItemID).OrderByDescending(c => c.PaymentDate).FirstOrDefault();
                        var Coun = 0;
                        DateTime thisDate = Convert.ToDateTime(ListPay.PaymentDate.ToString());
                        var Mo = thisDate.Month;
                        var ye = thisDate.Year;
                        var da = thisDate.Day;
                        PersianCalendar pc = new PersianCalendar();
                        DateTime dt = new DateTime(EmpSorted.Year, EmpSorted.Month,1, pc);
                        //DateTime dt2 = new DateTime(EmpSorted.Year, EmpSorted.Month,31, pc);
                        var cMo = dt.Month;
                        var cYe = dt.Year;

                        //var cMoo = dt2.Month;
                        //var cYee = dt2.Year;
                        if (cMo == Mo && cYe == ye)
                        {
                            ShredItem.Add(ListPay);
                        }

                    if (ShredItem == null)
                    {

                    }
                    var ShItem = ShredItem.FirstOrDefault();
                    if (ShItem != null)
                    {
                        TotalAmount = ite.TotalAmount;
                        Count = CorDB.vwShredItems.Count(s => s.ShredRef == ite.ShredID);

                        PerMonth = (int)ShItem.Amount;
                        var Rem = ShItem.RowNumber * PerMonth;
                        Remind = (int)TotalAmount - Rem;
                        Lo.RemainedAmount = Remind;
                        Lo.Target = ite.Target;
                        Lo.PerMonth = PerMonth;

                        LoanA.Add(Lo);
                        ViewBag.loan = LoanA;

                    }
                }
                    
                    

                var Sanavat = EmpQuerable.Select(s => s.ElementRef == -1517).FirstOrDefault();
                    var Mozd = EmpQuerable.Where(s => s.ElementRef == 2048).FirstOrDefault();
                    //if (Mozd!=0)
                    //{
                    //    Add.Add(Mozd);

                    //}
                    if (Sanavat != false)
                    {
                        Add.Add(Sanavat);
                    }

                    var Tax = EmpQuerable.Where(s => s.ElementRef == -390).FirstOrDefault();
                    var Insurance = EmpQuerable.Where(s => s.ElementRef == -150).FirstOrDefault();
                    ViewBag.Pay = EmpQuerable.Where(s => s.ElementRef == -270).Select(s => s.Value).FirstOrDefault();//خالص پرداختنی
                    ViewBag.TotalSalary = EmpQuerable.Where(s => s.ElementRef == -210).Select(s => s.Value).FirstOrDefault();//مجموع حقوق و مزایا
                    ViewBag.Remined = EmpQuerable.Where(s => s.ElementRef == -420).Select(s => s.Value).FirstOrDefault();//مانده مرخصی
                    Sub.Add(Tax);
                    Sub.Add(Insurance);


                    var Conid = EmployeeList.FirstOrDefault();
                    var ContractInfo = CorDB.vwContracts.Where(s => s.ContractId == Conid.ContractRef).FirstOrDefault();

                    co.ContractRef = ContractInfo.ContractId;
                    co.CostCenterTitle = ContractInfo.CostCenterTitle;
                    ContractA.Add(co);
                    ViewBag.ContractA = ContractA;

                    ViewBag.b2 = id;
                    ViewBag.e1 = e1;
                    var Mnt = Convert.ToString(EmpSorted.Month);
                    ViewBag.Add = Add;
                    ViewBag.Sub = Sub;
                    ViewBag.Total = Total;
                    ViewBag.Add = Add;
                    ViewBag.Sub = Sub;
                    ViewBag.Total = Total;
                    ViewBag.Karkerd = Karkerd;
                    ViewBag.Loan = LoanA;
                    ViewBag.EmpProfile = EmpProfile; ViewBag.EmployeeName = EmpSorted;
                    TempData["PrintDetail"] = EmpQuerable.ToList();
                    ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();
                    ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", LastYy.YearId);
                    ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", LastMm.MonthId);
                    return View(EmpQuerable.ToList());
                ViewBag.EmpProfile = EmpProfile;
            }

        ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", YNowid);
            ViewBag.MonthId = new SelectList(db.Months, "MonthId", "MonthTitle", MNowid);
            ViewBag.e7 = db.Months.Where(m => m.MonthId == MNowid).Select(m => m.MonthTitle).FirstOrDefault();
            return View(EmpQuerable.ToList());
        }
        [AllowAnonymous]
        public ActionResult GeneratePDF( string c5, string id = "", string e1 = "", string c4 = "")
        {
            var jj = TempData["PrintDetail"];
            Session["PrintDetail"] = TempData["PrintDetail"];
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

            //var createpdf = new Rotativa.ViewAsPdf("_pdf",new { vm=jj});
            Session["Login"] = id.ToString();
            var createpdf = new Rotativa.ActionAsPdf("_pdf", new { id = id, YearId = yy, MonthId = mm, e1 = e1, ispdf = true });
            return createpdf;

        }
        [AllowAnonymous]
        public ActionResult _pdf(List<vwCalculation> vm, int? YearId, int? MonthId, string id = "", string e1 = "")
        {
            var Modle = DetailsEm(YearId, MonthId, id, e1);

            return View(Modle.ToList());
        }
        [AllowAnonymous]
        public List<vwCalculation> DetailsEm(int? YearId, int? MonthId, string id = "", string e1 = "")
        {
            var EmpProfile = CorDB.vwPersonnels.Where(e => e.AccountNo == id & e.IdentificationCode == e1).OrderByDescending(s=>s.PersonnelId).FirstOrDefault();
            var EmployeeList = CorDB.vwCalculations.Where(e => e.DLCode == EmpProfile.DLCode && e.Value != 0).OrderByDescending(d => d.Year).ThenByDescending(d => d.Month).ToList();
            var List = CorDB.vwShreds.Where(s => s.DLCode == EmpProfile.DLCode).ToList();

            var EmpSorted = EmployeeList.FirstOrDefault();
            var EmpQuerable = EmployeeList.AsQueryable();

            ArrayList Karkerd = new ArrayList();
            ArrayList Add = new ArrayList();
            ArrayList Sub = new ArrayList();
            List<LoanVm> LoanA = new List<LoanVm>();
            ArrayList Total = new ArrayList();
            List<Contract> ContractA = new List<Contract>();
            Contract co = new Contract();

            var YearNow = utility.PertionDate.CurrentYear();
            var MonthNow = utility.PertionDate.CurrentMonth();
            var YNow = db.Years.Where(y => y.YearTitle == YearNow).FirstOrDefault();
            var MNow = db.Months.Where(y => y.Caption == MonthNow).FirstOrDefault();
            var YNowid = YNow.YearId;
            var MNowid = MNow.MonthId;

            decimal TotalAmount = 0;
            var Count = 0;
            var PerMonth = 0;
            var Remind = 0;
            var lastM = Convert.ToString(EmpSorted.Month);
            var lastY = Convert.ToString(EmpSorted.Year);

            var LastYy = db.Years.Where(y => y.YearTitle == lastY).FirstOrDefault();
            var LastMm = db.Months.Where(y => y.Caption == lastM).FirstOrDefault();

            var YearTitle = Convert.ToInt16(LastYy.YearTitle);
            var Caption = Convert.ToByte(LastMm.Caption);
            if (YearId.HasValue && YearId.Value != 0 && MonthId.HasValue && MonthId.Value != 0)
            {
                var Year = db.Years.Where(y => y.YearId == YearId).FirstOrDefault();
                var Month = db.Months.Where(y => y.MonthId == MonthId).FirstOrDefault();
                var mo = int.Parse(Month.Caption);
                var yearInt = int.Parse(Year.YearTitle);
                EmpQuerable = EmpQuerable.Where(e => e.Year == yearInt && e.Month == mo && e.Value != 0);
                var kk = EmpQuerable.ToList();
                
                foreach (var i in EmpQuerable.Where(m => m.ElementClass == 1 & m.ElementType != 6))
                {
                    Karkerd.Add(i);
                }
                foreach (var j in EmpQuerable.Where(m => m.ElementClass == 3))
                {
                    Sub.Add(j);
                }
                foreach (var k in EmpQuerable.Where(m => m.ElementClass == 2))
                {
                    Add.Add(k);
                }
                foreach (var ite in List)
                {
                    List<vwShredItem> ShredItem = new List<vwShredItem>();
                    var Lo = new LoanVm();
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = new DateTime(Convert.ToInt32(Year.YearTitle), Convert.ToInt32(Month.Caption), 1, pc);
                    var cMo = dt.Month;
                    var cYe = dt.Year;
                    var II = CorDB.vwShredItems.Where(s => s.ShredRef == ite.ShredID).ToList();
                    var Shred = II.Where(c => c.PaymentDate != null).OrderByDescending(c => c.PaymentDate).ToList();
                    foreach (var item in Shred)
                    {
                        DateTime thisDate = Convert.ToDateTime(item.PaymentDate.ToString());
                        var Mo = thisDate.Month;
                        var ye = thisDate.Year;
                        var da = thisDate.Day;
                        if (ye == cYe && Mo == cMo)
                        {
                            ShredItem.Add(item);
                            continue;
                        }
                    }

                    var Coun = 0;
                    var ShItem = ShredItem.FirstOrDefault();
                    if (ShItem != null)
                    {
                        TotalAmount = ite.TotalAmount;
                        Count = CorDB.vwShredItems.Count(s => s.ShredRef == ite.ShredID);

                        PerMonth = (int)ShItem.Amount;
                        var Rem = ShItem.RowNumber * PerMonth;
                        Remind = (int)TotalAmount - Rem;
                        Lo.RemainedAmount = Remind;
                        Lo.Target = ite.Target;
                        Lo.PerMonth = PerMonth;

                        LoanA.Add(Lo);
                        ViewBag.loan = LoanA;

                    }
                }

                var Sanavat = EmpQuerable.Select(s => s.ElementRef == -1517).FirstOrDefault();
                var Mozd = EmpQuerable.Where(s => s.ElementRef == 2048).FirstOrDefault();

                if (Sanavat != false)
                {
                    Add.Add(Sanavat);
                }
                var Tax = EmpQuerable.Where(s => s.ElementRef == -390).FirstOrDefault();
                var Insurance = EmpQuerable.Where(s => s.ElementRef == -150).FirstOrDefault();
                ViewBag.Pay = EmpQuerable.Where(s => s.ElementRef == -270).Select(s => s.Value).FirstOrDefault();//خالص پرداختنی
                ViewBag.TotalSalary = EmpQuerable.Where(s => s.ElementRef == -210).Select(s => s.Value).FirstOrDefault();//مجموع حقوق و مزایا
                ViewBag.Remined = EmpQuerable.Where(s => s.ElementRef == -420).Select(s => s.Value).FirstOrDefault();//مانده مرخصی
                Sub.Add(Tax);
                Sub.Add(Insurance);
                var Conid = EmployeeList.FirstOrDefault();
                var ContractInfo = CorDB.vwContracts.Where(s => s.ContractId == Conid.ContractRef).FirstOrDefault();

                co.ContractRef = ContractInfo.ContractId;
                co.CostCenterTitle = ContractInfo.CostCenterTitle;
                ContractA.Add(co);
                ViewBag.ContractA = ContractA;

                ViewBag.b2 = id;
                ViewBag.e1 = e1;
                var Mnt = Convert.ToString(Month.Caption);
                ViewBag.Add = Add;
                ViewBag.Sub = Sub;
                ViewBag.Total = Total;


                ViewBag.Add = Add;
                ViewBag.Sub = Sub;
                ViewBag.Total = Total;

                ViewBag.Karkerd = Karkerd;
                ViewBag.Loan = LoanA;
                ViewBag.EmpProfile = EmpProfile; ViewBag.EmployeeName = EmpSorted;
                TempData["PrintDetail"] = EmpQuerable.ToList();
                ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();
                ViewBag.YearId = new SelectList(db.Years, "YearId", "YearTitle", Year.YearId);
                ViewBag.MonthId = new SelectList(db.Months.OrderByDescending(m => m.Caption), "MonthId", "MonthTitle", Month.MonthId);
                _Employees = EmpQuerable.ToList();
                if (EmpQuerable != null)
                {

                    ViewBag.EmployeeName = EmpQuerable.FirstOrDefault();
                    ViewBag.EmpProfile = EmpProfile;
                    if (ViewBag.EmployeeName == null)
                    {
                        ViewBag.d3 = /*Employee.d3*/"";
                        ViewBag.b2 = EmpSorted.AccountNo;
                        ViewBag.e1 = EmpProfile.IdentificationCode;
                        ViewBag.a1 = EmpProfile.DLCode;
                        ViewBag.a2 = EmpProfile.FirstName + " " + EmpProfile.LastName;
                        //ViewBag.a3 = Employee.a3;
                        ViewBag.b6 = EmpProfile.FatherName;
                        //ViewBag.a4 = EmpSorted.InsId;
                        ViewBag.d9 = EmpSorted.BranchTitle;
                        ViewBag.e8 = EmpSorted.Year;
                        ViewBag.e7 = db.Months.Where(m => m.Caption == Mnt).Select(m => m.MonthTitle).FirstOrDefault();
                        ViewBag.MessageMonthNull = "اطلاعاتی در مورد ماه وارد شده در سیستم موجود نمی باشد.";
                    }
                }
                else
                {
                   
                }
            }

            return _Employees;
        }



        // GET: vwCalculations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwCalculation vwCalculation = CorDB.vwCalculations.Find(id);
            if (vwCalculation == null)
            {
                return HttpNotFound();
            }
            return View(vwCalculation);
        }

        // GET: vwCalculations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vwCalculations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vwCalculation vwCalculation)
        {
            if (ModelState.IsValid)
            {
                CorDB.vwCalculations.Add(vwCalculation);
                CorDB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vwCalculation);
        }

        // GET: vwCalculations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwCalculation vwCalculation = CorDB.vwCalculations.Find(id);
            if (vwCalculation == null)
            {
                return HttpNotFound();
            }
            return View(vwCalculation);
        }

        // POST: vwCalculations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vwCalculation vwCalculation)
        {
            if (ModelState.IsValid)
            {
                CorDB.Entry(vwCalculation).State = EntityState.Modified;
                CorDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vwCalculation);
        }

        // GET: vwCalculations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwCalculation vwCalculation = CorDB.vwCalculations.Find(id);
            if (vwCalculation == null)
            {
                return HttpNotFound();
            }
            return View(vwCalculation);
        }

        // POST: vwCalculations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vwCalculation vwCalculation = CorDB.vwCalculations.Find(id);
            CorDB.vwCalculations.Remove(vwCalculation);
            CorDB.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                CorDB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
