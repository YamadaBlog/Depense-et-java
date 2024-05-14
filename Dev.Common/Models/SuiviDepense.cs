using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Common.Models
{
    public class SuiviDepense
    {
        public int Id { get; set; }
        public string Statut { get; set; }

        public ICollection<Depense> Depenses { get; set; }
    }
}
