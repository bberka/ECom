using ECom.Application.Setup;
using Microsoft.AspNetCore.Mvc.Authorization;

EComLoggerHelper.Configure(true);


var builder = WebApplication.CreateBuilder(args);

builder.Setup();



var app = builder.Build();

app.Setup();
app.Run();