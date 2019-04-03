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
    public class DanceTypesController : Controller
    {
        private DanceDb db = new DanceDb();

        // GET: Admin/DanceTypes
        public ActionResult Index()
        {
            return View(db.DanceTypes.ToList());
        }

        // GET: Admin/DanceTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanceType danceType = db.DanceTypes.Find(id);
            if (danceType == null)
            {
                return HttpNotFound();
            }
            return View(danceType);
        }

        // GET: Admin/DanceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ParentID,Name,IsActive,CreateDate,UpdateDate,CreateUserID,UpdateUserID")] DanceType danceType)
        {
            if (ModelState.IsValid)
            {
                db.DanceTypes.Add(danceType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danceType);
        }

        // GET: Admin/DanceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanceType danceType = db.DanceTypes.Find(id);
            if (danceType == null)
            {
                return HttpNotFound();
            }
            return View(danceType);
        }

        // POST: Admin/DanceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ParentID,Name,IsActive,CreateDate,UpdateDate,CreateUserID,UpdateUserID")] DanceType danceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danceType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danceType);
        }

        // GET: Admin/DanceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanceType danceType = db.DanceTypes.Find(id);
            if (danceType == null)
            {
                return HttpNotFound();
            }
            return View(danceType);
        }

        // POST: Admin/DanceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanceType danceType = db.DanceTypes.Find(id);
            db.DanceTypes.Remove(danceType);
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
