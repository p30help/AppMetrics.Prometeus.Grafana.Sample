using AppMetrics.Prometues.Metrics;
using AppMetrics.Prometues.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMetrics.Prometues.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderMetrics _orderMetrics;

        public OrdersController(ILogger<OrdersController> logger, IOrderMetrics orderMetrics)
        {
            _logger = logger;
            _orderMetrics = orderMetrics;
        }

        [HttpGet("GetOrders")]
        public IEnumerable<Order> GetOrders()
        {
            // Add counter to metrics
            _orderMetrics.IncreamentGetOrder();

            return new List<Order>()
            {
                new Order(){ OrderName= "Order1" },
                new Order(){ OrderName= "Order2" },
                new Order(){ OrderName= "Order3" },
                new Order(){ OrderName= "Order4" }
            };
        }

        [HttpPost("CreateOrder")]
        public Task CreateOrder(Order order)
        {
            // Add counter to metrics
            _orderMetrics.IncreamentCreateOrder();

            return Task.CompletedTask;
        }
    }
}