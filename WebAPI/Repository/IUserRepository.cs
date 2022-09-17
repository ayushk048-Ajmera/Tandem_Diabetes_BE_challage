using Tandem_Diabetes_BE_challenge.Entities;

namespace Tandem_Diabetes_BE_challenge.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();

        public Task<User> GetUserByEmail(string email);

        public Task<User> CreateUser(User user);

    }
}
