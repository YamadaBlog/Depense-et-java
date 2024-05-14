using Dev.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces;

public interface ISuiviDepenseService
{
    bool CreateSuiviDepense(SuiviDepense suiviDepense);
    SuiviDepense GetSuiviDepenseById(int suiviDepenseId);
    ICollection<SuiviDepense> GetSuiviDepenses();
    bool UpdateSuiviDepense(SuiviDepense suiviDepense);
    bool DeleteSuiviDepense(SuiviDepense suiviDepense);
    bool Save();
}
