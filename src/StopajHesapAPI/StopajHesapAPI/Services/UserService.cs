using StopajHesapAPI.Models;
using StopajHesapAPI.Services.Abstraction;
using System.Linq;

namespace StopajHesapAPI.Services
{
    public class UserService : IUserService
    {
        readonly List<UserModel> _users;
        public UserService()
        {
            _users = new List<UserModel>()
            {
                new UserModel{userName = "user1", password = "12345" }

            };
        }

        public List<UserModel> GetUsers()
        {
            return _users;
        }

        public UserModel Login(string username, string password)
        {
            var user = _users.FirstOrDefault(x => x.userName == username && x.password == password);
            return user;
        }
    }
}


