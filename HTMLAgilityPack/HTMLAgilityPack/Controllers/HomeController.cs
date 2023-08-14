using HTMLAgilityPack.Models;
using Microsoft.AspNetCore.Mvc;
using ReadHTMLClassLibrary;
using System.Diagnostics;

namespace HTMLAgilityPack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.result = ReadHTML.SendList("https://lipsum.com/","//h2");
            return View();
        }
    }
}