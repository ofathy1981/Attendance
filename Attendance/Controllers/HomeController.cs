using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net.NetworkInformation; //Include this

namespace Attendance.Controllers
{
    public class HomeController : Controller
    {
       [Authorize()]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            Session["userip"] = HttpContext.Server;
           //=============================================

            string[] devs = {
                                
                "192.168.62.202",
                     "192.168.62.201",
                     "192.168.63.203",
                     "192.168.63.204",
                     "192.168.64.3",
                     "192.168.64.4",
                     "192.168.65.205",
                     "192.168.67.205",
                     "192.168.105.204",
                     "192.168.69.200",
                     "192.168.70.8",
                     "192.168.68.200",
                     "192.168.71.9"                             
                            
                            
                            
                            
                            
                            };


            string[] devsnames = { 
                                 
                "GARDEN 6",
            "GARDEN 9",
            "MOHANDSEEN 7",
            "MOHANDSEEN 8",
            "FAWALLA 10",
            "FAWALLA 8",
            "KASR ELNILE",
            "CITY BANK",
            "TAWFIKIA",
            "LUXOR AREA",
            "LUXOR INST",
            "ALEX INST",
            "ALEX KASR"        
                                 
                                 
                                 };


            int i = 0;
            string[] success = new string[13];
            string[] failures = new string[13];
            foreach (var dev in devs.Zip(devsnames, Tuple.Create))
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send(dev.Item1, 3000);
                if (reply.Status == IPStatus.Success)
                {
                    success[i] = dev.Item2;
                }
                else
                {
                    failures[i] = dev.Item2;
                }

                i = i + 1;
            }
            ViewBag.successful = success;
            ViewBag.failure = failures;







           //============================================
            return View();
        }
                        [Authorize()]
                public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
                        [Authorize()]

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
