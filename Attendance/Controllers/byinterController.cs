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
    public class byinterController : Controller
    {
        private AttLoginEntities1 db = new AttLoginEntities1();

        //
        // GET: /byinter/

        public ActionResult Index()
        {
            return View(db.byintervals.ToList());
        }

        //
        // GET: /byinter/Details/5

        public ActionResult Details(long id = 0)
        {
            byinterval byinterval = db.byintervals.Find(id);
            if (byinterval == null)
            {
                return HttpNotFound();
            }
            return View(byinterval);
        }

        //
        // GET: /byinter/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /byinter/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(byinterval byinterval)
        {
            if (ModelState.IsValid)
            {
                db.byintervals.Add(byinterval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(byinterval);
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]

        // GET: /byinter/Edit/5

        public ActionResult Edit(long id = 0)
        {
            byinterval byinterval = db.byintervals.Find(id);
            if (byinterval == null)
            {
                return HttpNotFound();
            }
            return View(byinterval);
        }

        //**************************
        public ActionResult byinterval(string frominputdate, string toinputdate, string empcode)
        {

            Session["frominputdate"] = frominputdate;
            Session["toinputdate"] = toinputdate;
            Session["empcode"] = empcode;



            if (frominputdate == "" || toinputdate == ""||empcode == "")
            {
                return View("notfound");


            }
            SqlParameter frominputdate1 = new SqlParameter("frominputdate", frominputdate);
            SqlParameter toinputdate1 = new SqlParameter("toinputdate", toinputdate);
            SqlParameter empcode1 = new SqlParameter("empcode", empcode);



            object[] parameters = new object[] { frominputdate1, toinputdate1, empcode1 };


            using (var context = new AttLoginEntities1())
            {
                var data = context.byintervals.SqlQuery("[dbo].[getbyinterval] @frominputdate, @toinputdate,@empcode", parameters);


                return View("Index", data.ToList());

            }
        }
        //============================
        public ActionResult byinterval2(string frominputdate, string toinputdate, string empcode)
        {

            Session["frominputdate"] = frominputdate;
            Session["toinputdate"] = toinputdate;
            Session["empcode"] = empcode;



            if (frominputdate == "" || toinputdate == "" || empcode == "")
            {
                return View("notfound");


            }
            SqlParameter frominputdate1 = new SqlParameter("frominputdate", frominputdate);
            SqlParameter toinputdate1 = new SqlParameter("toinputdate", toinputdate);
            SqlParameter empcode1 = new SqlParameter("empcode", empcode);



            object[] parameters = new object[] { frominputdate1, toinputdate1, empcode1 };


            using (var context = new AttLoginEntities1())
            {
                var data = context.byintervals.SqlQuery("[dbo].[getbyinterval2] @frominputdate, @toinputdate,@empcode", parameters);


                return View("Index2", data.ToList());

            }
        }
        // POST: /byinter/Edit/5
        public ActionResult searchbyinterval()
        {
            return View();
        }

        //----------------------

        public ActionResult searchbyinterval2()
        {
            return View();
        }

        //***************************
        //==================================================================================================================================================================
        public ActionResult searchbyinterval3()
        {
            return View();
        }

        public ActionResult byinterval3(string frominputdate, string toinputdate, string empcode)
        {

            Session["frominputdate"] = frominputdate;
            Session["toinputdate"] = toinputdate;
            Session["empcode"] = empcode;



            if (frominputdate == "" || toinputdate == "" || empcode == "")
            {
                return View("notfound");


            }
            SqlParameter frominputdate1 = new SqlParameter("frominputdate", frominputdate);
            SqlParameter toinputdate1 = new SqlParameter("toinputdate", toinputdate);
            SqlParameter empcode1 = new SqlParameter("empcode", empcode);



            object[] parameters = new object[] { frominputdate1, toinputdate1, empcode1 };


            using (var context = new AttLoginEntities1())
            {
                var data = context.byintervals.SqlQuery("[dbo].[getbyinterval2] @frominputdate, @toinputdate,@empcode", parameters);


                return View("Index3", data.ToList());

            }


        }
        //====================================================================================================================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(byinterval byinterval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(byinterval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(byinterval);
        }

        //
        // GET: /byinter/Delete/5

        public ActionResult Delete(long id = 0)
        {
            byinterval byinterval = db.byintervals.Find(id);
            if (byinterval == null)
            {
                return HttpNotFound();
            }
            return View(byinterval);
        }

        //
        // POST: /byinter/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            byinterval byinterval = db.byintervals.Find(id);
            db.byintervals.Remove(byinterval);
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