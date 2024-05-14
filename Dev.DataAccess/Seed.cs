using Dev.DataAccess.Data;
using Dev.Common.Models;
using Dev.DataAccess.Data;

namespace Dev.DataAccess
{
    public class Seed
    {
        private readonly DataContext context;

        public Seed(DataContext context)
        {
            this.context = context;
        }

        public void SeedDataContext()
        {
            // Vérifie si la base de données contient déjà des données
            if (context.Depenses.Any()|| context.SuiviDepenses.Any())
            {
                // La base de données a déjà été reinitialisée
                context.Depenses.RemoveRange(context.Depenses);
                context.SuiviDepenses.RemoveRange(context.SuiviDepenses);
                context.SaveChanges();
            }

            var depense1 = new Depense { Montant = 18, Description = "Jean", Date = DateTime.Now};
            var depense2 = new Depense { Montant = 19, Description = "Marie", Date = DateTime.Now};

            context.Depenses.AddRange(depense1, depense2);
            context.SaveChanges();

            var suiviDepense1 = new SuiviDepense { DepenseId = depense1.Id, Statut = "En attente" };
            var suiviDepense2 = new SuiviDepense { DepenseId = depense2.Id, Statut = "En attente" };

            context.SuiviDepenses.AddRange(suiviDepense1, suiviDepense2);
            context.SaveChanges();
        }
    }
}

