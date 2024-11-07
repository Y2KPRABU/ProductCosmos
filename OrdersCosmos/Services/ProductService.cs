using System.Collections.Concurrent;
using Microsoft.Azure.Cosmos;
using Product_API.Models;
namespace Product_API.Services
{
    public class ProductService : IProductService
    {
        private readonly Container? _container;

        public ProductService()
        {
        }

        public ProductService(CosmosClient cosmosClient, string
        databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName,
            containerName);
        }
        public async Task<ProductModel> Add(ProductModel task)
        {
            var item = await _container.CreateItemAsync < ProductModel>
            (task, new PartitionKey(task.Id));

            return item;
        }
        public async Task Delete(string id, string partition)
        {
            await _container.DeleteItemAsync<ProductModel>(id, new
            PartitionKey(partition));
        }
        public async Task<List<ProductModel>> Get(string cosmosQuery)
        {
            var query = _container.GetItemQueryIterator < ProductModel>
            (new QueryDefinition(cosmosQuery));
            List<ProductModel> results = new List<ProductModel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }
        public async Task<ProductModel> Update(ProductModel task)
        {
            var item = await _container.UpsertItemAsync < ProductModel>
            (task, new PartitionKey(task.Id));
            return item;
        }
    }

  
}