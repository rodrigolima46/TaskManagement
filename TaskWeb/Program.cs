using Microsoft.EntityFrameworkCore;
using TaskWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços Razor Pages
builder.Services.AddRazorPages();

// Adiciona EF Core com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

var app = builder.Build();

// Configuração padrão do template
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
