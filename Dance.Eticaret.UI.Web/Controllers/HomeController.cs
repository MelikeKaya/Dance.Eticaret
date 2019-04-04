using Dance.Eticaret.Model;
using Dance.Eticaret.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dance.Eticaret.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        DanceDb db = new DanceDb();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.DanceLessons.OrderByDescending(x => x.CreateDate).Take(5).ToList();
            return View(data);
        }

        public PartialViewResult GetMenu()
        {
            
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
            
            var users = db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive==true && x.ISAdmin==false).ToList();

            if (users.Count==1)
            {
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                //controllerla sayfa arasında veri taşımak için kullanılıyor viewbag
                ViewBag.Error = "Hatalı Kullanıcı veya Şifre";
                return View();
            }
            
        }

        [Route("Uye-Kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult CreateUser(User entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserID = 1;
                entity.IsActive = true;
                entity.ISAdmin = false;

                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return View(ex);
                throw;
            }

       
        }
    }
}