using GestionCommande.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.controleur
{
    public interface Controleur
    {

        void CreerCommande(Client client, ICollection<LigneCommande> ligneCmd);

        void CreerClient(string n, string p, string m);

        void CreerProduit(string d, int p);

        ICollection<Client> GetClients();

        ICollection<Produit> GetProduits();

        ICollection<Commande> GetCommandes();
    }
}
