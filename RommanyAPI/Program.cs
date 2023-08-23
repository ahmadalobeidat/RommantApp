using Microsoft.EntityFrameworkCore;
using RommanyAPI;
using RommanyAPI.Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RommanyDBContext>(options =>{
  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

builder.Services.AddScoped<IRepository<AboutUs> , Repository<AboutUs>>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
