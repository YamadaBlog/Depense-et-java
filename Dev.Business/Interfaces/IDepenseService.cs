﻿using Dev.Common.Models;
using Dev.Common.Resources;

namespace Dev.Business.Interfaces;

public interface IDepenseService
{
    bool CreateDepense(Depense depense);
    Depense GetDepenseById(int depenseId);
    ICollection<Depense> GetDepenses();
    bool UpdateDepense(Depense depense);
    bool DeleteDepense(Depense depense);
    bool DepenseExists(DepenseResource depenseCreate);
    bool DepenseExistsById(int depenseId);

    bool Save();
}

