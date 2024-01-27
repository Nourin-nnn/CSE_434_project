using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSE_434_project.Models;
using PagedList;


namespace CSE_434_project.Controllers
{
    [Authorize(Roles = "Admin, Assistantteacher")]
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teachers
        //public ActionResult Index()
        //{
        //    return View(db.Teachers.ToList());
        //}

        public ActionResult Index(int? page)
        {

            int pageSize = 5;//Configure paging size
            int pageNumber = (page ?? 1);//C# 8 onwards, ??= assigns value of the right operand only if the left operand is null
            return View(db.Teachers.ToList().ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin")]
        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [Authorize(Roles = "Admin")]
        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid && UploadImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(UploadImage.FileName);
                string extension = Path.GetExtension(UploadImage.FileName);
                fileName = fileName + extension;
                teacher.Picture = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                // Save the uploaded file
                UploadImage.SaveAs(fileName);

                // Add the teacher to the database and save changes
                db.Teachers.Add(teacher);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            // If ModelState is not valid or UploadImage is null, return to the Create view with errors
            return View(teacher);
        }


        [Authorize(Roles = "Admin")]
        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherID,TeacherName,Subject,JoiningDate,DOB,Email,Mobile,Address,Picture")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        [Authorize(Roles = "Admin")]
        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
