using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaVC_VinosCosteros.Models;

namespace SistemaVC_VinosCosteros.Controllers
{
    public class parcelasController : Controller
    {
        private VinosCosterosEntities db = new VinosCosterosEntities();

        // GET: parcelas
        public ActionResult Index()
        {
            return View(db.parcelas.ToList());
        }

        // GET: parcelas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parcela parcela = db.parcelas.Find(id);
            if (parcela == null)
            {
                return HttpNotFound();
            }
            return View(parcela);
        }

        // GET: parcelas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: parcelas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,ubicacion,superficie_ha")] parcela parcela)
        {
            if (ModelState.IsValid)
            {
                db.parcelas.Add(parcela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parcela);
        }

        // GET: parcelas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parcela parcela = db.parcelas.Find(id);
            if (parcela == null)
            {
                return HttpNotFound();
            }
            return View(parcela);
        }

        // POST: parcelas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,ubicacion,superficie_ha")] parcela parcela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parcela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parcela);
        }

        // GET: parcelas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parcela parcela = db.parcelas.Find(id);
            if (parcela == null)
            {
                return HttpNotFound();
            }
            return View(parcela);
        }

        // POST: parcelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parcela parcela = db.parcelas.Find(id);
            db.parcelas.Remove(parcela);
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
