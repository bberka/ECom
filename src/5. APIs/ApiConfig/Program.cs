using ECom.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InjectDbDependency(builder.Configuration);
builder.Services.InjectAdminBusinessDependency(builder.Configuration);
builder.Services.InjectUserBusinessDependency(builder.Configuration);
builder.Services.InjectBaseBusinessDependency(builder.Configuration);
builder.Services.InjectValidators(builder.Configuration);
// builder.Services.InjectAutoMapper(builder.Configuration);
builder.Services.InjectSwagger(builder.Configuration);
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// app.UseMiddleware<DebugUserAuthenticationMiddleware>();

app.Run();