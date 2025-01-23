using WebShop.Api.Helpers;
using WebShop.Api.Models;

namespace WebShop.Api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IHttpClientFactory httpClientFactory, ILogger<ProductService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("FakeApiHttpClient");
            _logger = logger;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("products");

                response.EnsureSuccessStatusCode();

                var products = await ResponseDeserializer.DeserializeAsync<List<Product>>(response);

                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting products");
                return [];
            }
        }

        public async Task<List<Product>> GetByCategoryAsync(string category)
        {
            try
            {
                var response = await _httpClient.GetAsync($"products/category/{category}");

                response.EnsureSuccessStatusCode();

                var products = await ResponseDeserializer.DeserializeAsync<List<Product>>(response);

                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting products by category: {category}");
                return [];
            }
        }
    }
}
