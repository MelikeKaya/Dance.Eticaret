using Dance.Eticaret.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dance.Eticaret.UI.Web.Controllers.Base
{
    public class DanceControllerBase:Controller
    {

        public bool IsLogin { get; private set; }
        public int LoginUserID { get; private set; }
        public User LoginUserEntity { get; private set; }

        protected override void Initialize(RequestContext requestContext)
        {

            //Session["LoginUserID"]
            //Session["LoginUser"]
            if (requestContext.HttpContext.Session["LoginUserID"]!=null)
            {
                //Kullanıcı Giriş yapmışsa
                IsLogin = true;
                LoginUserID = (int)requestContext.HttpContext.Session["LoginUserID"];
                LoginUserEntity = (Model.Entity.User)requestContext.HttpContext.Session["LoginUser"];
            }
            base.Initialize(requestContext);
        }
    }
}