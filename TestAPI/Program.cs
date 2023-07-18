using FakeStore.Database;
using FakeStore.Database.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.UseFakeStoreDatabase(new FakeDatabaseConfigurator()
{
    UsersConfiguration = new UsersConfigurator()
    {
        MaxDefaultUsers = 10,
        NullProbability = 0.3f
    },
    MaxDefaultProducts = 0,
    MaxDefaultCategories = 0
});

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
