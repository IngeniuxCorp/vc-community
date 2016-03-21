using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingeniux.OracleSoa.Api.Models;

namespace Ingeniux.OracleSoa.Services
{
	public class MockUserService : IUserService
	{
		public MockUserService()
		{

		}

		public UserServiceSearchResponse Search(UserServiceSearchRequest request)
		{
			throw new NotImplementedException();
		}

		public bool VerifyUser(string login, string password)
		{
			if (login == null)
				throw new ArgumentNullException("login");
			if (password == null)
				throw new ArgumentNullException("password");

			if (string.Equals(login, "success@demo.com"))
			{
				return true;
			}

			return false;
		}
	}
}
