using CelsiaProject.Data;
using CelsiaProject.Models;
using CelsiaProject.Utils;

namespace CelsiaProject.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CelsiaContext _context;

        private readonly Bcrypt _bcrypt;

        public UserRepository(CelsiaContext context, Bcrypt bcrypt)
        {
            _context = context;
            _bcrypt = bcrypt;
        }

        public void Add(User user)
        {
            user.Password = _bcrypt.HashPassword(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}