namespace TaskWeb.Models
{
    public class TodoItem
    {
        public int Id { get; set; }          // Chave primária
        public string? Title { get; set; }   // Nome da tarefa
        public bool IsDone { get; set; }     // Status da tarefa
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Data de criação
    }
}
