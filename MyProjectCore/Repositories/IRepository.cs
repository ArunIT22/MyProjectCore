using MyProjectCore.Models;

namespace MyProjectCore.Repositories
{
    public interface IRepository
    {
        UserDetail ValidateUser(string username, string password);
    }

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProductById(int categoryId);
    }
}
