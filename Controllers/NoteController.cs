using NoteMe.Data;
using NoteMe.Services;
using NoteMe.Models;

namespace NoteMe.Controllers;

public class NoteController : IDisposable
{
    private readonly INoteService _noteService;
    private bool _disposed;

    public NoteController()
    {
        _noteService = new NoteService(new NoteMeContext());
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public List<Note> GetAllNotes()
    {
        return _noteService.GetAllNotes();
    }

    public Note? GetNote(int id)
    {
        return _noteService.GetNote(id);
    }

    public async Task<Note> AddNoteAsync(string title, string summary, string details,
        bool generateSummaryIfEmpty = true)
    {
        return await _noteService.AddNoteAsync(title, summary, details, generateSummaryIfEmpty);
    }

    public void UpdateNote(int id, string title, string summary, string details)
    {
        _noteService.UpdateNote(id, title, summary, details);
    }

    public void DeleteNote(int id)
    {
        _noteService.DeleteNote(id);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing && _noteService is IDisposable disposableService) disposableService.Dispose();
            _disposed = true;
        }
    }
}