using Ingeniux.OracleSoa.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeniux.OracleSoa.Api.Services
{
    public interface IUserService
    {
		/// <summary>
		/// Returns true if login and password are correct. Otherwise false
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		Task<bool> VerifyUserAsync(string login, string password);

		/// <summary>
		/// Provides ability to search user
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		Task<UserServiceSearchResponse> SearchAsync(UserServiceSearchRequest request);
    }
}
