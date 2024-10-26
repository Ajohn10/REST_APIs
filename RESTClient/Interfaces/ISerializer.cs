using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClient
{
	/// <summary>
	/// serializer for body of request/response
	/// </summary>
	public interface ISerializer
	{
		/// <summary>
		/// media type to use when serializing
		/// </summary>
		string MediaType { get; }

		/// <summary>
		/// encoding type for serializer
		/// </summary>
		System.Text.Encoding Encoding { get; }

		/// <summary>
		/// serialize object for body
		/// </summary>
		/// <param name="ob"></param>
		/// <returns></returns>
		string Serialize(object ob);

		/// <summary>
		/// deserialize string into object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="body"></param>
		/// <returns></returns>
		T Deserialize<T>(string body);
	}
}
