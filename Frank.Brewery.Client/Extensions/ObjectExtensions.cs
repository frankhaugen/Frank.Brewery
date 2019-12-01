using System.Net.Http;
using System.Text.Json;

namespace Frank.Brewery.Client.Extensions
{
    public static class ObjectExtensions
    {
        public static HttpContent ToHttpContent(this object value)
        {
            return new StringContent(value.ToJson());
        }

        public static string ToJson(this object value, bool indented = false)
        {
            return JsonSerializer.Serialize(value, new JsonSerializerOptions()
            {
                WriteIndented = indented
            });
        }
    }
}
