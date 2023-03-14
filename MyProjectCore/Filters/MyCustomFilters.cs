using Microsoft.AspNetCore.Mvc.Filters;

namespace MyProjectCore.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class MyCustomFiltersAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        
        private readonly string _name;

        //Order of Execution (-1, 0, 1)
        public int Order { get; set; }

        public MyCustomFiltersAttribute(string name, int order)
        {
            _name = name;
            Order = order;
        }



        //Filter Sequence -> Global, Controller, Action
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine($"Authorize Filter - {_name}");
        }
    }
}
