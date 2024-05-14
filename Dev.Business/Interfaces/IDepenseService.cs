using Dev.Common.Models;
using Dev.Common.Resources;

namespace Dev.Business.Interfaces;

public interface IDepenseService
{
    /// <summary>
    /// Create a depense
    /// </summary>
    /// <param name="depense"></param>
    /// <returns>Save()</returns>
    bool CreateDepense(Depense depense);
    /// <summary>
    /// Get element by Id 
    /// </summary>
    /// <param name="depenseId"></param>
    /// <returns></returns>
    Depense GetDepenseById(int depenseId);
    /// <summary>
    /// Get all the collection of depenses
    /// </summary>
    /// <returns></returns>
    ICollection<Depense> GetDepenses();
    /// <summary>
    /// Update depense by the object depense
    /// </summary>
    /// <param name="depense"></param>
    /// <returns></returns>
    bool UpdateDepense(Depense depense);
    /// <summary>
    /// Delete the Depense
    /// </summary>
    /// <param name="depense"></param>
    /// <returns></returns>
    bool DeleteDepense(Depense depense);
    /// <summary>
    /// Verification if the depense exist in the database
    /// </summary>
    /// <param name="depenseCreate"></param>
    /// <returns></returns>
    bool DepenseExists(DepenseResource depenseCreate);
    /// <summary>
    /// Verification if depense exist by the id 
    /// </summary>
    /// <param name="depenseId"></param>
    /// <returns></returns>
    bool DepenseExistsById(int depenseId);
    /// <summary>
    /// Save information in the database
    /// </summary>
    /// <returns></returns>
    bool Save();
}

