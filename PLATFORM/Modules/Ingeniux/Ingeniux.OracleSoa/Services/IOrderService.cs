using Ingeniux.OracleSoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeniux.OracleSoa.Services
{
	public interface IOrderService
	{
		CreateOrderResponse CreateOrder(CreateOrderRequest request);
	}
}
