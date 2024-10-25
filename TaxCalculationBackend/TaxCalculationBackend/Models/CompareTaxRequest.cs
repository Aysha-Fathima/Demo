namespace TaxCalculationBackend.Models
{
    public class CompareTaxRequest
    {
        public int UserId { get; set; }
        public int FirstYear { get; set; }
        public int SecondYear { get; set; }
    }
}
