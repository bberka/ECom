using ECom.Application.Setup;
using Microsoft.AspNetCore.Mvc.Authorization;

EComLoggerHelper.Configure(true);


var builder = WebApplication.CreateBuilder(args);

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