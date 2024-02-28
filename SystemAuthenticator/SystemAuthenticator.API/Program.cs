using SystemAuthenticator.ExceptionMiddleware;
using SystemAuthenticator.Infra.Ioc.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(new ExceptionMiddleware()); });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureSwagger();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
