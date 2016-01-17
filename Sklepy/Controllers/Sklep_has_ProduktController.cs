using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sklepy.Models.DB;
using Sklepy.Security;

namespace Sklepy.Controllers
{
    public class Sklep_has_ProduktController : Controller
    {
        private UzytkownicyEntities db = new UzytkownicyEntities();

        // GET: Sklep_has_Produkt
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Index()
        {
            var sklep_has_Produkt = db.Sklep_has_Produkt.Include(s => s.Produkt).Include(s => s.Sklep);
            return View(sklep_has_Produkt.ToList());
        }

        // GET: Sklep_has_Produkt/Details/5
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep_has_Produkt sklep_has_Produkt = db.Sklep_has_Produkt.Find(id);
            if (sklep_has_Produkt == null)
            {
                return HttpNotFound();
            }
            return View(sklep_has_Produkt);
        }

        // GET: Sklep_has_Produkt/Create
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Create()
        {
            ViewBag.ProduktID = new SelectList(db.Produkts, "ProduktID", "Nazwa");
            ViewBag.SklepID = new SelectList(db.Skleps, "SklepID", "Nazwa");
            return View();
        }

        // POST: Sklep_has_Produkt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sklep_has_MiejsceID,SklepID,ProduktID")] Sklep_has_Produkt sklep_has_Produkt)
        {
            if (ModelState.IsValid)
            {
                db.Sklep_has_Produkt.Add(sklep_has_Produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProduktID = new SelectList(db.Produkts, "ProduktID", "Nazwa", sklep_has_Produkt.ProduktID);
            ViewBag.SklepID = new SelectList(db.Skleps, "SklepID", "Nazwa", sklep_has_Produkt.SklepID);
            return View(sklep_has_Produkt);
        }

        // GET: Sklep_has_Produkt/Edit/5
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep_has_Produkt sklep_has_Produkt = db.Sklep_has_Produkt.Find(id);
            if (sklep_has_Produkt == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProduktID = new SelectList(db.Produkts, "ProduktID", "Nazwa", sklep_has_Produkt.ProduktID);
            ViewBag.SklepID = new SelectList(db.Skleps, "SklepID", "Nazwa", sklep_has_Produkt.SklepID);
            return View(sklep_has_Produkt);
        }

        // POST: Sklep_has_Produkt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sklep_has_MiejsceID,SklepID,ProduktID")] Sklep_has_Produkt sklep_has_Produkt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sklep_has_Produkt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProduktID = new SelectList(db.Produkts, "ProduktID", "Nazwa", sklep_has_Produkt.ProduktID);
            ViewBag.SklepID = new SelectList(db.Skleps, "SklepID", "Nazwa", sklep_has_Produkt.SklepID);
            return View(sklep_has_Produkt);
        }

        // GET: Sklep_has_Produkt/Delete/5
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep_has_Produkt sklep_has_Produkt = db.Sklep_has_Produkt.Find(id);
            if (sklep_has_Produkt == null)
            {
                return HttpNotFound();
            }
            return View(sklep_has_Produkt);
        }

        // POST: Sklep_has_Produkt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sklep_has_Produkt sklep_has_Produkt = db.Sklep_has_Produkt.Find(id);
            db.Sklep_has_Produkt.Remove(sklep_has_Produkt);
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
