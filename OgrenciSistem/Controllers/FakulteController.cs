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
    public class FakulteController : Controller
    {
        private OgrencibilgisistemidbEntities db = new OgrencibilgisistemidbEntities();

        // GET: Fakulte
        public ActionResult Index()
        {
            return View(db.tFakulte.ToList());
        }

        // GET: Fakulte/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFakulte tFakulte = db.tFakulte.Find(id);
            if (tFakulte == null)
            {
                return HttpNotFound();
            }
            return View(tFakulte);
        }

        // GET: Fakulte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fakulte/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fakulteID,fakulteAd")] tFakulte tFakulte)
        {
            if (ModelState.IsValid)
            {
                db.tFakulte.Add(tFakulte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tFakulte);
        }

        // GET: Fakulte/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFakulte tFakulte = db.tFakulte.Find(id);
            if (tFakulte == null)
            {
                return HttpNotFound();
            }
            return View(tFakulte);
        }

        // POST: Fakulte/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fakulteID,fakulteAd")] tFakulte tFakulte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tFakulte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tFakulte);
        }

        // GET: Fakulte/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFakulte tFakulte = db.tFakulte.Find(id);
            if (tFakulte == null)
            {
                return HttpNotFound();
            }
            return View(tFakulte);
        }

        // POST: Fakulte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tFakulte tFakulte = db.tFakulte.Find(id);
            db.tFakulte.Remove(tFakulte);
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
