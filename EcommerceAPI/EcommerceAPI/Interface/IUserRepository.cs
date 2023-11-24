using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;

namespace EcommerceAPI.Interface
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetById(int id);
        UserVM GetUserByUsername(string Username);
        bool CheckIfExist(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
