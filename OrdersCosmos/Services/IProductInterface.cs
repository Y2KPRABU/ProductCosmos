using Product_API.Models;
namespace Product_API.Services
{

    public interface IProductService
    {

        Task<List<ProductModel>> Get(string query);
        Task<ProductModel> Add(ProductModel task);
        Task<ProductModel> Update(ProductModel task);
        Task Delete(string id, string partition);
    }
}