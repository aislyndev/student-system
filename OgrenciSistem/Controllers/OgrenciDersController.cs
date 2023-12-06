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
    public class OgrenciDersController : Controller
    {
        private OgrencibilgisistemidbEntities db = new OgrencibilgisistemidbEntities();

        // GET: OgrenciDers
        public ActionResult Index()
        {
            var tOgrenciDers = db.tOgrenciDers.Include(t => t.tDers).Include(t => t.tOgrenci);
            return View(tOgrenciDers.ToList());
        }

        // GET: OgrenciDers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOgrenciDers tOgrenciDers = db.tOgrenciDers.Find(id);
            if (tOgrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(tOgrenciDers);
        }

        // GET: OgrenciDers/Create
        public ActionResult Create()
        {
            ViewBag.dersID = new SelectList(db.tDers, "dersID", "dersAd");
            ViewBag.ogrenciID = new SelectList(db.tOgrenci, "ogrenciID", "ogrenciID");
            return View();
        }

        // POST: OgrenciDers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ogrenciID,dersID,yil,yariyil")] tOgrenciDers tOgrenciDers)
        {
            if (ModelState.IsValid)
            {
                db.tOgrenciDers.Add(tOgrenciDers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dersID = new SelectList(db.tDers, "dersID", "dersAd", tOgrenciDers.dersID);
            ViewBag.ogrenciID = new SelectList(db.tOgrenci, "ogrenciID", "ogrenciID", tOgrenciDers.ogrenciID);
            return View(tOgrenciDers);
        }

        // GET: OgrenciDers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOgrenciDers tOgrenciDers = db.tOgrenciDers.Find(id);
            if (tOgrenciDers == null)
            {
                return HttpNotFound();
            }
            ViewBag.dersID = new SelectList(db.tDers, "dersID", "dersAd", tOgrenciDers.dersID);
            ViewBag.ogrenciID = new SelectList(db.tOgrenci, "ogrenciID", "ogrenciID", tOgrenciDers.ogrenciID);
            return View(tOgrenciDers);
        }

        // POST: OgrenciDers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ogrenciID,dersID,yil,yariyil")] tOgrenciDers tOgrenciDers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOgrenciDers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dersID = new SelectList(db.tDers, "dersID", "dersAd", tOgrenciDers.dersID);
            ViewBag.ogrenciID = new SelectList(db.tOgrenci, "ogrenciID", "ogrenciID", tOgrenciDers.ogrenciID);
            return View(tOgrenciDers);
        }

        // GET: OgrenciDers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOgrenciDers tOgrenciDers = db.tOgrenciDers.Find(id);
            if (tOgrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(tOgrenciDers);
        }

        // POST: OgrenciDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tOgrenciDers tOgrenciDers = db.tOgrenciDers.Find(id);
            db.tOgrenciDers.Remove(tOgrenciDers);
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
