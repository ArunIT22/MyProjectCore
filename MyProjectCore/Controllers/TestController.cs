using Microsoft.AspNetCore.Mvc;
using MyProjectCore.Filters;

namespace MyProjectCore.Controllers
{
    //[MyCustomFilters("Controller", 1)]
    [NewCustomFilter("Controller")]
    public class TestController : Controller
    {
        //[MyCustomFilters("Action", -1)]
        [NewCustomFilter("Action")]
        public IActionResult Index()
        {
            //throw new Exception("This is Test");
            return View();
        }
    }
}
