using System;
using System.Collections.Generic;
using System.Text;

namespace EtsyAPI
{
	/// <summary>
	/// client to use for communicating to Etsy API 
	/// </summary>
	public class Client
	{
		/// <summary>
		/// version of api this client targets
		/// </summary>
		public const string VERSION = "v3";
		/// <summary>
		/// base url used to communicate to Etsy API
		/// </summary>
		public readonly string BASE_URL = $"https://openapi.etsy.com/{VERSION}/application";
	}
}
