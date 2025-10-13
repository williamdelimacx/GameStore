using GameStore.Api.Authorization;
using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddGameStoreAuthorization();

var app = builder.Build();

await app.Services.InitializeDbAsync();
app.Logger.LogInformation(5, "The database is ready!");

app.MapGamesEndpoints();

app.Run();