using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TaskManagerAPI.Services;
public class UserService
{
    private DbTaskContext _dbContext;
    private JwtSettings _jwtSettings;

    public UserService(DbTaskContext dbContext, JwtSettings jwtSettings)
    {
        _dbContext = dbContext;
        _jwtSettings = jwtSettings;
    } 

    public async Task<bool> RegisterAsync(string username, string password)
    {
        if (string.IsNullOrEmpty(username)) throw new ArgumentException("Некорректное имя пользователя!");
        if (string.IsNullOrEmpty(password)) throw new ArgumentException("Некорректный пароль!");
        if (await _dbContext.Users.AnyAsync(u => u.Username == username)) throw new ArgumentException("Пользователь с таким именем уже существует!");
        
        string hash = BCrypt.Net.BCrypt.HashPassword(password);
        User user = new User(username, hash);
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<string?> LoginAsync(string username, string password)
    {
        if (string.IsNullOrEmpty(username)) throw new ArgumentException("Некорректное имя пользователя!");
        if (string.IsNullOrEmpty(password)) throw new ArgumentException("Некорректный пароль!");

        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
        if (user == null) return null;
        if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            var token = GenerateJwtToken(user);
            return token;
        }
        return null;
    }
    
    private string GenerateJwtToken(User user)
    {
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username)
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiryHours);

    var token = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        claims: claims,
        expires: expires,
        signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
    }
}