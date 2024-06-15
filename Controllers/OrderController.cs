using AdminApi.Service;
using AdminApi.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _order;
        public OrderController(IOrderService order)
        {
            _order = order;
        }

        [HttpGet]
		[EnableQuery]
		public IActionResult Get()
        {
            return Ok(_order.GetOrders());
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderDetail(int orderId)
        {
            var orderDetails = _order.GetOrderDetails(orderId);
            if (orderDetails == null || !orderDetails.Any())
            {
                return NotFound($"Order with ID {orderId} not found or has no details.");
            }

            return Ok(orderDetails);
        }

        

        [HttpGet("total")]
        public IActionResult GetTotalOrder()
        {
            var total = _order.GetTotalOrder();
            return Ok(total);
        }
    }
}
