using System;
using System.ComponentModel.DataAnnotations;

namespace TaskWeb.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
