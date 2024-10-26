using System;

namespace RESTClient.Serializers
{
	/// <summary>
	/// serializer that uses newtonsoft.json
	/// </summary>
	public class NewtonsoftSerializer : ISerializer
	{
		/// <summary>
		/// settings to use on serialization
		/// </summary>
		public Newtonsoft.Json.JsonSerializerSettings Settings { get; set; }

		public string MediaType { get; set; } = "application/json";

		public System.Text.Encoding Encoding { get; set; } = System.Text.Encoding.Default;

		public T Deserialize<T>(string body) => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(body);

		public string Serialize(object ob) => Newtonsoft.Json.JsonConvert.SerializeObject(ob, Settings);
	}
}
