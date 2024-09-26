using InvestmentManager.Application.DTOs;
using InvestmentManager.Application.Interfaces;
using InvestmentManager.Domain.Entities;
using InvestmentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace InvestmentManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly InvestmentDbContext _context;

        public UserService(InvestmentDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> RegisterUserAsync(string name, string email, string password)
        {
            if (await _context.Users.AnyAsync(u => u.Email == email))
                throw new ArgumentException("Email already in use.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                PasswordHash = HashPassword(password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<Guid> LoginUserAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                throw new ArgumentException("Invalid email or password.");

            return user.Id;
        }

        public async Task<bool> RecoverPasswordAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return false;

            // Implement logic to send email for password recovery
            return true;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hashOfInput = HashPassword(password);
            return storedHash == hashOfInput;
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
