using System.Text.Json;

namespace WebShop.Api.Helpers
{
    public class ResponseDeserializer
    {
        public static async Task<T> DeserializeAsync<T>(HttpResponseMessage response)
            where T : class
        {
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // If return type is List, return empty list instead of null
            if(result is null && typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            {
                return (T)Activator.CreateInstance(typeof(T))!;
            }

            return result ?? default!;
        }
    }
}
