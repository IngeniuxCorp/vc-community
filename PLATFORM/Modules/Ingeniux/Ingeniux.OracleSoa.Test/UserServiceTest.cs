using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ingeniux.OracleSoa.Api.Services;

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
		public void SearchAsyncNotImplemented()
		{
			var searchTask = _userService.SearchAsync(null);
			searchTask.Wait();
		}


		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void VerifyUserNotImplemented()
		{
			var searchTask = _userService.VerifyUserAsync(null, null);
			searchTask.Wait();
		}

	}
}
