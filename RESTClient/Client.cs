using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RESTClient
{
	/// <summary>
	/// main client for REST API 
	/// </summary>
	public class Client : HttpClient
	{
		/// <summary>
		/// if set, will call authentication every call.  Otherwise, will only call when it is set
		/// </summary>
		public bool ResetAuthenticationEachCall { get; set; }

		private IAuthentication _authentication;
		/// <summary>
		/// authentication to add
		/// </summary>
		public IAuthentication Authentication 
		{
			get => _authentication;
			set
			{
				_authentication = value;
				_authentication?.AddAuthentication(this);
			}
		}

		/// <summary>
		/// serializer to use for making a request
		/// </summary>
		public ISerializer RequestSerializer { get; set; }

		/// <summary>
		/// serializer to use for reading a response.  If null, will use RequestSerializer
		/// </summary>
		public ISerializer ResponseSerializer { get; set; }

		public Client(ISerializer requestSerializer)
		{
			RequestSerializer = requestSerializer;
		}

		public Client(ISerializer requestSerializer, ISerializer responseSerializer)
		{
			RequestSerializer = requestSerializer;
			ResponseSerializer = responseSerializer;
		}

		/// <summary>
		/// Sends Put Call to the given URL with the given Body, and returns the expected response.
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <typeparam name="B"></typeparam>
		/// <param name="url"></param>
		/// <param name="body"></param>
		/// <returns></returns>
		public async Task<(R, HttpResponseMessage)> PutAsync<R, B>(string url, B body)
		{
			var content = new StringContent(RequestSerializer.Serialize(body),
				RequestSerializer.Encoding, RequestSerializer.MediaType);

			if (ResetAuthenticationEachCall)
				Authentication?.AddAuthentication(this);

			var response = await PutAsync(url, content);
			var result = await response.Content?.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode) throw new Exception($"{(int)response.StatusCode} {response.StatusCode}: {result}");
			return ((ResponseSerializer ?? RequestSerializer).Deserialize<R>(result), response);
		}

		/// <summary>
		/// Sends Post Call to the given URL with the given Body, and returns the expected response.
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <typeparam name="B"></typeparam>
		/// <param name="url"></param>
		/// <param name="body"></param>
		/// <returns></returns>
		public async Task<(R, HttpResponseMessage)> PostAsync<R, B>(string url, B body)
		{
			var content = new StringContent(RequestSerializer.Serialize(body),
				RequestSerializer.Encoding, RequestSerializer.MediaType);

			if (ResetAuthenticationEachCall)
				Authentication?.AddAuthentication(this);

			var response = await PostAsync(url, content);
			var result = await response.Content?.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode) throw new Exception($"{(int)response.StatusCode} {response.StatusCode}: {result}");
			return ((ResponseSerializer ?? RequestSerializer).Deserialize<R>(result), response);
		}

		/// <summary>
		/// Sends Get Call to the given URL, and returns the expected response.
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <param name="url"></param>
		/// <returns></returns>
		public async Task<(R, HttpResponseMessage)> GetAsync<R>(string url)
		{
			if (ResetAuthenticationEachCall)
				Authentication?.AddAuthentication(this);

			var response = await GetAsync(url);
			var result = await response.Content?.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode) throw new Exception($"{(int)response.StatusCode} {response.StatusCode}: {result}");
			return ((ResponseSerializer ?? RequestSerializer).Deserialize<R>(result), response);
		}

		/// <summary>
		/// Sends Delete Call to the given URL, and returns the expected response.
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <param name="url"></param>
		/// <returns></returns>
		public async Task<(R, HttpResponseMessage)> DeleteAsync<R>(string url)
		{
			if (ResetAuthenticationEachCall)
				Authentication?.AddAuthentication(this);

			var response = await DeleteAsync(url);
			var result = await response.Content?.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode) throw new Exception($"{(int)response.StatusCode} {response.StatusCode}: {result}");
			return ((ResponseSerializer ?? RequestSerializer).Deserialize<R>(result), response);
		}
	}
}