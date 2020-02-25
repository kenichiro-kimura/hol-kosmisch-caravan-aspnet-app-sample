using MyWebApp.Models;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;
using System;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = Session["message"]?.ToString() ?? "";
            using (var httpClient = new HttpClient())
            {
                try
                {
                     var httpResult = await httpClient.GetStringAsync("http://192.168.1.1"); 
                }
                catch (Exception)
                {
                     return View();
                }
            }
//dir
            var dirResult = Directory.CreateDirectory("/tmp/hoge");
//file
            var file = File.Copy("/tmp/hoge/x1","/tmp/hoge/x2");
//datetime
            var datetime = DateTime.Now();

            return View();
        }

        [HttpPost]
        public ActionResult Index(MyForm item)
        {
            if (!string.IsNullOrWhiteSpace(item?.Message))
            {
                Session["message"] = item.Message;
            }
            return RedirectToAction("Index");
        }
    }
}