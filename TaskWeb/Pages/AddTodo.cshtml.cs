using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskWeb.Data;
using TaskWeb.Models;

namespace TaskWeb.Pages
{
    public class AddTodoModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddTodoModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string? Title { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                var todo = new TodoItem { Title = Title };
                _context.TodoItems.Add(todo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Todos");
        }
    }
}
