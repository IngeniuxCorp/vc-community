﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingeniux.OracleSoa.Api.Models;

namespace Ingeniux.OracleSoa.Services
{
	public class OracleSoaUserService : IUserService
	{
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

			throw new NotImplementedException();
		}
	}
}
