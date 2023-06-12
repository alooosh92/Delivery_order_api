global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Delivery_order.Models;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using System.Diagnostics.CodeAnalysis;
global using System.Net.Mail;
global using System.Net;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using Microsoft.AspNetCore.Identity.UI.Services;
global using Delivery_order.Data;
global using jwt;
global using Delivery_order.Repository;
global using Delivery_order.VModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository,Repository>();
Seed.Setting(builder);
var app = builder.Build();
await Seed.AddRoll(app.Services, new List<string> { "User", "Admin", "Employee" }); //Add this line to add rolles
await Seed.AddAdmin(app.Services, builder.Configuration["EmailSender:UserName"]!); //Add this line to add admin user
await Seed.AddRegions(app.Services);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
