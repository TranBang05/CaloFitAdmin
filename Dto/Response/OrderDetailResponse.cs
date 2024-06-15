using AdminApi.Models;

namespace AdminApi.Dto.Response
{
    public class OrderDetailResponse
    {
       
        //public virtual IngredientResponse? Product { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? image {  get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

    }
}
