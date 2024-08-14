using CelsiaProject.Models.DTOs;

namespace CelsiaProject.Services;

public interface IJwtRepository
{
    string GenerateToken(UserDto user);
}