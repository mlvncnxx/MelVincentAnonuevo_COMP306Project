using MelVincentAnonuevo_COMP306Project.Models;
using MelVincentAnonuevo_COMP306Project.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MelVincentDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection2MelVincent")));

builder.Services.AddScoped<IGameInfoRepository, GameInfoRepository>();
builder.Services.AddScoped<IGameCommentRepository, GameCommentRepository>();
builder.Services.AddScoped<IGameRatingRepository, GameRatingRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
