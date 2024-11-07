using Microsoft.Azure.Cosmos;
using Product_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string? url = builder.Configuration.GetSection("AzureCosmoDBSettings").GetValue<string>("URL");
string? primaryKey = builder.Configuration.GetSection("AzureCosmoDBSettings").GetValue<string>("PrimaryKey");
string? dbName = builder.Configuration.GetSection("AzureCosmoDBSettings").GetValue<string>("DatabaseName");
string? containerName = builder.Configuration.GetSection("AzureCosmoDBSettings").GetValue<string>("ContainerName");

builder.Services.AddSingleton<IProductService>(options =>
{
    var cosmosClient = new CosmosClient(url, primaryKey);
    return new ProductService(cosmosClient, dbName, containerName);

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

