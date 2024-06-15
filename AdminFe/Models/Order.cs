namespace AdminFe.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string? CustomerName { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}
