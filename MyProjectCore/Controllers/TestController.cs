using Microsoft.AspNetCore.Mvc;
using MyProjectCore.Filters;

namespace MyProjectCore.Controllers
{
    //[MyCustomFilters("Controller", 1)]
    //[NewCustomFilter("Controller")]
    // [MyAsyncActionFilter]
    //[ServiceFilter(typeof(MyAsyncActionFilter))]
    public class TestController : Controller
    {
        //[MyCustomFilters("Action", -1)]
        // [NewCustomFilter("Action")]
        public IActionResult Index()
        {
            //throw new Exception("This is Test");
            return View();
        }
    }
}
