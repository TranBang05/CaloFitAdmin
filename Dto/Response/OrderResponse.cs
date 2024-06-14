using AdminApi.Models;

namespace AdminApi.Dto.Response
{
    public class OrderResponse
    {
        
        public int Id { get; set; }
  
        public DateTime? Date { get; set; }
       
        public string? CustomerName { get; set; }

        public decimal? TotalAmount { get; set; }

        public List<OrderDetailResponse>? OrderDetails { get; set; }


    }
}
