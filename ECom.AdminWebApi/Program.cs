using ECom.Application.Setup;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Setup();
builder.Services.AddControllers(config => {
  var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
  config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();
app.Setup();
app.Run();
