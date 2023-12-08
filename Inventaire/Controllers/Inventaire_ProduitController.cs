using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventaire.Models;

namespace Inventaire.Controllers
{
    public class Inventaire_ProduitController : Controller
    {
        private InventaireProduitsDBContext db = new InventaireProduitsDBContext();

        // GET: Inventaire_Produit
        public ActionResult Index(string Types, string searchString, string fabriquant)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Inventaire_Produits
                           orderby d.Type
                           select d.Type;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.Types = new SelectList(GenreLst);
            
            var GenreLstFab = new List<string>();

            var GenreQryFab = from d in db.Inventaire_Produits
                           orderby d.Fabriquant
                           select d.Fabriquant;

            GenreLstFab.AddRange(GenreQryFab.Distinct());
            ViewBag.Fab = new SelectList(GenreLstFab);

            var recherche = from m in db.Inventaire_Produits
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recherche = recherche.Where(s => s.Référence.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(Types))
            {
                recherche = recherche.Where(x => x.Type == Types);
            }
            if (!string.IsNullOrEmpty(fabriquant))
            {
                recherche = recherche.Where(x => x.Fabriquant == fabriquant);
            }
            return View(recherche.ToList());
        }

        // GET: Inventaire_Produit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_Produit inventaire_Produit = db.Inventaire_Produits.Find(id);
            if (inventaire_Produit == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_Produit);
        }

        // GET: Inventaire_Produit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventaire_Produit/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Référence,Fabriquant,Prix,Quantité,Localisation")] Inventaire_Produit inventaire_Produit)
        {
            if (ModelState.IsValid)
            {
                db.Inventaire_Produits.Add(inventaire_Produit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventaire_Produit);
        }

        // GET: Inventaire_Produit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_Produit inventaire_Produit = db.Inventaire_Produits.Find(id);
            if (inventaire_Produit == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_Produit);
        }

        // POST: Inventaire_Produit/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Référence,Fabriquant,Prix,Quantité,Localisation")] Inventaire_Produit inventaire_Produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventaire_Produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventaire_Produit);
        }

        // GET: Inventaire_Produit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_Produit inventaire_Produit = db.Inventaire_Produits.Find(id);
            if (inventaire_Produit == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_Produit);
        }

        // POST: Inventaire_Produit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventaire_Produit inventaire_Produit = db.Inventaire_Produits.Find(id);
            db.Inventaire_Produits.Remove(inventaire_Produit);
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
