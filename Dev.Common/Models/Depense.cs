namespace Dev.Common.Models
{
    public class Depense
    {
        public int Id { get; set; }
        public int Montant { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public ICollection<SuiviDepense> SuiviDepenses { get; set; }

    }
}
