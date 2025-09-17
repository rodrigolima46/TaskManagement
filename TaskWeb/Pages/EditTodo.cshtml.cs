using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskWeb.Data;
using TaskWeb.Models;

namespace TaskWeb.Pages
{
    public class EditTodoModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditTodoModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TodoItem Todo { get; set; } = new TodoItem();

        // Carrega a tarefa pelo id
        public IActionResult OnGet(int id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            Todo = todo;
            return Page();
        }

        // Atualiza a tarefa no banco
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var todoInDb = _context.TodoItems.Find(Todo.Id);
            if (todoInDb == null)
            {
                return NotFound();
            }

            todoInDb.Title = Todo.Title;
            _context.SaveChanges();

            return RedirectToPage("/Todos");
        }
    }
}
