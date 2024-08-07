using BE;
using BE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddCors(x =>
    x.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<TaltikoContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

var app = builder.Build();

//Run migrations
await using var scope = app.Services.CreateAsyncScope();
await using var db = scope.ServiceProvider.GetRequiredService<TaltikoContext>();
await db.Database.MigrateAsync();

// Configure the HTTP request pipeline.
app.UseCors();
app.UseGrpcWeb();
app.MapGrpcService<DiaryService>().EnableGrpcWeb();

app.Run();