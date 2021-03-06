﻿using Dance.Eticaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dance.Eticaret.UI.Web.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        DanceDb db = new DanceDb();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email,string Password)
        {
            var data = db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive==true && x.ISAdmin==true).ToList();
            if (data.Count == 1)
            {
                Session["AdminLoginUser"] = data.FirstOrDefault();
                return Redirect("/admin");
            }
            else
            {
                return View();
            }
            
        }
    }
}