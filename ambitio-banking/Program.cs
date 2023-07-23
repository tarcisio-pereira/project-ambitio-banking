using ambitio_banking.Data;
using ambitio_banking.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ambitio_banking.Helpers;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkMySql().AddDbContext<AmbitioContext>();

builder.Services.AddDbContext<AmbitioContext>(options =>
    options.UseMySql("server=localhost;port=3306;database=Banking;uid=root;password=senha123", new MySqlServerVersion(new Version(8, 0, 24))));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o =>
    {
        o.Cookie.HttpOnly = true;
        o.Cookie.IsEssential = true;

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

