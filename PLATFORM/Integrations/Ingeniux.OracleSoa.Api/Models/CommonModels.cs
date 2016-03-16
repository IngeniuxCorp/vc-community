using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeniux.OracleSoa.Api.Models
{
	public class ListRequest
	{
		public int Take { get; set; }
		public int Skeep { get; set; }
	}

	public class ListResponse<T>
	{
		public T[] Items { get; set; }
		public int TotalCount { get; set; }
	}
}
