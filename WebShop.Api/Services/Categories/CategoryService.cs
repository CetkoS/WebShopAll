using WebShop.Api.Helpers;

namespace WebShop.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IHttpClientFactory httpClientFactory, ILogger<CategoryService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("FakeApiHttpClient");
            _logger = logger;
        }

        public async Task<List<string>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("products/categories");

                response.EnsureSuccessStatusCode();

                var categories = await ResponseDeserializer.DeserializeAsync<List<string>>(response);
                
                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting categories");
                return [];
            }
        }
    }
}
