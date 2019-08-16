using Microsoft.AspNetCore.Mvc;
using OrderSystem.Model;
using OrderSystem.Models;
using OrderSystem.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/json")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _service;

		public OrdersController(IOrderService service)
		{
			this._service = service;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Orders>> Get(string id)
		{
			return new ActionResult<IEnumerable<Orders>>(_service.GetOrders(id));
		}

		[HttpPost]
		[Produces("application/xml")]
		public async Task<IActionResult> Create([FromBody]OrdersXML orders)
		{
			await _service.AddOrders(orders.Order);

			return Ok();
		}

		[HttpPut("setStatus/{orderId:long}/{status:int}")]
		public async Task<ActionResult<Orders>> Status(long orderId, int status)
		{
			var order = await _service.SetStatus(orderId, status);

			return order;
		}

		[HttpPut("setInvoice/{orderId:long}/{invoice:int}")]
		public async Task<ActionResult<Orders>> Invoice(long orderId, int invoice)
		{

			var order = await _service.SetInvoice(orderId, invoice);

			return order;
		}
	}
}