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
            db.SaveChanges();
            return Json("");
        }
    }
}