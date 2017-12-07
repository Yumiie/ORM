using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibraryProjet;

namespace WebApplicationProjet.Controllers
{
    public class MagasinsController : Controller
    {
        private SaladesContext db = new SaladesContext();

        // GET: Magasins
        public ActionResult Index()
        {
            return View(db.Magasins.ToList());
        }

        // GET: Magasins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magasin magasin = db.Magasins.Find(id);
            if (magasin == null)
            {
                return HttpNotFound();
            }
            return View(magasin);
        }

        // GET: Magasins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Magasins/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom")] Magasin magasin)
        {
            if (ModelState.IsValid)
            {
                db.Magasins.Add(magasin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(magasin);
        }

        // GET: Magasins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magasin magasin = db.Magasins.Find(id);
            if (magasin == null)
            {
                return HttpNotFound();
            }
            return View(magasin);
        }

        // POST: Magasins/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom")] Magasin magasin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magasin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(magasin);
        }

        // GET: Magasins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magasin magasin = db.Magasins.Find(id);
            if (magasin == null)
            {
                return HttpNotFound();
            }
            return View(magasin);
        }

        // POST: Magasins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Magasin magasin = db.Magasins.Find(id);
            db.Magasins.Remove(magasin);
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
