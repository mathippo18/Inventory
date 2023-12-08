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
    public class Inventaire_PCController : Controller
    {
        private InventaireOrdinateurDBContext db = new InventaireOrdinateurDBContext();

        // GET: Inventaire_PC
        public ActionResult Index(string Carte_graphique, string OS,string Processeur, string searchString, string fabriquant, string Taille, string Stockage, string Type_écran, string RAM, string Connectique)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Inventaire_PCs
                           orderby d.Processeur
                           select d.Processeur;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.Processeur = new SelectList(GenreLst);

            var GenreLstCG = new List<string>();

            var GenreQryCG = from d in db.Inventaire_PCs
                           orderby d.Carte_graphique
                           select d.Carte_graphique;

            GenreLstCG.AddRange(GenreQryCG.Distinct());
            ViewBag.Carte_graphique = new SelectList(GenreLstCG);

            var GenreLstOS = new List<string>();

            var GenreQryOS = from d in db.Inventaire_PCs
                           orderby d.OS
                           select d.OS;

            GenreLstOS.AddRange(GenreQryOS.Distinct());
            ViewBag.OS = new SelectList(GenreLstOS);

            var GenreLstFab = new List<string>();

            var GenreQryFab = from d in db.Inventaire_PCs
                              orderby d.Fabriquant
                              select d.Fabriquant;

            GenreLstFab.AddRange(GenreQryFab.Distinct());
            ViewBag.Fab = new SelectList(GenreLstFab);

            var GenreLstTaille = new List<string>();

            var GenreQryTaille = from d in db.Inventaire_PCs
                                 orderby d.Taille
                                 select d.Taille;

            GenreLstTaille.AddRange(GenreQryTaille.Distinct());
            ViewBag.Taille = new SelectList(GenreLstTaille);

            var GenreLstStockage = new List<string>();

            var GenreQryStockage = from d in db.Inventaire_PCs
                                   orderby d.Stockage
                                   select d.Stockage;

            GenreLstStockage.AddRange(GenreQryStockage.Distinct());
            ViewBag.Stockage = new SelectList(GenreLstStockage);

            var GenreLstType_écran = new List<string>();

            var GenreQryType_écran = from d in db.Inventaire_PCs
                                     orderby d.Type_écran
                                     select d.Type_écran;

            GenreLstType_écran.AddRange(GenreQryType_écran.Distinct());
            ViewBag.Type_écran = new SelectList(GenreLstType_écran);

            var GenreLstRAM = new List<string>();

            var GenreQryRAM = from d in db.Inventaire_PCs
                              orderby d.RAM
                              select d.RAM;

            GenreLstRAM.AddRange(GenreQryRAM.Distinct());
            ViewBag.RAM = new SelectList(GenreLstRAM);

            var GenreLstConnectique = new List<string>();

            var GenreQryConnectique = from d in db.Inventaire_PCs
                                      orderby d.Connectique
                                      select d.Connectique;

            GenreLstConnectique.AddRange(GenreQryConnectique.Distinct());
            ViewBag.Connectique = new SelectList(GenreLstConnectique);

            var recherche = from m in db.Inventaire_PCs
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recherche = recherche.Where(s => s.Référence.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(Processeur))
            {
                recherche = recherche.Where(x => x.Processeur == Processeur);
            }
            if (!string.IsNullOrEmpty(OS))
            {
                recherche = recherche.Where(x => x.OS == OS);
            }
            if (!string.IsNullOrEmpty(Carte_graphique))
            {
                recherche = recherche.Where(x => x.Carte_graphique == Carte_graphique);
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

        // GET: Inventaire_PC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_PC inventaire_PC = db.Inventaire_PCs.Find(id);
            if (inventaire_PC == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_PC);
        }

        // GET: Inventaire_PC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventaire_PC/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Référence,Fabriquant,Processeur,Taille,Stockage,Type_écran,RAM,Carte_graphique,OS,Connectique,Prix,Quantité,Localisation")] Inventaire_PC inventaire_PC)
        {
            if (ModelState.IsValid)
            {
                db.Inventaire_PCs.Add(inventaire_PC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventaire_PC);
        }

        // GET: Inventaire_PC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_PC inventaire_PC = db.Inventaire_PCs.Find(id);
            if (inventaire_PC == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_PC);
        }

        // POST: Inventaire_PC/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Référence,Fabriquant,Processeur,Taille,Stockage,Type_écran,RAM,Carte_graphique,OS,Connectique,Prix,Quantité,Localisation")] Inventaire_PC inventaire_PC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventaire_PC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventaire_PC);
        }

        // GET: Inventaire_PC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventaire_PC inventaire_PC = db.Inventaire_PCs.Find(id);
            if (inventaire_PC == null)
            {
                return HttpNotFound();
            }
            return View(inventaire_PC);
        }

        // POST: Inventaire_PC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventaire_PC inventaire_PC = db.Inventaire_PCs.Find(id);
            db.Inventaire_PCs.Remove(inventaire_PC);
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
