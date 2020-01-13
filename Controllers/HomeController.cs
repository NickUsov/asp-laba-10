using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GoodHandler handler = new GoodHandler();
            
            return View(handler.GetGoods());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Good good)
        {
            if(ModelState.IsValid)
            {
                GoodHandler handler = new GoodHandler();
                handler.Create(good);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            GoodHandler handler = new GoodHandler();
            Good good = handler.GetGoods().Find(g => g.Id == id);
            if(good!=null)
            {
                return View(good);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Good good)
        {
            if (ModelState.IsValid)
            {
                GoodHandler handler = new GoodHandler();
                handler.Update(good);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            GoodHandler handler = new GoodHandler();
            Good good = handler.GetGoods().Find(g => g.Id == id);
            if(good!=null)
            {
                return View(good);
            }
            return HttpNotFound();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Delete(int id)
        {
            GoodHandler handler = new GoodHandler();
            handler.Delete(id);
            return RedirectToAction("Index");
        }
    }
}