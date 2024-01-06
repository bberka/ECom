using ECom.Api;
using ECom.Business;
using ECom.Database;
using ECom.Foundation.Abstract;
using ECom.Foundation.Lib;
using ECom.Service.AdminApi;
using ECom.Service.PublicApi;
using ECom.Service.UserApi;

var builder = WebApplication.CreateBuilder(args);


DatabaseResolver.SetupBuilder(builder);
BusinessResolver.SetupBuilder(builder);
UserServiceResolver.SetupBuilder(builder);
AdminServiceResolver.SetupBuilder(builder);
PublicServiceResolver.SetupBuilder(builder);
ApiResolver.SetupBuilder(builder);

var app = builder.Build();

DatabaseResolver.SetupApplication(app);
BusinessResolver.SetupApplication(app);
UserServiceResolver.SetupApplication(app);
AdminServiceResolver.SetupApplication(app);
PublicServiceResolver.SetupApplication(app);
ApiResolver.SetupApplication(app);

AsmLib.InitializeAllSingletons(app.Services);
app.Run();