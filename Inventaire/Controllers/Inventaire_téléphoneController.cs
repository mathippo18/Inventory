using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Inventaire.Models;

namespace Inventaire.Controllers
{
    public class Inventaire_téléphoneController : Controller
    {
        private InventaireTéléphoneDBContext db = new InventaireTéléphoneDBContext();

        // GET: Inventaire_téléphone
        public ActionResult Index(string Processeur, string searchString, string fabriquant,string Taille, string Stockage, string Type_écran, string RAM, string Connectique)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Inventaire_téléphones
                           orderby d.Processeur
                           select d.Processeur;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.Processeur = new SelectList(GenreLst);

            var GenreLstFab = new List<string>();

            var GenreQryFab = from d in db.Inventaire_téléphones
                              orderby d.Fabriquant
                              select d.Fabriquant;

            GenreLstFab.AddRange(GenreQryFab.Distinct());
            ViewBag.Fab = new SelectList(GenreLstFab);

            var GenreLstTaille = new List<string>();

            var GenreQryTaille = from d in db.Inventaire_téléphones
                                  orderby d.Taille
                                 select d.Taille;

            GenreLstTaille.AddRange(GenreQryTaille.Distinct());
            ViewBag.Taille = new SelectList(GenreLstTaille);

            var GenreLstStockage = new List<string>();

            var GenreQryStockage = from d in db.Inventaire_téléphones
                              orderby d.Stockage
                                   select d.Stockage;

            GenreLstStockage.AddRange(GenreQryStockage.Distinct());
            ViewBag.Stockage = new SelectList(GenreLstStockage);

            var GenreLstType_écran = new List<string>();

            var GenreQryType_écran = from d in db.Inventaire_téléphones
                           orderby d.Type_écran
                                     select d.Type_écran;

            GenreLstType_écran.AddRange(GenreQryType_écran.Distinct());
            ViewBag.Type_écran = new SelectList(GenreLstType_écran);

            var GenreLstRAM = new List<string>();

            var GenreQryRAM = from d in db.Inventaire_téléphones
                              orderby d.RAM
                              select d.RAM;

            GenreLstRAM.AddRange(GenreQryRAM.Distinct());
            ViewBag.RAM = new SelectList(GenreLstRAM);

            var GenreLstConnectique = new List<string>();

            var GenreQryConnectique = from d in db.Inventaire_téléphones
                              orderby d.Connectique
                              select d.Connectique;

            GenreLstConnectique.AddRange(GenreQryConnectique.Distinct());
            ViewBag.Connectique = new SelectList(GenreLstConnectique);

            var recherche = from m in db.Inventaire_téléphones
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recherche = recherche.Where(s => s.Référence.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(Processeur))
            {
                recherche = recherche.Where(x => x.Processeur == Processeur);
            }
            if (!string.IsNullOrEmpty(fabriquant))
            {
                recherche = recherche.Where(x => x.Fabriquant == fabriquant);
            }
            if (!string.IsNullOrEmpty(Taille))
            {
                recherche = recherche.Where(x => x.Taille == Taille);
            }
            if (!string.IsNullOrEmpty(Stockage))
            {
                recherche = recherche.Where(x => x.Stockage == Stockage);
            }
            if (!string.IsNullOrEmpty(Type_écran))
            {
                recherche = recherche.Where(x => x.Type_écran == Type_écran);
            }
            if (!string.IsNullOrEmpty(RAM))
            {
                recherche = recherche.Where(x => x.RAM == RAM);
            }
            if (!string.IsNullOrEmpty(Connectique))
            {
                recherche = recherche.Where(x => x.Connectique == Connectique);
            }
            return View(recherche.ToList());
        }

        // GET: Inventaire_téléphone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_téléphone inventaire_téléphone = db.Inventaire_téléphones.Find(id);
            if (inventaire_téléphone == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_téléphone);
        }

        // GET: Inventaire_téléphone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventaire_téléphone/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Référence,Fabriquant,Processeur,Taille,Stockage,Type_écran,RAM,Connectique,Prix,Quantité,Localisation")] Inventaire_téléphone inventaire_téléphone)
        {
            if (ModelState.IsValid)
            {
                db.Inventaire_téléphones.Add(inventaire_téléphone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventaire_téléphone);
        }

        // GET: Inventaire_téléphone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_téléphone inventaire_téléphone = db.Inventaire_téléphones.Find(id);
            if (inventaire_téléphone == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_téléphone);
        }

        // POST: Inventaire_téléphone/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Référence,Fabriquant,Processeur,Taille,Stockage,Type_écran,RAM,Connectique,Prix,Quantité,Localisation")] Inventaire_téléphone inventaire_téléphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventaire_téléphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventaire_téléphone);
        }

        // GET: Inventaire_téléphone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_téléphone inventaire_téléphone = db.Inventaire_téléphones.Find(id);
            if (inventaire_téléphone == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_téléphone);
        }

        // POST: Inventaire_téléphone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventaire_téléphone inventaire_téléphone = db.Inventaire_téléphones.Find(id);
            db.Inventaire_téléphones.Remove(inventaire_téléphone);
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
