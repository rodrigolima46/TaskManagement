using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskWeb.Data;
using TaskWeb.Models;

namespace TaskWeb.Pages
{
    public class TodosModel : PageModel
    {
        private readonly AppDbContext _context;

        public TodosModel(AppDbContext context)
        {
            _context = context;
        }

        public List<TodoItem> TodoItems { get; set; } = new();

        public async Task OnGetAsync()
        {
            TodoItems = await _context.TodoItems.ToListAsync();
        }
    }
}
