using Geek.Web.Domain.Interface;
using Geek.Web.Domain.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProdutoService, ProdutoService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrl:ProductApi"]));

builder.Services.AddScoped<Geek.Web.Domain.Interface.IProdutoService, Geek.Web.Domain.Service.ProdutoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
