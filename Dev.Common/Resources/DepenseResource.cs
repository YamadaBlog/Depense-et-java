using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Common.Resources
{
    public class DepenseResource
    {
        public int id { get; set; }
        public int montant { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
    }
}
