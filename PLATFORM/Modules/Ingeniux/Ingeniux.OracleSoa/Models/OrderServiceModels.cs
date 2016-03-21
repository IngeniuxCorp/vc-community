using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingeniux.OracleSoa.Models
{

	public class CreateOrderRequest
	{
		public Order Order { get; set; }
	}

	public class CreateOrderResponse
	{
		public string OrderId { get; set; }
	}

	public class LineItem
	{
		public string SkuId { get; set; }
		public int Quantity { get; set; }
	}

	public class Order
	{
		public Order()
		{
			this.LineItems = new List<LineItem>();
		}

		public string OuterId { get; set; }

		public List<LineItem> LineItems { get; set; }
	}
}