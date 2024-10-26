using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RESTClient
{
	/// <summary>
	/// how authentication is handled
	/// </summary>
	public interface IAuthentication
	{
		/// <summary>
		/// add authentication to client
		/// </summary>
		/// <param name="client"></param>
		void AddAuthentication(HttpClient client);
	}
}
