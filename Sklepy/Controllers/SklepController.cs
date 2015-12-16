using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sklepy.DAL;
using Sklepy.Models;

namespace Sklepy.Controllers
{
    public class SklepController : Controller
    {
        private SklepyContext db = new SklepyContext();

        // GET: Sklep
        public ActionResult Index()
        {
            return View(db.Skleps.ToList());
        }

        // GET: Sklep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Skleps.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // GET: Sklep/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sklep/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,Numer,Telefon")] Sklep sklep)
        {
            if (ModelState.IsValid)
            {
                db.Skleps.Add(sklep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sklep);
        }

        // GET: Sklep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Skleps.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // POST: Sklep/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,Numer,Telefon")] Sklep sklep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sklep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sklep);
        }

        // GET: Sklep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Skleps.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // POST: Sklep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sklep sklep = db.Skleps.Find(id);
            db.Skleps.Remove(sklep);
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
