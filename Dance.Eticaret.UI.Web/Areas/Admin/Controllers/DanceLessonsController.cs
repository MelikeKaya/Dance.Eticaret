using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dance.Eticaret.Model;
using Dance.Eticaret.Model.Entity;

namespace Dance.Eticaret.UI.Web.Areas.Admin.Controllers
{
    public class DanceLessonsController : Controller
    {
        private DanceDb db = new DanceDb();

        // GET: Admin/DanceLessons
        public ActionResult Index()
        {
            var danceLessons = db.DanceLessons.Include(d => d.DanceType);
            return View(danceLessons.ToList());
        }

        // GET: Admin/DanceLessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanceLesson danceLesson = db.DanceLessons.Find(id);
            if (danceLesson == null)
            {
                return HttpNotFound();
            }
            return View(danceLesson);
        }

        // GET: Admin/DanceLessons/Create
        public ActionResult Create()
        {
            ViewBag.DanceTypeID = new SelectList(db.DanceTypes, "ID", "Name");
            return View();
        }

        // POST: Admin/DanceLessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DanceTypeID,Trainer,ImageUrl,VideoUrl,Description,Price,Tax,Discount,Kontenjan,IsActive,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] DanceLesson danceLesson)
        {
            if (ModelState.IsValid)
            {
                db.DanceLessons.Add(danceLesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DanceTypeID = new SelectList(db.DanceTypes, "ID", "Name", danceLesson.DanceTypeID);
            return View(danceLesson);
        }

        // GET: Admin/DanceLessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanceLesson danceLesson = db.DanceLessons.Find(id);
            if (danceLesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.DanceTypeID = new SelectList(db.DanceTypes, "ID", "Name", danceLesson.DanceTypeID);
            return View(danceLesson);
        }

        // POST: Admin/DanceLessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DanceTypeID,Trainer,ImageUrl,VideoUrl,Description,Price,Tax,Discount,Kontenjan,IsActive,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] DanceLesson danceLesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danceLesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanceTypeID = new SelectList(db.DanceTypes, "ID", "Name", danceLesson.DanceTypeID);
            return View(danceLesson);
        }

        // GET: Admin/DanceLessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanceLesson danceLesson = db.DanceLessons.Find(id);
            if (danceLesson == null)
            {
                return HttpNotFound();
            }
            return View(danceLesson);
        }

        // POST: Admin/DanceLessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanceLesson danceLesson = db.DanceLessons.Find(id);
            db.DanceLessons.Remove(danceLesson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
