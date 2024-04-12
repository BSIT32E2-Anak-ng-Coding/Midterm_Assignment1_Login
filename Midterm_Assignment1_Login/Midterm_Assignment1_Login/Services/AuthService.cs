using System;
using System.Collections.Generic;
using Midterm_Assignment1_Login.Domain;

namespace Midterm_Assignment1_Login.Services
{
    public interface IAuthService
    {
        bool RegisterUser(string username, string password, string email);
        bool Login(string username, string password, out User user);
    }


    public class AuthService : IAuthService
    {
        private readonly IDictionary<string, User> _userStorage;

        public AuthService(IDictionary<string, User> userStorage)
        {
            _userStorage = userStorage ?? throw new ArgumentNullException(nameof(userStorage));
        }

        public bool RegisterUser(string username, string password, string email)
        {
            if (_userStorage.ContainsKey(username))
            {
                return false; // Username already exists
            }

            // Validate username, password, and email
            // (Validation code omitted for brevity)

            // Hash the password
            string passwordHash = HashPassword(password);

            var newUser = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                Email = email
            };

            _userStorage.Add(username, newUser);
            return true;
        }

        public bool Login(string username, string password, out User user)
        {
            user = null;
            if (!_userStorage.TryGetValue(username, out User storedUser))
            {
                return false; // User not found
            }

            if (!VerifyPassword(password, storedUser.PasswordHash))
            {
                return false; // Invalid password
            }

            user = storedUser;
            return true;
        }

        // Hashes the password using bcrypt
        private string HashPassword(string password)
        {
            // Bcrypt hashing implementation
            // (You'll need to integrate a bcrypt library for this)
            // Example: BCrypt.Net
            // string salt = BCrypt.GenerateSalt();
            // return BCrypt.HashPassword(password, salt, costFactor: 12);
            throw new NotImplementedException("Bcrypt hashing not implemented for demonstration.");
        }

        // Verifies the password against the stored hash
        private bool VerifyPassword(string password, string storedHash)
        {
            // Bcrypt verification implementation
            // Example: BCrypt.Net
            // return BCrypt.Verify(password, storedHash);
            throw new NotImplementedException("Bcrypt verification not implemented for demonstration.");
        }
    }
}
