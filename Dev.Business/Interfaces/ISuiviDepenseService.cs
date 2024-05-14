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
    /// <summary>
    /// Create an expense tracking
    /// </summary>
    /// <param name="suiviDepense"></param>
    /// <returns></returns>
    bool CreateSuiviDepense(SuiviDepense suiviDepense);
    /// <summary>
    /// Gel an expense tracking by id
    /// </summary>
    /// <param name="suiviDepenseId"></param>
    /// <returns></returns>
    SuiviDepense GetSuiviDepenseById(int suiviDepenseId);
    /// <summary>
    /// Get all expenses for one expenses tracker
    /// </summary>
    /// <param name="suiviDepenseId"></param>
    /// <returns></returns>
    ICollection<Depense> GetDepensesBySuiviDepense(int suiviDepenseId);
    /// <summary>
    /// Get all the expenses tracking
    /// </summary>
    /// <returns></returns>
    ICollection<SuiviDepense> GetSuiviDepenses();
    /// <summary>
    /// Update one expense tracker
    /// </summary>
    /// <param name="suiviDepense"></param>
    /// <returns></returns>
    bool UpdateSuiviDepense(SuiviDepense suiviDepense);
    /// <summary>
    /// Delete one expense tracker
    /// </summary>
    /// <param name="suiviDepense"></param>
    /// <returns></returns>
    bool DeleteSuiviDepense(SuiviDepense suiviDepense);
    /// <summary>
    /// verify if one depense tracker exist
    /// </summary>
    /// <param name="suiviDepense"></param>
    /// <returns></returns>
    bool SuiviDepenseExists(SuiviDepenseResource suiviDepense);
    /// <summary>
    /// Verify if one depense tracker exist by 
    /// </summary>
    /// <param name="suiviDepenseId"></param>
    /// <returns></returns>
    bool SuiviDepenseExistsById(int suiviDepenseId);
    /// <summary>
    /// Start the save in the database
    /// </summary>
    /// <returns></returns>
    bool Save();
}
