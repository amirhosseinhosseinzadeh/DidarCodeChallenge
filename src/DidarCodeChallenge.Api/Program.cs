global using DidarCodeChallenge.Api.Services;
using DidarCodeChallenge.Api.Context;
using DidarCodeChallenge.Api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBinarySerachTreeService, BinarySearchTreeService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRequestService,RequestService>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("Server=localhost, 1445;Database=DidarCodeChallenge;user id = sa;password=didarcodeChallenge0021");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
#endif

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
