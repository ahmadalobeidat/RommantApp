using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RommanyAPI;
using RommanyAPI.Interfaces;
using RommanyAPI.Services;
using RommanyAPI.Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RommanyDBContext>(options =>{
  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

builder.Services.AddScoped<IRepository<AboutUs> , Repository<AboutUs>>();
builder.Services.AddScoped<IRepository<User> , Repository<User>>();
builder.Services.AddScoped<IRepository<UserLogin> , Repository<UserLogin>>();
builder.Services.AddScoped<IUserLoginRepository , UserLoginRepository>();
builder.Services.AddScoped<IUserRepository , UserRepository>();
builder.Services.AddScoped<ITokenService , TokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer( option => {
  option.TokenValidationParameters = new TokenValidationParameters(){
    ValidateIssuerSigningKey = true ,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
    ValidateIssuer = false,
    ValidateAudience = false 
  };
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(builder =>  builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
