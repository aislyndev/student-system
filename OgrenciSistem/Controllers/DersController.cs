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
    public class DersController : Controller
    {
        private OgrencibilgisistemidbEntities db = new OgrencibilgisistemidbEntities();

        // GET: Ders
        public ActionResult Index()
        {
            return View(db.tDers.ToList());
        }

        // GET: Ders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDers tDers = db.tDers.Find(id);
            if (tDers == null)
            {
                return HttpNotFound();
            }
            return View(tDers);
        }

        // GET: Ders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ders/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dersID,dersAd")] tDers tDers)
        {
            if (ModelState.IsValid)
            {
                db.tDers.Add(tDers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tDers);
        }

        // GET: Ders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDers tDers = db.tDers.Find(id);
            if (tDers == null)
            {
                return HttpNotFound();
            }
            return View(tDers);
        }

        // POST: Ders/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dersID,dersAd")] tDers tDers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tDers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tDers);
        }

        // GET: Ders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDers tDers = db.tDers.Find(id);
            if (tDers == null)
            {
                return HttpNotFound();
            }
            return View(tDers);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tDers tDers = db.tDers.Find(id);
            db.tDers.Remove(tDers);
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
