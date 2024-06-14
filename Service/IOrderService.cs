using AdminApi.Dto.Response;

namespace AdminApi.Service
{
    public interface IOrderService
    {
        IQueryable<OrderResponse> GetOrders();

        public List<OrderDetailResponse> GetOrderDetails(int orderId);

        public int GetTotalOrder();
    }
}
