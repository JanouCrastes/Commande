using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionCommande.controleur;
using System.Linq;
using GestionCommande.model;

namespace Commandes.Tests
{
    /// <summary>
    /// Description résumée pour Tests
    /// </summary>
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CreerClient()
        {
            Controleur controleur = new CommandeControleur();
            controleur.CreerClient("Crastes", "Janou", "janou.crastes@epsi.fr");
            Assert.AreEqual(controleur.GetClients().Last().Prenom, "Janou");
            Assert.AreEqual(controleur.GetClients().Last().Nom, "Crastes");
            Assert.AreEqual(controleur.GetClients().Last().Mail, "janou.crastes@epsi.fr");
        }

        [TestMethod]
        public void CreerProduit()
        {
            Controleur controleur = new CommandeControleur();
            controleur.CreerProduit("Banane", 15);
            Assert.AreEqual(controleur.GetProduits().Last().Designation, "Banane");
            Assert.AreEqual(controleur.GetProduits().Last().Prix, 15);
        }

        [TestMethod]
        public void CreerCommande()
        {
            Controleur controleur = new CommandeControleur();
            List<LigneCommande> Produits = new List<LigneCommande>();
            Produits.Add(new LigneCommande() { Produit = controleur.GetProduits().Last(), Quantite = 5 });
            Produits.Add(new LigneCommande() { Produit = controleur.GetProduits().First(), Quantite = 10 });
            controleur.CreerCommande(controleur.GetClients().Last(), Produits);
            Assert.AreEqual(controleur.GetCommandes().Last().Client, controleur.GetClients().Last());
            Assert.AreEqual(controleur.GetCommandes().Last().LignesCommande, Produits);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

    }
}
