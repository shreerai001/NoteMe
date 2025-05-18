using NoteMe.Models;

namespace NoteMe.Services;

public interface INoteService
{
    List<Note> GetAllNotes();
    Note? GetNote(int id);
    Task<Note> AddNoteAsync(string title, string summary, string details, bool generateSummaryIfEmpty = true);
    void UpdateNote(int id, string title, string summary, string details);
    void DeleteNote(int id);
    Task<string> GenerateSummaryFromDetailsAsync(string details);
}