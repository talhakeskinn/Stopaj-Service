using Microsoft.AspNetCore.Authentication;
using StopajHesapAPI.Services;
using StopajHesapAPI.Services.Abstraction; // Ensure this namespace is included

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<StopajHesapService>();


// Register IUserService implementation
builder.Services.AddSingleton<IUserService, UserService>();

// Configure authentication with BasicAuthenticationHandler
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", options => { });

// Add services to the container.
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

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
