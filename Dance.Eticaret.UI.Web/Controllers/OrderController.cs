using Dance.Eticaret.Model;
using Dance.Eticaret.Model.Entity;
using Dance.Eticaret.UI.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dance.Eticaret.UI.Web.Controllers
{
    public class OrderController : DanceControllerBase 
    {
        DanceDb db = new DanceDb();

        // GET: Order
        [Route("Siparisver")]
        public ActionResult AddressList()
        {
            var data = db.UserAddresses.Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }

        public ActionResult CreateUserAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserAddress(UserAddress entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUserID = LoginUserID;
            entity.UserID = LoginUserID;
            entity.IsActive = true;

            db.UserAddresses.Add(entity);
            db.SaveChanges();

            return View();
        }

        public ActionResult CreateOrder(int id)
        {
            Order order = new Order();
            var sepet = db.Baskets.Include("DanceLesson").Where(x => x.UserId == LoginUserID).ToArray();
            order.CreateDate = DateTime.Now;
            order.CreateUserID = LoginUserID;
            order.StatusID = 2;
            order.TotalLessonPrice = sepet.Sum(x => x.DanceLesson.Price);
            order.TotalTaxPrice = sepet.Sum(x => x.DanceLesson.Tax);
            order.TotalDiscount = sepet.Sum(x => x.DanceLesson.Discount);
            order.TotalPrice = order.TotalTaxPrice + order.TotalLessonPrice;
            order.UserAddressID = id;
            order.UserID = LoginUserID;
            order.OrderLessons = new List<OrderLesson>();

            foreach (var item in sepet)
            {
                order.OrderLessons.Add(new OrderLesson
                {
                    CreateDate = DateTime.Now,
                    CreateUserID = LoginUserID,
                    DanceLessonID=item.DanceLessonID,
                    Quantity=item.Quantity
                
                });
            }
            db.Orders.Add(order);
            db.SaveChanges();
            return View();
        }
    }
}