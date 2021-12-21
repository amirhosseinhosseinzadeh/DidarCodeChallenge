global using DidarCodeChallenge.Api.Services;
using DidarCodeChallenge.Api.Context.Migration;
using DidarCodeChallenge.Api.Context;
using DidarCodeChallenge.Api.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBinarySerachTreeService, BinarySearchTreeService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRequestService, RequestService>();
// builder.WebHost.UseUrls("http://*:80");
builder.Services.AddCors(options =>
{
    CorsPolicy policy = new();
    options.AddPolicy("policy", policy => 
    { 
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
    // options.
});
builder.Services.AddDbContext<DataContext>(options =>
{
    var str = "Server=172.29.0.5, 1433;Database=DidarCodeChallenge;user id = sa;password=didarcodeChallenge0021";
    // options.UseSqlServer("Server=localhost, 1445;Database=DidarCodeChallenge;user id = sa;password=didarcodeChallenge0021");
    // System.Console.WriteLine(str);
    options.UseSqlServer(str);
});
var app = builder.Build();
MigrationManager.Migrate(app);
System.Console.WriteLine();
// Configure the HTTP request pipeline.
#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
#endif

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
