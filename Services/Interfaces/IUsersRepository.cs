using CelsiaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CelsiaProject.Services
{
    public interface IUserRepository
    {
        public void Add(User user);
    }
}