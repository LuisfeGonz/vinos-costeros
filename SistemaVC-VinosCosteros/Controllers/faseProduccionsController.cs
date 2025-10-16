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
    public class faseProduccionsController : Controller
    {
        private VinosCosterosEntities db = new VinosCosterosEntities();

        // GET: faseProduccions
        public ActionResult Index()
        {
            var faseProduccions = db.faseProduccions.Include(f => f.produccion);
            return View(faseProduccions.ToList());
        }

        // GET: faseProduccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faseProduccion faseProduccion = db.faseProduccions.Find(id);
            if (faseProduccion == null)
            {
                return HttpNotFound();
            }
            return View(faseProduccion);
        }

        // GET: faseProduccions/Create
        public ActionResult Create()
        {
            ViewBag.produccion_id = new SelectList(db.produccions, "id", "nombre");
            return View();
        }

        // POST: faseProduccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,produccion_id,nombre_fase,descripcion")] faseProduccion faseProduccion)
        {
            if (ModelState.IsValid)
            {
                db.faseProduccions.Add(faseProduccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.produccion_id = new SelectList(db.produccions, "id", "nombre", faseProduccion.produccion_id);
            return View(faseProduccion);
        }

        // GET: faseProduccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faseProduccion faseProduccion = db.faseProduccions.Find(id);
            if (faseProduccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.produccion_id = new SelectList(db.produccions, "id", "nombre", faseProduccion.produccion_id);
            return View(faseProduccion);
        }

        // POST: faseProduccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,produccion_id,nombre_fase,descripcion")] faseProduccion faseProduccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faseProduccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.produccion_id = new SelectList(db.produccions, "id", "nombre", faseProduccion.produccion_id);
            return View(faseProduccion);
        }

        // GET: faseProduccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faseProduccion faseProduccion = db.faseProduccions.Find(id);
            if (faseProduccion == null)
            {
                return HttpNotFound();
            }
            return View(faseProduccion);
        }

        // POST: faseProduccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            faseProduccion faseProduccion = db.faseProduccions.Find(id);
            db.faseProduccions.Remove(faseProduccion);
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
