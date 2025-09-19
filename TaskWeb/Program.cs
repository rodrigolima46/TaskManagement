using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));


// Identity e UI padrão
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultUI(); // mantém as telas padrão

// Forçar redirecionamento após login/registro para /Todos
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnSignedIn = context =>
    {
        context.Response.Redirect("/Todos");
        return Task.CompletedTask;
    };
});


builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ✅ habilita autenticação
app.UseAuthorization();

app.MapRazorPages(); // ✅ mapeia páginas padrão do Identity

app.Run();
