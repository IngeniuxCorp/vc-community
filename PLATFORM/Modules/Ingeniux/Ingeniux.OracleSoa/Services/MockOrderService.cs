using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ingeniux.OracleSoa.Models;
using System.Threading.Tasks;

namespace Ingeniux.OracleSoa.Services
{
	public class MockOrderService : IOrderService
	{
		public MockOrderService()
		{

		}

		public CreateOrderResponse CreateOrder(CreateOrderRequest request)
		{
			if (request == null)
				throw new ArgumentNullException("response");
			if (request.Order == null)
				throw new ArgumentNullException("request.Order");

			var response = new CreateOrderResponse { OrderId = string.Format("{0}/DEMO", request.Order.OuterId) };
			
			return response;
		}
	}
}