﻿using Microsoft.Azure.Cosmos;
using User = Tandem_Diabetes_BE_challenge.Entities.User;

namespace Tandem_Diabetes_BE_challenge.CosmosConfig.Service
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                await _container.CreateItemAsync(user, new PartitionKey(user.EmailAddress));
                return user;
            }
            catch
            {
                throw new Exception("Fail to add user");
            }
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string query)
        {
            FeedIterator<User> feedIterator = _container.GetItemQueryIterator<User>(new QueryDefinition(query));
            List<User> results = new List<User>();
            while (feedIterator.HasMoreResults)
            {
                var response = await feedIterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<User> GetUserAsync(string emailAddress)
        {
            try
            {
                ItemResponse<User> response = await _container.ReadItemAsync<User>(emailAddress, new PartitionKey(emailAddress));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
