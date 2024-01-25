using chattech_auth.Dependencies;
using chattech_auth.Interface;
using chattech_auth.Models.Dto;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

ServicesDependency.AddServices(builder.Services, builder);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/api/auth", async(IAuthService _authService,[FromBody] AuthRequest authRequest) =>
{
    var response = await _authService.Login(authRequest);
    return response.Succeeded
        ? Results.Ok(response.Data)
        : Results.BadRequest();
})
.WithDescription("To validate a user")
.WithOpenApi();

app.Run();

