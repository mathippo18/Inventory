using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventaire.Models
{
    public class Inventaire_Produit
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }

        public string Référence { get; set; }
        public string Fabriquant { get; set; }
        public string Prix { get; set; }
        public string Quantité { get; set; }
        public string Localisation { get; set; }

    }
    public class Inventaire_PC
    {

        [Key]
        public int Id { get; set; }
        public string Référence { get; set; }
        public string Fabriquant { get; set; }
        public string Processeur { get; set; }
        public string Taille { get; set; }
        public string Stockage { get; set; }
        public string Type_écran { get; set; }
        public string RAM { get; set; }
        public string Carte_graphique { get; set; }
        public string OS { get; set; }
        public string Connectique { get; set; }
        public string Prix { get; set; }
        public string Quantité { get; set; }
        public string Localisation { get; set; }

    }
    public class Inventaire_téléphone
    {
        [Key]
        public int Id { get; set; }
        public string Référence { get; set; }
        public string Fabriquant { get; set; }
        public string Processeur { get; set; }
        public string Taille { get; set; }
        public string Stockage { get; set; }
        public string Type_écran { get; set; }
        public string RAM { get; set; }
        public string Connectique { get; set; }
        public string Prix { get; set; }
        public string Quantité { get; set; }
        public string Localisation { get; set; }


    }
    public class InventaireProduitsDBContext : DbContext
    {
        public DbSet<Inventaire_Produit> Inventaire_Produits { get; set; }
    }
    public class InventaireOrdinateurDBContext : DbContext
    {
        public DbSet<Inventaire_PC> Inventaire_PCs { get; set; }
    }
    public class InventaireTéléphoneDBContext : DbContext
    {
        public DbSet<Inventaire_téléphone> Inventaire_téléphones { get; set; }
    }
}