using TKS.Components;
using Microsoft.EntityFrameworkCore;
using TKS.Services.Interfaces;
using TKS.Services.Implementations;
using TKS.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<TKS.Data.AppDbContext>(options =>
options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")
   )));

builder.Services.AddScoped<IDonViTinhService, TKS.Services.DonViTinhService>();
builder.Services.AddScoped<ILoaiSanPhamService, TKS.Services.LoaiSanPhamService>();
builder.Services.AddScoped<ISanPhamService, TKS.Services.SanPhamService>();
builder.Services.AddScoped<INhaCungCapService, TKS.Services.NhaCungCapService>();
builder.Services.AddScoped<IKhoService, TKS.Services.KhoService>();
builder.Services.AddScoped<IKhoUserService, TKS.Services.KhoUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
