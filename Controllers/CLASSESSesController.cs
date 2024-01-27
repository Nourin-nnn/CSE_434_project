using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSE_434_project.Models;
using PagedList;
namespace CSE_434_project.Controllers
{
    [Authorize(Roles = "Admin, Assistantteacher")]
    public class CLASSESSesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            int pageSize = 5;//Configure paging size
            int pageNumber = (page ?? 1);//C# 8 onwards, ??= assigns value of the right operand only if the left operand is null
            return View(db.CLASSESSes.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: CLASSESSes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSESS cLASSESS = db.CLASSESSes.Find(id);
            if (cLASSESS == null)
            {
                return HttpNotFound();
            }
            return View(cLASSESS);
        }

        [Authorize(Roles = "Admin")]

        // GET: CLASSESSes/Create
        public ActionResult Create()
        {
            ViewBag.teacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: CLASSESSes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SeatCapacity,Section,RoomNo,teacherID")] CLASSESS cLASSESS)
        {
            if (ModelState.IsValid)
            {
                db.CLASSESSes.Add(cLASSESS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", cLASSESS.teacherID);
            return View(cLASSESS);
        }

        [Authorize(Roles = "Admin")]
        // GET: CLASSESSes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSESS cLASSESS = db.CLASSESSes.Find(id);
            if (cLASSESS == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", cLASSESS.teacherID);
            return View(cLASSESS);
        }

        // POST: CLASSESSes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SeatCapacity,Section,RoomNo,teacherID")] CLASSESS cLASSESS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASSESS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", cLASSESS.teacherID);
            return View(cLASSESS);
        }
        [Authorize(Roles = "Admin")]
        // GET: CLASSESSes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASSESS cLASSESS = db.CLASSESSes.Find(id);
            if (cLASSESS == null)
            {
                return HttpNotFound();
            }
            return View(cLASSESS);
        }

        // POST: CLASSESSes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASSESS cLASSESS = db.CLASSESSes.Find(id);
            db.CLASSESSes.Remove(cLASSESS);
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
