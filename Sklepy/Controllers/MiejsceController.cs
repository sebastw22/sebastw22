using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sklepy.Models.DB;
using Sklepy.Models.ViewModel;
namespace Sklepy.Controllers
{
    public class MiejsceController : Controller
    {
        private UzytkownicyEntities db = new UzytkownicyEntities();

        // GET: Miejsce
        public ActionResult Index( int? id, int? SklepID)
        {

            
            var viewModel = new ProduktIndexData();
            viewModel.Miejsces = db.Miejsces
               // .Include(i => i.Sklep_has_Miejsce.Select(s => s.Sklep))
                .OrderBy(i => i.Nazwa);


            // z tego korzystam zeby wyswietlic dane o sklepie, porownuje miejsce id z ID przekazanym przez select
            if (id != null)
            {
                viewModel.Sklep_has_Miejsces = viewModel.Miejsces.Where(i => i.MiejsceID == id.Value).Single().Sklep_has_Miejsce;
                viewModel.Skleps = viewModel.Sklep_has_Miejsces.Where(i => i.MiejsceID == id.Value).Select(s => s.Sklep);
          
            }
            
            if (SklepID != null)
            {
                ViewBag.SklepID = SklepID.Value;
                viewModel.Sklep_has_Produkts = viewModel.Skleps.Where(i => i.SklepID == SklepID.Value).Single().Sklep_has_Produkt;
                viewModel.Produkts = viewModel.Sklep_has_Produkts.Where(i => i.SklepID == SklepID.Value).Select(p => p.Produkt);
                
            }


            return View(viewModel);

/*
            if (id != null)
            {
                ViewBag.InstructorID = id.Value;
                viewModel.Courses = viewModel.Instructors.Where(
                    i => i.ID == id.Value).Single().Courses;
            }

            if (courseID != null)
            {
                ViewBag.CourseID = courseID.Value;
                viewModel.Enrollments = viewModel.Courses.Where(
                    x => x.CourseID == courseID).Single().Enrollments;
            }


    */
            // return View(db.Miejsces.ToList());



        }

        // GET: Miejsce/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejsce miejsce = db.Miejsces.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            return View(miejsce);
        }

        // GET: Miejsce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Miejsce/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MiejsceID,Nazwa,Adres,Telefon,Email,Data_otwarcia")] Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                db.Miejsces.Add(miejsce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miejsce);
        }

        // GET: Miejsce/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejsce miejsce = db.Miejsces.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            return View(miejsce);
        }

        // POST: Miejsce/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MiejsceID,Nazwa,Adres,Telefon,Email,Data_otwarcia")] Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miejsce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miejsce);
        }

        // GET: Miejsce/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejsce miejsce = db.Miejsces.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            return View(miejsce);
        }

        // POST: Miejsce/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miejsce miejsce = db.Miejsces.Find(id);
            db.Miejsces.Remove(miejsce);
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
