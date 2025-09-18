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
        public TodoItem TodoItem { get; set; } = new TodoItem();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TodoItem.CreatedAt = DateTime.UtcNow; 
            _context.TodoItems.Add(TodoItem);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Todos");
        }
    }
}
