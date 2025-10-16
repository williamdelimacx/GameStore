using System.Diagnostics;
using GameStore.Api.Authorization;
using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddGameStoreAuthorization();

var app = builder.Build();

app.Use(async (context, next) =>
{
  var stopWatch = new Stopwatch();

  try
  {
    stopWatch.Start();
    await next(context);
  }
  finally
  {
    stopWatch.Stop();

    var elapsedMilliseconds = stopWatch.ElapsedMilliseconds;
    app.Logger.LogInformation(
        "{RequestMethod} {RequestPath} request took {EllapsedMilliseconds}ms to complete",
        context.Request.Method,
        context.Request.Path,
        elapsedMilliseconds);
  }
});

await app.Services.InitializeDbAsync();

app.UseHttpLogging();
app.MapGamesEndpoints();

app.Run();