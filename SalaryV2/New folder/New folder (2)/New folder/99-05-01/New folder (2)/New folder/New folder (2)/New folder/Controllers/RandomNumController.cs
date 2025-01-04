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
    public class RandomNumController : Controller
    {
        private Storedb db = new Storedb();
        // GET: RandomNum
        public ActionResult Index()
        {
            var List = db.RandomNumbers.OrderByDescending(o => o.EditDate).ThenByDescending(o=>o.EditTime).ToList();
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
        // GET: RandomNum/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: RandomNum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RandomNumber randomNumber)
        {
            if (ModelState.IsValid)
            {
                db.RandomNumbers.Add(randomNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(randomNumber);
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
        public ActionResult Edit( RandomNumber randomNumber)
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
