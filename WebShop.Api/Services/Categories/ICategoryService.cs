namespace WebShop.Api.Services
{
    public interface ICategoryService
    {
        Task<List<string>> GetAllAsync();
    }
}