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
    public class dailyreportController : Controller
    {
        private AttLoginEntities db = new AttLoginEntities();

        //
        // GET: /dailyreport/

        public ActionResult Index()
        {
            return View(db.DailyAttendanceReports.ToList());
        }

        //
        [Authorize()]

        public ActionResult searchatt(string employeecode1, string employeecode12)
        {
            Session["entereddate"] = employeecode1;
            Session["ssector"] = employeecode12;

            var test1 = db.DailyAttendanceReports.Where((t =>( t.thedate1.Contains(employeecode1) || t.thedate2.Contains(employeecode1)) && t.DEPTNAME.Contains(employeecode12)));

            return View("Index", test1.ToList());
        }
        // GET: /dailyreport/Details/5
        //
        [Authorize()]

        public ActionResult search()
        {

            return View();
        }
        //

        public ActionResult Details(long id = 0)
        {
            DailyAttendanceReport dailyattendancereport = db.DailyAttendanceReports.Find(id);
            if (dailyattendancereport == null)
            {
                return HttpNotFound();
            }
            return View(dailyattendancereport);
        }

        //
        // GET: /dailyreport/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /dailyreport/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DailyAttendanceReport dailyattendancereport)
        {
            if (ModelState.IsValid)
            {
                db.DailyAttendanceReports.Add(dailyattendancereport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dailyattendancereport);
        }

        //
        // GET: /dailyreport/Edit/5

        public ActionResult Edit(long id = 0)
        {
            DailyAttendanceReport dailyattendancereport = db.DailyAttendanceReports.Find(id);
            if (dailyattendancereport == null)
            {
                return HttpNotFound();
            }
            return View(dailyattendancereport);
        }

        //
        // POST: /dailyreport/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DailyAttendanceReport dailyattendancereport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyattendancereport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dailyattendancereport);
        }

        //
        // GET: /dailyreport/Delete/5

        public ActionResult Delete(long id = 0)
        {
            DailyAttendanceReport dailyattendancereport = db.DailyAttendanceReports.Find(id);
            if (dailyattendancereport == null)
            {
                return HttpNotFound();
            }
            return View(dailyattendancereport);
        }

        //
        // POST: /dailyreport/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DailyAttendanceReport dailyattendancereport = db.DailyAttendanceReports.Find(id);
            db.DailyAttendanceReports.Remove(dailyattendancereport);
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