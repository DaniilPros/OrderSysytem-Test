using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSystem.Convertors;
using OrderSystem.Model;
using OrderSystem.Models;
using OrderSystem.Repositories;

namespace OrderSystem.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IOrderConvertor _orderConvertor;

		public OrderService(IOrderRepository orderRepository,
			IOrderConvertor orderConvertor)
		{
			this._orderRepository = orderRepository;
			this._orderConvertor = orderConvertor;
		}

		public async Task AddOrders(IEnumerable<Order> orders)
		{

			/// here must be a mapper
			var os = orders.Select(ord => _orderConvertor.Convert(ord)).ToList();
			await _orderRepository.AddOrders(os);
		}

		public IEnumerable<Orders> GetOrders()
		{
			return _orderRepository.GetOrders().AsEnumerable();
		}

		public IEnumerable<Orders> GetOrders(string id)
		{
			return string.IsNullOrEmpty(id) ? GetOrders() : _orderRepository.GetOrders(id).AsEnumerable();
		}

		public Task<Orders> SetInvoice(long orderId, int invoice)
		{
			return _orderRepository.SetInvoice(orderId, invoice);
		}

		public async Task<Orders> SetStatus(long orderId, int status)
		{
			var stat = await _orderRepository.GetStatusId(GetStatusName(status));

			return await _orderRepository.SetStatus(orderId, stat.Id);
		}

		private string GetStatusName(int status)
		{
			switch (status)
			{
				case 1:
					return "Processed";
				case 2:
					return "Unprocessed";
				case 3:
					return "Canceled";
				default:
					throw new Exception($"No status with this code: {status}");
			}
		}
	}
}
