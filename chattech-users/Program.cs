using chattech_users.Dependencies;
using chattech_users.Enums;
using chattech_users.Interfaces;
using chattech_users.Models;
using chattech_users.Models.Dto;

var builder = WebApplication.CreateBuilder(args);

ServicesDependency.AddServices(builder.Services);
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/api/user", async (IUserService _userService, UserDto userDto) =>
{
    var response = await _userService.AddUserAsync(userDto);
    return response.Succeeded
        ? Results.Ok(new ApiResponse<User>(response.Succeeded, response.Message, response.Data, (int)HttpStatusCode.Created))
        : Results.BadRequest();
})
.WithDescription("To create a user")
.WithOpenApi();

app.Run();

