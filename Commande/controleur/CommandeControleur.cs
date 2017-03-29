using GestionCommande.dao;
using GestionCommande.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.controleur
{
    class CommandeControleur:Controleur
    {
        private ClientDao ClientDao { get; }
        private ProduitDao ProduitDao { get; }
        private CommandeDao CommandeDao { get; }

        public CommandeControleur()
        {
            this.ClientDao = new ClientDao();
            this.ProduitDao = new ProduitDao();
            this.CommandeDao = new CommandeDao();
        }

        public void CreerCommande(Client client,ICollection<LigneCommande> ligneCmd)
        {
            Commande cmd = new Commande { Id = CommandeDao.Commandes.Count + 1, Client = client, LignesCommande = ligneCmd };
            foreach (LigneCommande ligne in ligneCmd)
            {
                ligne.Commande = cmd;
            }
            client.Commandes.Add(cmd);
            CommandeDao.AjouterCommande(cmd);
        }

        public void CreerClient(string n, string p, string m)
        {
            Client clt = new Client { Id = ClientDao.Clients.Count + 1, Nom = n, Prenom = p, Mail = m};
            ClientDao.AjouterClient(clt);
        }

        public void CreerProduit(string d, int p)
        {
            Produit prd = new Produit { Id = ProduitDao.Produits.Count + 1, Designation = d, Prix = p };
            ProduitDao.AjouterProduit(prd);
        }

        public ICollection<Client>  GetClients()
        {
            return ClientDao.Clients;
        }

        public ICollection<Produit> GetProduits()
        {
            return ProduitDao.Produits;
        }

        public ICollection<Commande> GetCommandes()
        {
            return CommandeDao.Commandes;
        }
    }
}
