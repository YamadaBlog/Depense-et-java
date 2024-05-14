using Dev.Common.Models;

namespace Dev.Business.Interfaces;

public interface IDepense
{
    void AjouterDepense(Depense depense);
    void AfficherDepenses();
    void MettreAJourDepense(int id, Depense depense);
    void SupprimerDepense(int id);
}

