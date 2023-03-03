using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attendance.Models;


namespace Attendance.Controllers
{
    public class AttendanceController : Controller
    {
        private ZKAccessEntities2 db = new ZKAccessEntities2();

        //
   //     public ActionResult absence(string the_input_date)
  //      {
   //         using (var context = new ZKAccessEntities2())
     //       {
      //          var data = context.absence.SqlQuery("[dbo].[absence]@the_input_date", new SqlParameter("the_input_date", the_input_date));
       //         return View("Index2", data.ToList());

         //   }
      //  }
 


        // GET: /Attendance/
                [Authorize()]

        public ActionResult Index()
        {
            return View(db.attendancevs.ToList());
        }
           public ActionResult Index2()
        {
            return View(db.attendancevs.ToList());
        }
           public ActionResult Index3()
           {
               return View(db.attendancevs.ToList());
           }



        //---------------------
           public ActionResult Index4()
           {
               return View(db.attendancevs.ToList());
           }
        //search 1
                        [Authorize()]

        public ActionResult search()
        {

            return View();
        }
                        [Authorize()]

        public ActionResult search1(string employeecode1, string employeecode12)
        {
            Session["employeecode1"] = employeecode1;
            var test1 = db.attendancevs.Where(t => t.atttime.Contains(employeecode1) && t.DEPTNAME.Contains(employeecode12));

            return View("Index2", test1.ToList());
        }
        //
        //search 2
                        [Authorize()]

        public ActionResult search2()
        {

            return View();
        }

        public ActionResult search22(string employeecode, string employeecode2)
        {
            Session["employeecode"] = employeecode;
            var test1 = db.attendancevs.Where(t => t.atttime.StartsWith(employeecode) && t.Badgenumber.StartsWith(employeecode2));

            return View("Index", test1.ToList());
        }
        //
        //search 3
                        [Authorize()]

        public ActionResult search3()
        {

            return View();
        }

        //------------------------------------------------------------------------------------

                        public ActionResult searchall()
                        {

                            return View();
                        }

                        public ActionResult allattendance(string attenddate)
                        {
                            Session["attenddate"] = attenddate;
                            var test1 = db.attendancevs.Where(t => t.atttime.StartsWith(attenddate));

                            return View("Index4", test1.ToList());
                        }
        
        
        
        //-----------------------------------------------------------------------------------



 




                        [Authorize()]

        public ActionResult search33(string employeecode3, string employeecode32)
        {
            Session["employeecode3"] = employeecode3;    
            var test1 = db.attendancevs.Where(t => t.atttime.StartsWith(employeecode3) && t.device_name.Contains(employeecode32));

            return View("Index3", test1.ToList());
        }
        //
        // GET: /Attendance/Details/5
                        [Authorize()]

        public ActionResult Details(string id = null)
        {
            attendancev attendancev = db.attendancevs.Find(id);
            if (attendancev == null)
            {
                return HttpNotFound();
            }
            return View(attendancev);
        }

        //
        // GET: /Attendance/Create
                        [Authorize()]

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Attendance/Create
                        [Authorize()]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(attendancev attendancev)
        {
            if (ModelState.IsValid)
            {
                db.attendancevs.Add(attendancev);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendancev);
        }

        //
        // GET: /Attendance/Edit/5

        public ActionResult Edit(string id = null)
        {
            attendancev attendancev = db.attendancevs.Find(id);
            if (attendancev == null)
            {
                return HttpNotFound();
            }
            return View(attendancev);
        }

        //
        // POST: /Attendance/Edit/5
                        [Authorize()]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(attendancev attendancev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendancev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendancev);
        }

        //
        // GET: /Attendance/Delete/5
                        [Authorize()]

        public ActionResult Delete(string id = null)
        {
            attendancev attendancev = db.attendancevs.Find(id);
            if (attendancev == null)
            {
                return HttpNotFound();
            }
            return View(attendancev);
        }

        //
        // POST: /Attendance/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            attendancev attendancev = db.attendancevs.Find(id);
            db.attendancevs.Remove(attendancev);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public object employeecode1 { get; set; }
    }
}