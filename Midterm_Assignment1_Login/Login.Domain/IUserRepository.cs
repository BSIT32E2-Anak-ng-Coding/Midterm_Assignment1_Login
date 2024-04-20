
namespace Login.Domain
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
    }
}
