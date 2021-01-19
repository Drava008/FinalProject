using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore.Models;

namespace bookstore.Controllers
{
    public class HomeController : Controller
    {

        Database1Entities db = new Database1Entities();

        public ActionResult Index()
        {
            ViewBag.pageI = "active";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.pageA = "active";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.pageC = "active";
            return View();
        }

        public ActionResult Service1()
        {
            ViewBag.pageS = "active";
            return View();
        }
        public ActionResult Service2()
        {
            ViewBag.pageS = "active";
            return View();
        }
        public ActionResult Service3()
        {
            ViewBag.pageS = "active";
            return View();
        }
        public ActionResult Service4()
        {
            ViewBag.pageS = "active";
            return View();
        }
        public ActionResult Login()
        {
            if (Session["user"] != null) return RedirectToAction("admin");
            return View();
        }
        [HttpPost]
        public ActionResult Login(users users)
        {
            var user = db.users.Where(m => m.user == users.user && m.password == users.password).FirstOrDefault();

            if(user != null)
            {
                Session["user"] = user.name;
                return RedirectToAction("admin");
            }

            ViewBag.msg = "帳號密碼錯誤";

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index");
        }
        public ActionResult admin()
        {
            if (Session["user"] == null) return RedirectToAction("login");

            ViewBag.contact = db.contact.Count();
            ViewBag.service = db.service.Count();

            ViewBag.user = Session["user"] + "";
            return View();
        }
        public ActionResult userslist()
        {
            if (Session["user"] == null) return RedirectToAction("login");

            var user = db.users.ToList();
            return View(user);
        }
        public ActionResult usersadd()
        {
            if (Session["user"] == null) return RedirectToAction("login");

            return View();
        }
        [HttpPost]
        public ActionResult usersadd(users users)
        {
            var user = db.users.Where(m => m.user == users.user).FirstOrDefault();

            if (user == null)
            {
                db.users.Add(users);
                db.SaveChanges();

                return RedirectToAction("userslist");
            }

            ViewBag.msg = users.user + "帳號已被使用，請重新輸入";
            return View();
            
        }
        public ActionResult usersmod(int id)
        {
            if (Session["user"] == null) return RedirectToAction("login");

            var user = db.users.Find(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult usersmod(users users)
        {
            var user = db.users.Find(users.Id);

            user.password = users.password;
            user.name = users.name;
            db.SaveChanges();

            return RedirectToAction("userslist");
        }
        public ActionResult usersdel(int id)
        {
            var user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("userslist");
        }
        public ActionResult servicelist()
        {
            if (Session["user"] == null) return RedirectToAction("login");

            var ser = db.service.ToList();
            return View(ser);
        }
        public ActionResult servicedel(int id)
        {
            var ser = db.service.Find(id);
            db.service.Remove(ser);
            db.SaveChanges();

            return RedirectToAction("servicelist");
        }
        [HttpPost]
        public ActionResult service1(service ser)
        {
            db.service.Add(ser);
            db.SaveChanges();

            return View();
        }
        [HttpPost]
        public ActionResult service2(service ser)
        {
            db.service.Add(ser);
            db.SaveChanges();

            return View();
        }
        [HttpPost]
        public ActionResult service3(service ser)
        {
            db.service.Add(ser);
            db.SaveChanges();

            return View();
        }
        [HttpPost]
        public ActionResult service4(service ser)
        {
            db.service.Add(ser);
            db.SaveChanges();

            return View();
        }
        public ActionResult contactlist()
        {
            if (Session["user"] == null) return RedirectToAction("login");

            var con = db.contact.ToList();
            return View(con);
        }
        [HttpPost]
        public ActionResult Contact(contact con)
        {
            db.contact.Add(con);
            db.SaveChanges();

            return View();
        }
        public ActionResult contactdel(int id)
        {
            var con = db.contact.Find(id);
            db.contact.Remove(con);
            db.SaveChanges();

            return RedirectToAction("contactlist");
        }
    }
}