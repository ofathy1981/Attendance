using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attendance.Models;
using System.Data.SqlClient;

namespace Attendance.Controllers
{
    public class delayController : Controller
    {
        private DelayEntities db = new DelayEntities();

        //
        // GET: /delay/
                        [Authorize()]

        public ActionResult Index()
        {
            return View(db.DELAYs.ToList());
        }
                        [Authorize()]

        public ActionResult searchdelay()
        {
            return View();
        }
                        public ActionResult notfound()
                        {
                            return View();
                        }

        //**************************************************************************************************************************************
                        [Authorize()]

        public ActionResult delay(string the_input_date,string dept)
        {
            Session["date1"] = the_input_date;

            if (the_input_date == "")
            {
                return View("notfound");


            }
      
            SqlParameter the_input_date11 = new SqlParameter("the_input_date", the_input_date);
            SqlParameter deptname = new SqlParameter("dept", dept);


            object[] parameters = new object[] { the_input_date11, deptname };


            using (var context = new DelayEntities())
            {
                var data = context.DELAYs.SqlQuery("[dbo].[delay_count] @the_input_date,@dept", parameters);


                return View("Index", data.ToList());

            }
        }
        //**************************************************************************************************************************************
        // GET: /delay/Details/5
                        [Authorize()]

        public ActionResult Details(int id = 0)
        {
            DELAY delay = db.DELAYs.Find(id);
            if (delay == null)
            {
                return HttpNotFound();
            }
            return View(delay);
        }

        //
        // GET: /delay/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /delay/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DELAY delay)
        {
            if (ModelState.IsValid)
            {
                db.DELAYs.Add(delay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(delay);
        }

        //
        // GET: /delay/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DELAY delay = db.DELAYs.Find(id);
            if (delay == null)
            {
                return HttpNotFound();
            }
            return View(delay);
        }

        //
        // POST: /delay/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DELAY delay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(delay);
        }

        //
        // GET: /delay/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DELAY delay = db.DELAYs.Find(id);
            if (delay == null)
            {
                return HttpNotFound();
            }
            return View(delay);
        }

        //
        // POST: /delay/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DELAY delay = db.DELAYs.Find(id);
            db.DELAYs.Remove(delay);
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