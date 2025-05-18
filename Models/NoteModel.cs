using System.ComponentModel.DataAnnotations;

namespace NoteMe.Models;

public class Note
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; }

    [MaxLength(200)] public string Summary { get; set; }

    public string Details { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}