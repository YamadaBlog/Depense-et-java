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
        public int DepenseId { get; set; }
        public string Statut { get; set; }
        public Depense Depense { get; set; }
    }
}
