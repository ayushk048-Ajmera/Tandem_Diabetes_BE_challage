using Microsoft.Azure.Documents.Client;
using Tandem_Diabetes_BE_challenge.CosmosConfig.Service;
using Tandem_Diabetes_BE_challenge.Entities;
using Tandem_Diabetes_BE_challenge.Repository;

namespace Tandem_Diabetes_BE_challenge.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ICosmosDbService _cosmosDbService;

        public UserRepository(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public async Task<User> createUser(User user)
        {
            User createdUser = await _cosmosDbService.AddItemAsync(user);
            return createdUser;
        }

        public async Task<IEnumerable<User>> getAllUsers()
        {
            IEnumerable<User> users = await _cosmosDbService.GetUsersAsync("SELECT * FROM c");
            return users;
        }

        public async Task<IEnumerable<User>> getUserByEmail(string email)
        {
            IEnumerable<User> users = await _cosmosDbService.GetUsersAsync($"SELECT * FROM c WHERE c.emailAddress = '{email}'");
            return users;
        }

    }
}
