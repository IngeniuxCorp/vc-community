using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ingeniux.OracleSoa.Models;
using System.Threading.Tasks;

namespace Ingeniux.OracleSoa.Services
{
	public class OracleSoaOrderService : IOrderService
	{
		public OracleSoaOrderService()
		{

		}

		public CreateOrderResponse CreateOrder(CreateOrderRequest request)
		{
			if (request == null)
				throw new ArgumentNullException("request");

			throw new NotImplementedException();
		}
	}
}