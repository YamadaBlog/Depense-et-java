using System.ComponentModel.DataAnnotations.Schema;

namespace Dev.Common.Models
{
    public class Depense
    {
        public int Id { get; set; }
        [ForeignKey("SuiviDepense")]
        public int SuiviDepenseId { get; set; }
        public SuiviDepense SuiviDepense { get; set; }
        public int Montant { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}
