using AdminApi.Dto.Response;
using AdminApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdminApi.Service.Impl
{
    public class OrderService : IOrderService
    {
        private readonly CalofitDBContext _context;
        private readonly IMapper _mapper;

        public OrderService(CalofitDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        public OrderDetailResponse GetOrderDetails(int orderId)
        {
     
            var order = _context.Orders
                .Include(o => o.OrderDetails) 
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
            {
                
                throw new InvalidOperationException($"Order with ID {orderId} not found.");
            }

           
            var orderDetailResponse = _mapper.Map<OrderDetailResponse>(order);

            return orderDetailResponse;
        }

        public IQueryable<OrderResponse> GetOrders()
        {
            var orders = _context.Orders.AsQueryable();
            return _mapper.ProjectTo<OrderResponse>(orders);
        }

        public int GetTotalOrder()
        {
            return _context.Orders.Count();
        }

        List<OrderDetailResponse> IOrderService.GetOrderDetails(int orderId)
        {
            var orderDetails = _context.OrderDetails
            .Where(od => od.Orderid == orderId)
            .Include(od => od.Product) // Include Product to map ProductName
            .ToList();

            var orderDetailResponses = _mapper.Map<List<OrderDetailResponse>>(orderDetails);

            return orderDetailResponses;
        }
    }
}
