using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProjectCore.Filters;
using MyProjectCore.Repositories;

namespace MyProjectCore.Controllers
{
    //[RequireHttps]
    [HttpsOnly]
    [ServiceFilter(typeof(GlobalExceptionFilter))]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [AdminOnly]
        //[CanRead("admin","employee","customer")]
        public IActionResult Index()
        {
            throw new DivideByZeroException("Product is null");
            var products = _repository.GetProducts();
            return View(products);
        }

        [Authorize(Roles = "admin")]
        public IActionResult ProductByCategory(int? id)
        {
            var products = _repository.GetProductById(id.Value);
            return View(products);
        }
    }
}
