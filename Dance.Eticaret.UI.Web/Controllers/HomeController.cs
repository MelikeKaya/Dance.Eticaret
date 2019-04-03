using Dance.Eticaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dance.Eticaret.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetMenu()
        {
            var db = new DanceDb();
            var menus = db.DanceTypes.Where(x => x.ParentID == 0).ToList();
            return PartialView(menus);
        }
        [Route("Uye-Giris")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Uye-Giris")]
        public ActionResult Login(string Email,string Password)
        {
            var db = new DanceDb();
            var users = db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive==true && x.ISAdmin==false).ToList();
            if (users.Count==1)
            {
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                //controllerla sayfa arasında veri taşımak için kullanılıyor viewbag
                ViewBag.Error="Hatalı Kullanıcı veya Şifre"
                return View();
            }
            return View();
        }
    }
}