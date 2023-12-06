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
    public class OgrenciController : Controller
    {
        private OgrencibilgisistemidbEntities db = new OgrencibilgisistemidbEntities();

        // GET: Ogrenci
        public ActionResult Index()
        {
            var tOgrenci = db.tOgrenci.Include(t => t.tBolum).Include(t => t.tOgrenciDers);
            return View(tOgrenci.ToList());
        }

        // GET: Ogrenci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOgrenci tOgrenci = db.tOgrenci.Find(id);
            if (tOgrenci == null)
            {
                return HttpNotFound();
            }
            return View(tOgrenci);
        }

        // GET: Ogrenci/Create
        public ActionResult Create()
        {
            ViewBag.bolumID = new SelectList(db.tBolum, "bolumID", "bolumAd");
            //ViewBag.ogrenciID = new SelectList(db.tOgrenciDers, "ogrenciID", "dersID");
            return View();
        }

        // POST: Ogrenci/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ogrenciID,ad,soyad,bolumID")] tOgrenci tOgrenci)
        {
            if (ModelState.IsValid)
            {
                db.tOgrenci.Add(tOgrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bolumID = new SelectList(db.tBolum, "bolumID", "bolumAd", tOgrenci.bolumID);
            //ViewBag.ogrenciID = new SelectList(db.tOgrenciDers, "ogrenciID", "dersID", tOgrenci.ogrenciID);
            return View(tOgrenci);
        }

        // GET: Ogrenci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOgrenci tOgrenci = db.tOgrenci.Find(id);
            if (tOgrenci == null)
            {
                return HttpNotFound();
            }
            ViewBag.bolumID = new SelectList(db.tBolum, "bolumID", "bolumAd", tOgrenci.bolumID);
            //ViewBag.ogrenciID = new SelectList(db.tOgrenciDers, "ogrenciID", "dersID", tOgrenci.ogrenciID);
            return View(tOgrenci);
        }

        // POST: Ogrenci/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ogrenciID,ad,soyad,bolumID")] tOgrenci tOgrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOgrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bolumID = new SelectList(db.tBolum, "bolumID", "bolumAd", tOgrenci.bolumID);
            //ViewBag.ogrenciID = new SelectList(db.tOgrenciDers, "ogrenciID", "dersID", tOgrenci.ogrenciID);
            return View(tOgrenci);
        }

        // GET: Ogrenci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOgrenci tOgrenci = db.tOgrenci.Find(id);
            if (tOgrenci == null)
            {
                return HttpNotFound();
            }
            return View(tOgrenci);
        }

        // POST: Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tOgrenci tOgrenci = db.tOgrenci.Find(id);
            db.tOgrenci.Remove(tOgrenci);
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
