using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attendance.Models;

namespace Attendance.Controllers
{
    public class cumulativeController : Controller
    {
        private cumulativeent db = new cumulativeent();

        //
        // GET: /cumulative/

        public ActionResult Index()
        {
            return View(db.cumlatives.ToList());
        }



        //************************************************************************************************************************
        public ActionResult searchcumulative()
        {
            
            return View();
        }

        public ActionResult searchcumu(string code1, string code2, string code3)
        {
            Session["code1"] = code1;
            Session["code2"] = code2;
            Session["code3"] = code3;



            var test1 = db.cumlatives.Where(t => (t.DEPTNAME.Contains(code1) && t.theyear.Contains(code2) && t.themonth==code3));

            return View("Index", test1.ToList());
        }


        //************************************************************************************************************************
        //
        // GET: /cumulative/Details/5

        public ActionResult Details(long id = 0)
        {
            cumlative cumlative = db.cumlatives.Find(id);
            if (cumlative == null)
            {
                return HttpNotFound();
            }
            return View(cumlative);
        }

        //
        // GET: /cumulative/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /cumulative/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(cumlative cumlative)
        {
            if (ModelState.IsValid)
            {
                db.cumlatives.Add(cumlative);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cumlative);
        }

        //
        // GET: /cumulative/Edit/5

        public ActionResult Edit(long id = 0)
        {
            cumlative cumlative = db.cumlatives.Find(id);
            if (cumlative == null)
            {
                return HttpNotFound();
            }
            return View(cumlative);
        }

        //
        // POST: /cumulative/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cumlative cumlative)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cumlative).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cumlative);
        }

        //
        // GET: /cumulative/Delete/5

        public ActionResult Delete(long id = 0)
        {
            cumlative cumlative = db.cumlatives.Find(id);
            if (cumlative == null)
            {
                return HttpNotFound();
            }
            return View(cumlative);
        }

        //
        // POST: /cumulative/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            cumlative cumlative = db.cumlatives.Find(id);
            db.cumlatives.Remove(cumlative);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}