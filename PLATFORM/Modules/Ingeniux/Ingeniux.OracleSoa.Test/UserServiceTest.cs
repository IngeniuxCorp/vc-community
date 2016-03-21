using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ingeniux.OracleSoa.Services;

namespace Ingeniux.OracleSoa.Test
{
	[TestClass]
	public class UserServiceTest
	{
		private IUserService _userService;

		[TestInitialize]
		public void Initialize()
		{
			_userService = new OracleSoaUserService();
		}

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void SearchNotImplemented()
		{
			var response = _userService.Search(null);
		}


		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void VerifyUserNotImplemented()
		{
			var response = _userService.VerifyUser(null, null);
		}

	}
}
