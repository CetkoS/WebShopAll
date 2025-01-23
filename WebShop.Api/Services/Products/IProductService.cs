using WebShop.Api.Models;

namespace WebShop.Api.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetByCategoryAsync(string category);
    }
}