using Dance.Eticaret.Model;
using Dance.Eticaret.UI.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dance.Eticaret.UI.Web.Controllers
{
    public class DanceTypeController : DanceControllerBase
    {
        // GET: DanceType
        [Route("Kategori/{isim}/{id}")]
        public ActionResult Index(string isim, int id)
        {
            var db = new DanceDb();
            var lessons= db.DanceLessons.Where(x => x.IsActive == true && x.DanceTypeID == id).ToList();
            ViewBag.category = db.DanceTypes.Where(x => x.ID == id).FirstOrDefault();
            return View(lessons);
        }

       
    }
}