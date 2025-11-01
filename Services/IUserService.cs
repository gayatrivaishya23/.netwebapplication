using MovieEventBooking.Models;

namespace MovieEventBooking.Services
{
    public interface IUserService
    {
        UserModel? Authenticate(string email, string password);
        bool Register(UserModel user);
    }
}
