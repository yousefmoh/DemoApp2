using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.AuthenticationFilters;

namespace WebApplication3.Controllers
{
    [BasicAuthAttribute]
    public class TeacherModelsController : Controller
    {
        private Context db = new Context();

        // GET: TeacherModels
        public ActionResult Index()
        {
            var teacher = db.Teacher.Include(t => t.Class);
            return View(teacher.ToList());
        }

        // GET: TeacherModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.Teacher.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // GET: TeacherModels/Create
        public ActionResult Create()
        {
            ViewBag.ClassName = new SelectList(db.Classes, "ClassId", "ClassName");
            return View();
        }

        // POST: TeacherModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ClassName")] TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                db.Teacher.Add(teacherModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassName = new SelectList(db.Classes, "ClassId", "ClassName", teacherModel.ClassName);
            return View(teacherModel);
        }

        // GET: TeacherModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.Teacher.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassName = new SelectList(db.Classes, "ClassId", "ClassName", teacherModel.ClassName);
            return View(teacherModel);
        }

        // POST: TeacherModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ClassName")] TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassName = new SelectList(db.Classes, "ClassId", "ClassName", teacherModel.ClassName);
            return View(teacherModel);
        }

        // GET: TeacherModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.Teacher.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // POST: TeacherModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherModel teacherModel = db.Teacher.Find(id);
            db.Teacher.Remove(teacherModel);
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
