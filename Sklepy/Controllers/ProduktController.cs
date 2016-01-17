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
    public class ProduktController : Controller
    {
        private UzytkownicyEntities db = new UzytkownicyEntities();

        // GET: Produkt
        [AuthorizeRoles("Admin", "Member","Sklep")]
        public ActionResult Index()
        {
            var produkts = db.Produkts.Include(p => p.RodzajProd);
            return View(produkts.ToList());
        }

        // GET: Produkt/Details/5
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // GET: Produkt/Create
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Create()
        {
            ViewBag.RodzajProdID = new SelectList(db.RodzajProds, "RodzajProdID", "Nazwa");
            return View();
        }

        // POST: Produkt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProduktID,Nazwa,IloscOgolem,Cena,RodzajProdID")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Produkts.Add(produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RodzajProdID = new SelectList(db.RodzajProds, "RodzajProdID", "Nazwa", produkt.RodzajProdID);
            return View(produkt);
        }

        // GET: Produkt/Edit/5
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            ViewBag.RodzajProdID = new SelectList(db.RodzajProds, "RodzajProdID", "Nazwa", produkt.RodzajProdID);
            return View(produkt);
        }

        // POST: Produkt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProduktID,Nazwa,IloscOgolem,Cena,RodzajProdID")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RodzajProdID = new SelectList(db.RodzajProds, "RodzajProdID", "Nazwa", produkt.RodzajProdID);
            return View(produkt);
        }

        // GET: Produkt/Delete/5
        [AuthorizeRoles("Admin", "Member", "Sklep")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: Produkt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkt produkt = db.Produkts.Find(id);
            db.Produkts.Remove(produkt);
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
