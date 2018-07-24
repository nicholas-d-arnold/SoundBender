using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCollabWebApp.Models;

namespace MusicCollabWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult UploadFile()
        {
            ViewData["Message"] = "Upload an audio file here.";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadFileModel model)
        {
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/audiofiles",
                        model.File.FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.File.CopyToAsync(fileStream);
            }
            return View("Index");
        }
        public IActionResult RecordFile()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RecordFile(UploadFileModel model)
        {
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/audiofiles",
                        model.File.FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.File.CopyToAsync(fileStream);
            }
            return Json(Url.Action("Index", "Home"));
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
