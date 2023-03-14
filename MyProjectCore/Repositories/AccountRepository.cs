using MyProjectCore.Models;

namespace MyProjectCore.Repositories
{
    public class AccountRepository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserDetail ValidateUser(string username, string password)
        {
            var userDetails = _context.UserDetails.FirstOrDefault(x => x.UserName == username && x.Password == password);
            return userDetails;
        }
    }
}
