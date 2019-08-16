using OrderSystem.Model;
using OrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Services
{
	public interface IOrderService
	{
		Task AddOrders(IEnumerable<Order> orders);
		IEnumerable<Orders> GetOrders();
		IEnumerable<Orders> GetOrders(string id);
		Task<Orders> SetStatus(long orderId, int status);
		Task<Orders> SetInvoice(long orderId, int invoice);
	}
}
