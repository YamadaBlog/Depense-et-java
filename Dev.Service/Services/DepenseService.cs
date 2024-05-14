using Dev.Business.Interfaces;
using Dev.Common.Models;
using Dev.Common.Resources;
using Dev.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Service.Services;

public class DepenseService : IDepenseService
{
    private readonly DataContext _context;

    public DepenseService(DataContext context)
    {
        _context = context;
    }

    public bool CreateDepense(Depense depense)
    {
        _context.Add(depense);

        return Save();
    }

    public ICollection<Depense> GetDepenses()
    {
        return _context.Depenses.OrderBy(p => p.Id).ToList();
    }
    public Depense GetDepenseById(int depenseId)
    {
        return _context.Depenses.Where(c => c.Id == depenseId).FirstOrDefault();
    }

    public bool UpdateDepense(Depense depense)
    {
        _context.Update(depense);
        return Save();
    }
    public bool DeleteDepense(Depense depense)
    {
        _context.Remove(depense);
        return Save();
    }

    public bool DepenseExists(DepenseResource depenseCreate)
    {
        return _context.Depenses.Any(r => r.Id == depenseCreate.Id);
    }

    public bool DepenseExistsById(int depenseId)
    {
        return _context.Depenses.Any(r => r.Id == depenseId);

    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}
