using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TaskWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = null!;

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/Todos"); // 🔹 redirecionamento padrão
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/Todos");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }
    }
}
