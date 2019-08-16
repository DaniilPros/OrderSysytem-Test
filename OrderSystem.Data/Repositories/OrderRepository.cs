using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;

namespace OrderSystem.Repositories
{

	public class OrderRepository : IOrderRepository
	{
		private readonly OrdersDBContext _context;

		public OrderRepository(OrdersDBContext context)
		{
			_context = context;
		}

		public async Task AddOrders(IEnumerable<Orders> orders)
		{
			foreach (var order in orders)
			{
				_context.Orders.Add(order);
				if (_context.Orders.Any(o => o.OxId.Equals(order.OxId)))
					throw new Exception("The order with the same id is exist in db");//

			}
			await _context.SaveChangesAsync();
		}

		public IQueryable<Orders> GetOrders()
		{
			return _context.Orders.Include(o => o.BillingAddresses)
				.Include(o => o.Payments)
				.Include(o => o.Articles);
		}

		public IQueryable<Orders> GetOrders(string id)
		{
			return GetOrders().Where(order => order.OxId.ToString().Contains(id));
		}

		public Task<OrderStatuses> GetStatusId(string name)
		{
			return _context.OrderStatuses.FirstOrDefaultAsync(os => os.Name.Equals(name));
		}

		public  async Task<Orders> SetInvoice(long orderId, int invoice)
		{
			var order = await GetOrderById(orderId);

			order.InvoiceNumber = invoice;

			await _context.SaveChangesAsync();
			return order;
		}

		private async Task<Orders> GetOrderById(long orderId)
		{
			var order = await GetOrders().SingleOrDefaultAsync(ord => ord.OxId == orderId);
			if (order == null) throw new Exception($"Not found order with id:{orderId}");
			return order;
		}

		public async Task<Orders> SetStatus(long orderId, byte statusId)
		{
			var order = await GetOrderById(orderId);

			order.OrderStatus = statusId;

			await _context.SaveChangesAsync();
			return order;

		}
	}
}
