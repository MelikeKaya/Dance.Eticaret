using Dance.Eticaret.Model;
using Dance.Eticaret.UI.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dance.Eticaret.UI.Web.Controllers
{
    public class DanceLessonController : DanceControllerBase
    {
        // GET: DanceLesson
        [Route("Ders/{title}/{id}")]
        public ActionResult Detail(string title, int id)
        {
            var db = new DanceDb();
            var lesson = db.DanceLessons.Where(x => x.ID == id).FirstOrDefault();
            return View(lesson);
        }
    }
}