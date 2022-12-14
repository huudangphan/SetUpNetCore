using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using QTS.Commons;
using QTS.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
GlobalData.connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
GlobalData.issuer = Functions.ToString(Functions.Decrypt(builder.Configuration["Jwt:Issuer"]));
GlobalData.audience = Functions.ToString(Functions.Decrypt(builder.Configuration["Jwt:Audience"]));
GlobalData.key = Functions.ToString(Functions.Decrypt(builder.Configuration["Jwt:Key"]));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = GlobalData.issuer,
        ValidAudience = GlobalData.audience,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF32.GetBytes(GlobalData.key)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddAuthorization();


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



