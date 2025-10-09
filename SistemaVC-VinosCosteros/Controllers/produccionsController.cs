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
    public class produccionsController : Controller
    {
        private VinosCosterosEntities db = new VinosCosterosEntities();

        // GET: produccions
        public ActionResult Index()
        {
            var produccions = db.produccions.Include(p => p.parcela);
            return View(produccions.ToList());
        }

        // GET: produccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccions.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            return View(produccion);
        }

        // GET: produccions/Create
        public ActionResult Create()
        {
            ViewBag.parcela_id = new SelectList(db.parcelas, "id", "nombre");
            return View();
        }

        // POST: produccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,fecha_inicio,fecha_fin,parcela_id")] produccion produccion)
        {
            if (ModelState.IsValid)
            {
                db.produccions.Add(produccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.parcela_id = new SelectList(db.parcelas, "id", "nombre", produccion.parcela_id);
            return View(produccion);
        }

        // GET: produccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccions.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.parcela_id = new SelectList(db.parcelas, "id", "nombre", produccion.parcela_id);
            return View(produccion);
        }

        // POST: produccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,fecha_inicio,fecha_fin,parcela_id")] produccion produccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.parcela_id = new SelectList(db.parcelas, "id", "nombre", produccion.parcela_id);
            return View(produccion);
        }

        // GET: produccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccions.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            return View(produccion);
        }

        // POST: produccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produccion produccion = db.produccions.Find(id);
            db.produccions.Remove(produccion);
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
