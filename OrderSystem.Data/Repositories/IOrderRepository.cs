using OrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Repositories
{
	public interface IOrderRepository
	{
		Task AddOrders(IEnumerable<Orders> orders);
		IQueryable<Orders> GetOrders();
		IQueryable<Orders> GetOrders(string id);
		Task<OrderStatuses> GetStatusId(string name);
		Task<Orders> SetStatus(long orderId,byte statusId);
		Task<Orders> SetInvoice(long orderId, int invoice);
	}
}
