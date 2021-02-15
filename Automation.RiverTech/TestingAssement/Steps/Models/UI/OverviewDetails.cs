namespace TestingAssessment.Steps.Models.UI
{
    public class OverviewDetails
    {
        public OverviewDetails(decimal total, decimal tax, decimal itemTotal)
        {
            Total = total;
            Tax = tax;
            ItemTotal = itemTotal;
        }

        public decimal Total { get; }
        public decimal Tax { get; }
        public decimal ItemTotal { get; }
    }
}
