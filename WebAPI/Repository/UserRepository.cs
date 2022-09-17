using Microsoft.Azure.Cosmos;
using Tandem_Diabetes_BE_challenge.CosmosConfig.Service;
using Tandem_Diabetes_BE_challenge.Entities;
using User = Tandem_Diabetes_BE_challenge.Entities.User;

namespace Tandem_Diabetes_BE_challenge.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ICosmosDbService _cosmosDbService;

        public UserRepository(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public async Task<User> CreateUser(User user)
        {
            User createdUser = await _cosmosDbService.AddUserAsync(user);
            return createdUser;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            IEnumerable<User> users = await _cosmosDbService.GetUsersAsync("SELECT * FROM c");
            return users;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = await _cosmosDbService.GetUserAsync(email);
            return user;
        }
    }
}
