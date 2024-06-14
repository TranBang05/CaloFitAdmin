using AdminApi.Models;

namespace AdminApi.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly CalofitDBContext _context;

        public UserService(CalofitDBContext context)
        {
            _context = context;
        }

        public int GetTotalUsers()
        {
            return _context.Users.Count();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public string login(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);

            if (user == null)
            {
                return "User not found";
            }

            if (user.Password != password)
            {
                return "Invalid password";
            }
            if (user.Role != "Admin")
            {
                return "Access denied. Role is not an admin.";
            }
            return "Login successful";
        }
    }
}
