using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskWeb.Data;
using TaskWeb.Models;

namespace TaskWeb.Pages
{
    public class CompleteTodoModel : PageModel
    {
        private readonly AppDbContext _context;

        public CompleteTodoModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            todo.IsDone = true;
            await _context.SaveChangesAsync();

            return RedirectToPage("/Todos");
        }
    }
}
