using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.AuthenticationFilters;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [BasicAuthAttribute]
    public class DepartmentsController : Controller
    {
        private Context db = new Context();
        
        
        // GET: DepModels
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Department.ToList());
        }

        // GET: DepModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepModel depModel = db.Department.Find(id);
            if (depModel == null)
            {
                return HttpNotFound();
            }
            return View(depModel);
        }

        // GET: DepModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepId,DepName")] DepModel depModel)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(depModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(depModel);
        }

        // GET: DepModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepModel depModel = db.Department.Find(id);
            if (depModel == null)
            {
                return HttpNotFound();
            }
            return View(depModel);
        }

        // POST: DepModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepId,DepName")] DepModel depModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depModel);
        }

        // GET: DepModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepModel depModel = db.Department.Find(id);
            if (depModel == null)
            {
                return HttpNotFound();
            }
            return View(depModel);
        }

        // POST: DepModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepModel depModel = db.Department.Find(id);
            db.Department.Remove(depModel);
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
