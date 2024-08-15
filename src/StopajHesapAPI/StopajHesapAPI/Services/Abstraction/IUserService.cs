using StopajHesapAPI.Models;

namespace StopajHesapAPI.Services.Abstraction
{
    public interface IUserService
    {
       public List<UserModel> GetUsers();
        public UserModel Login(string username, string password);  
    }
}
