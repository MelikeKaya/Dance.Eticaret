using Dance.Eticaret.Model;
using Dance.Eticaret.UI.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dance.Eticaret.UI.Web.Controllers
{
    public class BasketController : DanceControllerBase
    {

        DanceDb db = new DanceDb();
        // GET: Basket
        [HttpPost]
        public JsonResult AddProduct(int lessonID,int quantity)
        {
            var db=new DanceDb();
            db.Baskets.Add(new Model.Entity.Basket
            {
                CreateDate = DateTime.Now,
                CreateUserID = LoginUserID,
                DanceLessonID = lessonID,
                Quantity = quantity,
                UserId = LoginUserID
            });
            var rt= db.SaveChanges();
            return Json(rt,JsonRequestBehavior.AllowGet);
        }


        [Route("Sepetim")]
        public ActionResult Index()
        {
           
            var data = db.Baskets.Include("DanceLesson").Where(x => x.UserId == LoginUserID).ToList();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var deleteItem = db.Baskets.Where(x => x.ID == id).FirstOrDefault();
            db.Baskets.Remove(deleteItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}