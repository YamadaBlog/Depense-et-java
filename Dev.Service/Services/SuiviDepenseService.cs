using Dev.DataAccess.Data;
using Dev.Business.Interfaces;
using Dev.Common.Models;
using Dev.Common.Resources;
using Dev.DataAccess.Data;


namespace Dev.Service.Services;

public class SuiviDepenseService : ISuiviDepenseService
{
    private readonly DataContext _context;

    public SuiviDepenseService(DataContext context)
    {
        _context = context;
    }

    public bool CreateSuiviDepense(SuiviDepense suiviDepense)
    {
        _context.Add(suiviDepense);

        return Save();
    }

    public ICollection<SuiviDepense> GetSuiviDepenses()
    {
        return _context.SuiviDepenses.OrderBy(p => p.Id).ToList();
    }
    public SuiviDepense GetSuiviDepenseById(int suiviDepenseId)
    {
        return _context.SuiviDepenses.Where(c => c.Id == suiviDepenseId).FirstOrDefault();
    }

    public bool UpdateSuiviDepense(SuiviDepense suiviDepense)
    {
        _context.Update(suiviDepense);
        return Save();
    }
    public bool DeleteSuiviDepense(SuiviDepense suiviDepense)
    {
        _context.Remove(suiviDepense);
        return Save();
    }

    public bool SuiviDepenseExists(SuiviDepenseResource suiviDepenseCreate)
    {
        if (_context.SuiviDepenses.Any(r => r.Id == suiviDepenseCreate.Id))
        {
            return true;
        }
        else
        {
            return (!_context.SuiviDepenses.Any(r => r.Id == suiviDepenseCreate.Id)) && (!_context.Depenses.Any(r => r.Id == suiviDepenseCreate.DepenseId));
        }
    }
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}
