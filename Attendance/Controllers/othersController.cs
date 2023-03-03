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
    public class othersController : Controller
    {
        private othrZKAccessEntities4 db = new othrZKAccessEntities4();

        //
        // GET: /others/

        public ActionResult Index()
        {
            return View(db.otherts.ToList());
        }
        //**************************************************************************

        public ActionResult searchothers()
        {
            return View();
        }
        public ActionResult othrs(string the_inputdate)
        {

            Session["thedate1"] = the_inputdate;



            SqlParameter the_input_date11 = new SqlParameter("the_inputdate", the_inputdate);



            object[] parameters = new object[] { the_input_date11};


            using (var context = new othrZKAccessEntities4())
            {
                var data = context.otherts.SqlQuery("[dbo].[getothers] @the_inputdate", parameters);


                return View("Index", data.ToList());

            }
        }

        //**************************************************************************
        //
        // GET: /others/Details/5

        public ActionResult Details(long id = 0)
        {
            othert othert = db.otherts.Find(id);
            if (othert == null)
            {
                return HttpNotFound();
            }
            return View(othert);
        }

        //
        // GET: /others/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /others/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(othert othert)
        {
            if (ModelState.IsValid)
            {
                db.otherts.Add(othert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(othert);
        }

        //
        // GET: /others/Edit/5

        public ActionResult Edit(long id = 0)
        {
            othert othert = db.otherts.Find(id);
            if (othert == null)
            {
                return HttpNotFound();
            }
            return View(othert);
        }

        //
        // POST: /others/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(othert othert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(othert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(othert);
        }

        //
        // GET: /others/Delete/5

        public ActionResult Delete(long id = 0)
        {
            othert othert = db.otherts.Find(id);
            if (othert == null)
            {
                return HttpNotFound();
            }
            return View(othert);
        }

        //
        // POST: /others/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            othert othert = db.otherts.Find(id);
            db.otherts.Remove(othert);
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