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
    public class catasController : Controller
    {
        private VinosCosterosEntities db = new VinosCosterosEntities();

        // GET: catas
        public ActionResult Index()
        {
            var catas = db.catas.Include(c => c.produccion).Include(c => c.usuario);
            return View(catas.ToList());
        }

        // GET: catas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cata cata = db.catas.Find(id);
            if (cata == null)
            {
                return HttpNotFound();
            }
            return View(cata);
        }

        // GET: catas/Create
        public ActionResult Create()
        {
            ViewBag.idProduccion = new SelectList(db.produccions, "id", "nombre");
            ViewBag.idEvaluador = new SelectList(db.usuarios, "id", "nombre");
            return View();
        }

        // POST: catas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,observaciones,idEvaluador,idProduccion,idRanking,calificacion")] cata cata)
        {
            if (cata.calificacion < 0 || cata.calificacion > 100)
            {
                ModelState.AddModelError("calificacion", "La calificación debe estar entre 0 y 100");
            }
            if (ModelState.IsValid)
            {
                db.catas.Add(cata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProduccion = new SelectList(db.produccions, "id", "nombre", cata.idProduccion);
            ViewBag.idEvaluador = new SelectList(db.usuarios, "id", "nombre", cata.idEvaluador);
            return View(cata);
        }

        // GET: catas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cata cata = db.catas.Find(id);
            if (cata == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProduccion = new SelectList(db.produccions, "id", "nombre", cata.idProduccion);
            ViewBag.idEvaluador = new SelectList(db.usuarios, "id", "nombre", cata.idEvaluador);
            return View(cata);
        }

        // POST: catas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,observaciones,idEvaluador,idProduccion,idRanking,calificacion")] cata cata)
        {
            if (cata.calificacion < 0 || cata.calificacion > 100)
            {
                ModelState.AddModelError("calificacion", "La calificación debe estar entre 0 y 100");
            }
            if (ModelState.IsValid)
            {
                db.Entry(cata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProduccion = new SelectList(db.produccions, "id", "nombre", cata.idProduccion);
            ViewBag.idEvaluador = new SelectList(db.usuarios, "id", "nombre", cata.idEvaluador);
            return View(cata);
        }

        // GET: catas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cata cata = db.catas.Find(id);
            if (cata == null)
            {
                return HttpNotFound();
            }
            return View(cata);
        }

        // POST: catas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cata cata = db.catas.Find(id);
            db.catas.Remove(cata);
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
