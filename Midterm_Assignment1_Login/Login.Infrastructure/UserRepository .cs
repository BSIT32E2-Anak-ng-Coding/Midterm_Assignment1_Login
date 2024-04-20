using Login.Domain;


namespace Login.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByUsername(string username)
        {
            // In a real application, you would fetch the user from a database
            // For demonstration purposes, let's create a mock user
            if (username == "admin")
            {
                return new User { Id = 1, Username = "admin", Password = "admin" };
            }
            return null;
        }
    }
}
