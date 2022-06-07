using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HW3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            if (files != null && files.ContentLength>0)
            {
                ViewBag.Location = Request["radioBtn"];

                var fileName = Path.GetFileName(files.FileName);

                //gets all the locations until media folder gets the radio button
                var path = Path.Combine(Server.MapPath("~/Media/"),ViewBag.location,fileName);
               

                files.SaveAs(path);
            }
            ViewBag.Message = "your aplication description page ";
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        
    }
}