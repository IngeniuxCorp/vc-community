using Ingeniux.OracleSoa.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeniux.OracleSoa.Services
{
    public interface IUserService
    {
		/// <summary>
		/// Returns true if login and password are correct. Otherwise false
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		bool VerifyUser(string login, string password);

		/// <summary>
		/// Provides ability to search user
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		UserServiceSearchResponse Search(UserServiceSearchRequest request);
    }
}
