using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeniux.OracleSoa.Api.Models
{
	public class UserServiceSearchRequest: ListRequest
	{
		public string OrderBy { get; set; }

		public DateTime? CreatedFrom { get; set; }

		public DateTime? CreatedTo { get; set; }
	}

	public class User
	{
		public DateTime Created { get; set; }

		public string Login { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }
	}


	public class UserServiceSearchResponse: ListResponse<User>
	{

	}
}
