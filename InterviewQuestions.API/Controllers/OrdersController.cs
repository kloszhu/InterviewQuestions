using InterviewQuestions.BLL;
using InterviewQuestions.ViewModel.Orders;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestions.API.Controllers
{
    /// <summary>
    /// 订单服务
    /// </summary>
    [ApiController]
    [Route("api")]
    public class OrdersController : BaseController
    {
        private IOrdersBLL ordersBLL;

        public OrdersController(IOrdersBLL ordersBLL)
        {
            this.ordersBLL = ordersBLL;
        }

        [HttpGet("PostOrder")]
        public IActionResult PostOrder([FromQuery]string code,[FromBody]OrderSearchViewModel order)
        {
            return Result(ordersBLL.PostOrder(order, code));
        }
        [HttpGet("GetOrders")]
        public IActionResult GetOrders([FromQuery]OrderQueryViewModel order) {
            return Result(ordersBLL.GetOrder(order));
        }
    }
}
