using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Programm_L.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Programm_LContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Programm_LContext") ?? throw new InvalidOperationException("Connection string 'Programm_LContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
