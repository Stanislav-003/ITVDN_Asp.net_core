using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace _001_SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string lessonFilePath = "01. Вступ. Шаблон MVC. Middleware_8.0.zip";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DownloadLesson()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", lessonFilePath);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            return PhysicalFile(filePath, "application/zip");
        }
    }
}
