using TKS.Components;
using Microsoft.EntityFrameworkCore;
using TKS.Services.Interfaces;
using TKS.Services.Implementations;
using TKS.Services;
using Microsoft.Extensions.Options;
using TKS.Models;

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
builder.Services.AddScoped<INhapKhoService, TKS.Services.NhapKhoService>();
builder.Services.AddScoped<INhapKhoRawService, TKS.Services.Implementations.NhapKhoRawService>();
builder.Services.AddScoped<IXNKNhapKhoService, TKS.Services.Implementations.XNKNhapKhoService>();
builder.Services.AddScoped<IXuatKhoService, TKS.Services.Implementations.XuatKhoService>();
builder.Services.AddScoped<IXuatKhoRawService, TKS.Services.Implementations.XuatKhoRawService>();
builder.Services.AddScoped<IXNKXuatKho, TKS.Services.Implementations.XNKXuatKhoService>();

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
