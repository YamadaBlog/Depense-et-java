using Dev.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces;

public interface ISuiviDepenseService
{
    bool CreateSuiviDepense(ISuiviDepenseService suiviDepense);
    ISuiviDepenseService GetSuiviDepenseById(int suiviDepenseId);
    ICollection<ISuiviDepenseService> GetSuiviDepenses();
    ICollection<Depense> GetDepensesBySuiviDepense(int suiviDepenseId);
    bool UpdateSuiviDepense(ISuiviDepenseService suiviDepense);
    bool DeleteSuiviDepense(ISuiviDepenseService suiviDepense);
}
