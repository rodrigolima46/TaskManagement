using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskWeb.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using TaskWeb.Services;


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

builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ✅ habilita autenticação
app.UseAuthorization();

app.MapRazorPages(); // ✅ mapeia páginas padrão do Identity

app.MapGet("/", async (IEmailSender emailSender) =>
{
    await emailSender.SendEmailAsync(
        "rodrigo.lima.ads@gmail.com",
        "Teste SendGrid",
        "<strong>Se você recebeu isso, o envio funciona!</strong>"
    );
    return "E-mail enviado!";
});

app.Run();
