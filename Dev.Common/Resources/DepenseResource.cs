using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Common.Resources
{
    public class DepenseResource
    {
        public int Id { get; set; }
        public int SuiviDepenseId { get; set; }
        public int Montant { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
