using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using CelsiaProject.Data;
using CelsiaProject.Models.DTOs;
using CelsiaProject.Services;

namespace CelsiaProject.Services;

public class JwtRepository : IJwtRepository
{
    private readonly CelsiaContext _context;

    public JwtRepository(CelsiaContext context)
    {
        _context = context;
    }

    public string GenerateToken(UserDto user)
    {
        var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E")); //variable key
            var SigninCredentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
            //This apart id for permissions
            //Add token opstions
            var TokenOptions = new JwtSecurityToken(
                issuer: @Environment.GetEnvironmentVariable("Issuer"),
                audience: @Environment.GetEnvironmentVariable("Audience"),
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: SigninCredentials
            );
            //Token Generated
            var TokenString = new JwtSecurityTokenHandler().WriteToken(TokenOptions);

            return TokenString;
    }
}