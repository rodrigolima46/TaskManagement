using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskWeb.Data;
using TaskWeb.Models;

namespace TaskWeb.Pages
{
    public class TodosModel : PageModel
    {
        private readonly AppDbContext _context;
        public TodosModel(AppDbContext context) => _context = context;

        public IList<TodoItem> Todos { get; set; } = new List<TodoItem>();

        // Bind das query strings para GET
        [BindProperty(SupportsGet = true)]
        public string? Sort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Order { get; set; } = "asc";

        [BindProperty(SupportsGet = true)]
        public bool ToggleOrder { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.TodoItems.AsQueryable();

            // Filtro
            if (Status == "done")
                query = query.Where(t => t.IsDone);
            else if (Status == "pending")
                query = query.Where(t => !t.IsDone);

            // Ordenação
            if (Sort == "title")
            {
                query = Order == "desc"
                    ? query.OrderByDescending(t => t.Title)
                    : query.OrderBy(t => t.Title);
            }
            else if (Sort == "date")
            {
                query = Order == "desc"
                    ? query.OrderByDescending(t => t.CreatedAt)
                    : query.OrderBy(t => t.CreatedAt);
            }

            Todos = await query.ToListAsync();
        }
    }
}
