using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW3.Models;
using System.IO;

namespace HW3.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            //gets all the files in this location that we uploaded
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Images"));

            //lists the files as modal
            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {

                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
            
        }

        //in the other view get everything in the folder foreach 
        public ActionResult Delete(string filename)
        {
            ViewBag.File = filename;
            var path = Path.Combine(Server.MapPath("~/Media/Images/"), filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);

            }
            else
            {
                return HttpNotFound();
            }
            //refreshes the page and goes back to the action
            return RedirectToAction("Index");

        }

        //these are linked to the index action link
        public FileResult Download(string fileName) // Why fileName and not FileName????
                                                    // Because of using.
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Images/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream", fileName);
        }
    }
}