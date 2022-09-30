using Microsoft.EntityFrameworkCore;
using URLShortenerBACK.Sevices;
using URLShortenerBACK.Models;


var builder = WebApplication.CreateBuilder(args);

string CORSOpenPolicy = "OpenCORSPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("Database")
);
builder.Services.AddScoped<URLService, URLService>();
builder.Services.AddScoped<UserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseCors(CORSOpenPolicy);

app.UseAuthorization();

app.MapControllers();


app.Run();
