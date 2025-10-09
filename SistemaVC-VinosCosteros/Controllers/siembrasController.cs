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
    public class siembrasController : Controller
    {
        private VinosCosterosEntities db = new VinosCosterosEntities();

        // GET: siembras
        public ActionResult Index()
        {
            var siembras = db.siembras.Include(s => s.parcela);
            return View(siembras.ToList());
        }

        // GET: siembras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siembra siembra = db.siembras.Find(id);
            if (siembra == null)
            {
                return HttpNotFound();
            }
            return View(siembra);
        }

        // GET: siembras/Create
        public ActionResult Create()
        {
            ViewBag.parcela_id = new SelectList(db.parcelas, "id", "nombre");
            return View();
        }

        // POST: siembras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,parcela_id,variedad_uva,fecha_siembra,estado")] siembra siembra)
        {
            if (ModelState.IsValid)
            {
                db.siembras.Add(siembra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.parcela_id = new SelectList(db.parcelas, "id", "nombre", siembra.parcela_id);
            return View(siembra);
        }

        // GET: siembras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siembra siembra = db.siembras.Find(id);
            if (siembra == null)
            {
                return HttpNotFound();
            }
            ViewBag.parcela_id = new SelectList(db.parcelas, "id", "nombre", siembra.parcela_id);
            return View(siembra);
        }

        // POST: siembras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,parcela_id,variedad_uva,fecha_siembra,estado")] siembra siembra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siembra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.parcela_id = new SelectList(db.parcelas, "id", "nombre", siembra.parcela_id);
            return View(siembra);
        }

        // GET: siembras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siembra siembra = db.siembras.Find(id);
            if (siembra == null)
            {
                return HttpNotFound();
            }
            return View(siembra);
        }

        // POST: siembras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            siembra siembra = db.siembras.Find(id);
            db.siembras.Remove(siembra);
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
