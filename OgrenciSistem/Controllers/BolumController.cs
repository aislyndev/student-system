using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OgrenciSistem.Models;

namespace OgrenciSistem.Controllers
{
    public class BolumController : Controller
    {
        private OgrencibilgisistemidbEntities db = new OgrencibilgisistemidbEntities();

        // GET: Bolum
        public ActionResult Index()
        {
            var tBolum = db.tBolum.Include(t => t.tFakulte);
            return View(tBolum.ToList());
        }

        // GET: Bolum/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBolum tBolum = db.tBolum.Find(id);
            if (tBolum == null)
            {
                return HttpNotFound();
            }
            return View(tBolum);
        }

        // GET: Bolum/Create
        public ActionResult Create()
        {
            ViewBag.fakulteID = new SelectList(db.tFakulte, "fakulteID", "fakulteAd");
            return View();
        }

        // POST: Bolum/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bolumID,bolumAd,fakulteID")] tBolum tBolum)
        {
            if (ModelState.IsValid)
            {
                db.tBolum.Add(tBolum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fakulteID = new SelectList(db.tFakulte, "fakulteID", "fakulteAd", tBolum.fakulteID);
            return View(tBolum);
        }

        // GET: Bolum/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBolum tBolum = db.tBolum.Find(id);
            if (tBolum == null)
            {
                return HttpNotFound();
            }
            ViewBag.fakulteID = new SelectList(db.tFakulte, "fakulteID", "fakulteAd", tBolum.fakulteID);
            return View(tBolum);
        }

        // POST: Bolum/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bolumID,bolumAd,fakulteID")] tBolum tBolum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBolum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fakulteID = new SelectList(db.tFakulte, "fakulteID", "fakulteAd", tBolum.fakulteID);
            return View(tBolum);
        }

        // GET: Bolum/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBolum tBolum = db.tBolum.Find(id);
            if (tBolum == null)
            {
                return HttpNotFound();
            }
            return View(tBolum);
        }

        // POST: Bolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tBolum tBolum = db.tBolum.Find(id);
            db.tBolum.Remove(tBolum);
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
