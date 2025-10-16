using System.Diagnostics;
using GameStore.Api.Authorization;
using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.ErrorHandling;
using GameStore.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddGameStoreAuthorization();
builder.Services.AddApiVersioning();

builder.Services.AddHttpLogging(logging =>
{
  // Added because it was not working properly
  logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp =>
exceptionHandlerApp.ConfigureExceptionHandler());

app.UseMiddleware<RequestTimingMiddleware>();

await app.Services.InitializeDbAsync();

app.UseHttpLogging();
app.MapGamesEndpoints();

app.Run();