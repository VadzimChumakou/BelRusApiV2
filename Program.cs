using BelRusApiV2.Models.EfModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("systemAdminPolicy", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Администратор системы");
    });
    options.AddPolicy("uzelAdminPolicy", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Администратор узла");
    });
    options.AddPolicy("operatorPolicy", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Оператор");
    });
    options.AddPolicy("userPolisy", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Пользователь");
    });
});
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("http://localhost:3002/"));
});
builder.Services.AddCors();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BelayaRusV5Context>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.UseCors("CorsPolicy");
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});
app.Run();
