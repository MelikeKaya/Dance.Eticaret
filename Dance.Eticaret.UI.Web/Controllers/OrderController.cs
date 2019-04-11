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

            return View();
        }
    }
}