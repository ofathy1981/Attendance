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
    public class absentController : Controller
    {
        private ZKAccessEntitiesforabsence3 db = new ZKAccessEntitiesforabsence3();

        //
        // GET: /absent/
        [HttpPost]
        [Authorize()]

        public ActionResult Index()
        {
            ViewBag.date1 = Session["date1"];
            ViewBag.date2 = Session["date2"];


            return View(db.absencevs.ToList());
        }
                [Authorize()]

        public ActionResult searchabsence()
        {
            return View();
        }
        //

                public ActionResult notfound()
                {
                    return View();
                }
        [HttpPost]
        [Authorize()]

        public ActionResult absence(string the_input_date1, string the_input_date2,string dept)
        {
         
                Session["date1"] = the_input_date1;
                Session["date2"] = the_input_date2;

   if (the_input_date1 == "" || the_input_date2 == "")
            {
                return View("notfound");


            }
            SqlParameter the_input_date11 = new SqlParameter("the_input_date1", the_input_date1);
            SqlParameter the_input_date22 = new SqlParameter("the_input_date2", the_input_date2);
            SqlParameter deptname = new SqlParameter("dept", dept);



            object[] parameters = new object[] { the_input_date11, the_input_date22,deptname };


            using (var context = new ZKAccessEntitiesforabsence3())
            {
                var data = context.absencevs.SqlQuery("[dbo].[absence] @the_input_date1, @the_input_date2,@dept", parameters);


                return View("Index", data.ToList());

            }
        }

        // GET: /absent/Details/5

        public ActionResult Details(string id = null)
        {
            absencev absencev = db.absencevs.Find(id);
            if (absencev == null)
            {
                return HttpNotFound();
            }
            return View(absencev);
        }

        //
        // GET: /absent/Create
                [Authorize(Roles = "admin")]

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /absent/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(absencev absencev)
        {
            if (ModelState.IsValid)
            {
                db.absencevs.Add(absencev);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(absencev);
        }

        //
        // GET: /absent/Edit/5
                [Authorize(Roles = "admin")]

        public ActionResult Edit(string id = null)
        {
            absencev absencev = db.absencevs.Find(id);
            if (absencev == null)
            {
                return HttpNotFound();
            }
            return View(absencev);
        }

        //
        // POST: /absent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(absencev absencev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(absencev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(absencev);
        }

        //
        // GET: /absent/Delete/5
                [Authorize(Roles = "admin")]

        public ActionResult Delete(string id = null)
        {
            absencev absencev = db.absencevs.Find(id);
            if (absencev == null)
            {
                return HttpNotFound();
            }
            return View(absencev);
        }

        //
        // POST: /absent/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            absencev absencev = db.absencevs.Find(id);
            db.absencevs.Remove(absencev);
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