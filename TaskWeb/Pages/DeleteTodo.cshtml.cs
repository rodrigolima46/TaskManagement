using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskWeb.Data;
using TaskWeb.Models;

namespace TaskWeb.Pages
{
    public class DeleteTodoModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteTodoModel(AppDbContext context)
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

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Todos");
        }
    }
}
