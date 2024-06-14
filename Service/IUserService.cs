using AdminApi.Models;

namespace AdminApi.Service
{
    public interface IUserService
    {
        public int GetTotalUsers();
        public List<User> GetUsers();
        public string login(string email, string password);
    }
}
