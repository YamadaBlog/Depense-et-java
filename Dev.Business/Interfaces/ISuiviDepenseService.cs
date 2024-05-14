using Dev.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev.Common.Resources;

namespace Dev.Business.Interfaces;

public interface ISuiviDepenseService
{
    bool CreateSuiviDepense(SuiviDepense suiviDepense);
    SuiviDepense GetSuiviDepenseById(int suiviDepenseId);
    ICollection<Depense> GetDepensesBySuiviDepense(int suiviDepenseId);
    ICollection<SuiviDepense> GetSuiviDepenses();
    bool UpdateSuiviDepense(SuiviDepense suiviDepense);
    bool DeleteSuiviDepense(SuiviDepense suiviDepense);
    bool SuiviDepenseExists(SuiviDepenseResource suiviDepense);
    bool SuiviDepenseExistsById(int suiviDepenseId);
    bool Save();
}
