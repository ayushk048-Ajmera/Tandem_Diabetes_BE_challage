using Microsoft.Azure.Cosmos;
using Tandem_Diabetes_BE_challenge.CosmosConfig.Service;

namespace Tandem_Diabetes_BE_challenge.Config
{
    public class CosmosDBConfig
    {
        public static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string containerName = configurationSection.GetSection("ContainerName").Value;
            string account = configurationSection.GetSection("Account").Value;
            string key = configurationSection.GetSection("Key").Value;
            
            CosmosClient client = new CosmosClient(account, key);
            CosmosDbService cosmosDbService = new CosmosDbService(client, databaseName, containerName);
            
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            return cosmosDbService;
        }
    }
}
