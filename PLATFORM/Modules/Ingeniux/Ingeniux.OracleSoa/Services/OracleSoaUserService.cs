using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingeniux.OracleSoa.Api.Models;

namespace Ingeniux.OracleSoa.Api.Services
{
	public class OracleSoaUserService : IUserService
	{
		public Task<UserServiceSearchResponse> SearchAsync(UserServiceSearchRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<bool> VerifyUserAsync(string login, string password)
		{
			throw new NotImplementedException();
		}
	}
}
