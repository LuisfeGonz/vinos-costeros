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
    public class controlSiembrasController : Controller
    {
        private VinosCosterosEntities db = new VinosCosterosEntities();

        // GET: controlSiembras
        public ActionResult Index()
        {
            var controlSiembras = db.controlSiembras.Include(c => c.siembra);
            return View(controlSiembras.ToList());
        }

        // GET: controlSiembras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            controlSiembra controlSiembra = db.controlSiembras.Find(id);
            if (controlSiembra == null)
            {
                return HttpNotFound();
            }
            return View(controlSiembra);
        }

        // GET: controlSiembras/Create
        public ActionResult Create()
        {
            ViewBag.siembra_id = new SelectList(db.siembras, "id", "variedad_uva");
            return View();
        }

        // POST: controlSiembras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,siembra_id,fecha,observaciones,temperatura,humedad")] controlSiembra controlSiembra)
        {
            if (ModelState.IsValid)
            {
                db.controlSiembras.Add(controlSiembra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.siembra_id = new SelectList(db.siembras, "id", "variedad_uva", controlSiembra.siembra_id);
            return View(controlSiembra);
        }

        // GET: controlSiembras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            controlSiembra controlSiembra = db.controlSiembras.Find(id);
            if (controlSiembra == null)
            {
                return HttpNotFound();
            }
            ViewBag.siembra_id = new SelectList(db.siembras, "id", "variedad_uva", controlSiembra.siembra_id);
            return View(controlSiembra);
        }

        // POST: controlSiembras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,siembra_id,fecha,observaciones,temperatura,humedad")] controlSiembra controlSiembra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlSiembra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.siembra_id = new SelectList(db.siembras, "id", "variedad_uva", controlSiembra.siembra_id);
            return View(controlSiembra);
        }

        // GET: controlSiembras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            controlSiembra controlSiembra = db.controlSiembras.Find(id);
            if (controlSiembra == null)
            {
                return HttpNotFound();
            }
            return View(controlSiembra);
        }

        // POST: controlSiembras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            controlSiembra controlSiembra = db.controlSiembras.Find(id);
            db.controlSiembras.Remove(controlSiembra);
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
