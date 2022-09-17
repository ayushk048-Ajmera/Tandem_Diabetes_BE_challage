

using Tandem_Diabetes_BE_challenge.Entities;

namespace Tandem_Diabetes_BE_challenge.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> getAllUsers();

        public Task<IEnumerable<User>> getUserByEmail(string email);

        public Task<User> createUser(User user);

    }
}
