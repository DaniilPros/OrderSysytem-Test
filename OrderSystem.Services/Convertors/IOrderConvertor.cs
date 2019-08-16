using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Convertors
{
	public interface IOrderConvertor
	{
		Models.Orders Convert(Model.Order order);

	}
}
