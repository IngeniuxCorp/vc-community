using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ingeniux.OracleSoa.Services;

namespace Ingeniux.OracleSoa.Test
{
	[TestClass]
	public class OrderServiceTest
	{
		private IOrderService _service;

		[TestInitialize]
		public void Initialize()
		{
			_service = new OracleSoaOrderService();
		}

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void CreateOrderNotImplemented()
		{
			var response = _service.CreateOrder(null);
		}

	}
}
