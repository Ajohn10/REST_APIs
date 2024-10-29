using System.Text.Json;

namespace RESTClient.Serializers
{
	/// <summary>
	/// serializer for RESTClient that uses the System.Text.Json dependency
	/// </summary>
	public class SystemTextJsonSerializer
	{
		public string MediaType { get; set; } = "application/json";

		public System.Text.Encoding Encoding { get; set; } = System.Text.Encoding.Default;

		public T Deserialize<T>(string body) => JsonSerializer.Deserialize<T>(body);

		public string Serialize(object ob) => JsonSerializer.Serialize(ob);
	}
}
