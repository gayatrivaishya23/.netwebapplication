using MovieEventBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieEventBooking.Services
{
    public class InMemoryUserService : IUserService
    {
        private readonly List<UserModel> _users = new();

        public bool Register(UserModel user)
        {
            if (_users.Any(u => u.Email == user.Email))
                return false;

            user.UserId = _users.Count + 1;
            _users.Add(user);
            return true;
        }

        public UserModel? Authenticate(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
