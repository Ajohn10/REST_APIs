using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RESTClient.Authenticators
{
	/// <summary>
	/// authenticator that adds authentication through standard Basic Authentication
	/// </summary>
	public class BasicAuthenticator : IAuthentication
	{
		public string Username { get; }
		public string Password { get; }

		public BasicAuthenticator(string username, string password)
		{

		}

		public void AddAuthentication(HttpClient client)
		{
			var basicAuthValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Username}:{Password}"));
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthValue);
		}
	}
}
