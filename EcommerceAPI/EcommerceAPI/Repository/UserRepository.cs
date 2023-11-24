using EcommerceAPI.Data;
using EcommerceAPI.Interface;
using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public bool CheckIfExist(int id)
        {
            return _context.Users.Any(x => x.id == id);
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public User GetById(int id)
        {
            return _context.Users.Where(x => x.id == id).FirstOrDefault();
        }

        public UserVM GetUserByUsername(string Username)
        {
            return _context.Users.Where(x => x.username == Username).Select(x => new UserVM { nama = x.nama, password = x.password, username = x.username }).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return Save();
        }
    }
}
