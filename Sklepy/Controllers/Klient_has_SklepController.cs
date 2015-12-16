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
    public class Klient_has_SklepController : Controller
    {
        private SklepyContext db = new SklepyContext();

        // GET: Klient_has_Sklep
        public ActionResult Index()
        {
            var klient_has_Skleps = db.Klient_has_Skleps.Include(k => k.Klient).Include(k => k.Sklep);
            return View(klient_has_Skleps.ToList());
        }

        // GET: Klient_has_Sklep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient_has_Sklep klient_has_Sklep = db.Klient_has_Skleps.Find(id);
            if (klient_has_Sklep == null)
            {
                return HttpNotFound();
            }
            return View(klient_has_Sklep);
        }

        // GET: Klient_has_Sklep/Create
        public ActionResult Create()
        {
            ViewBag.KlientID = new SelectList(db.Klients, "ID", "Imie");
            ViewBag.SklepID = new SelectList(db.Skleps, "ID", "Nazwa");
            return View();
        }

        // POST: Klient_has_Sklep/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Klient_has_SklepID,KlientID,SklepID,znizka1,znizka2,znizka3")] Klient_has_Sklep klient_has_Sklep)
        {
            if (ModelState.IsValid)
            {
                db.Klient_has_Skleps.Add(klient_has_Sklep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlientID = new SelectList(db.Klients, "ID", "Imie", klient_has_Sklep.KlientID);
            ViewBag.SklepID = new SelectList(db.Skleps, "ID", "Nazwa", klient_has_Sklep.SklepID);
            return View(klient_has_Sklep);
        }

        // GET: Klient_has_Sklep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient_has_Sklep klient_has_Sklep = db.Klient_has_Skleps.Find(id);
            if (klient_has_Sklep == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlientID = new SelectList(db.Klients, "ID", "Imie", klient_has_Sklep.KlientID);
            ViewBag.SklepID = new SelectList(db.Skleps, "ID", "Nazwa", klient_has_Sklep.SklepID);
            return View(klient_has_Sklep);
        }

        // POST: Klient_has_Sklep/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Klient_has_SklepID,KlientID,SklepID,znizka1,znizka2,znizka3")] Klient_has_Sklep klient_has_Sklep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klient_has_Sklep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlientID = new SelectList(db.Klients, "ID", "Imie", klient_has_Sklep.KlientID);
            ViewBag.SklepID = new SelectList(db.Skleps, "ID", "Nazwa", klient_has_Sklep.SklepID);
            return View(klient_has_Sklep);
        }

        // GET: Klient_has_Sklep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient_has_Sklep klient_has_Sklep = db.Klient_has_Skleps.Find(id);
            if (klient_has_Sklep == null)
            {
                return HttpNotFound();
            }
            return View(klient_has_Sklep);
        }

        // POST: Klient_has_Sklep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klient_has_Sklep klient_has_Sklep = db.Klient_has_Skleps.Find(id);
            db.Klient_has_Skleps.Remove(klient_has_Sklep);
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
