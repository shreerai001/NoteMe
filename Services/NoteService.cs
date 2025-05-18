using Microsoft.EntityFrameworkCore;
using NoteMe.Data;
using NoteMe.Models;

namespace NoteMe.Services;

public class NoteService : INoteService, IDisposable
{
    private readonly NoteMeContext _context;
    private bool _disposed;

    public NoteService(NoteMeContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public List<Note> GetAllNotes()
    {
        return _context.Notes
            .AsNoTracking()
            .OrderByDescending(n => n.CreatedAt)
            .ToList();
    }

    public Note? GetNote(int id)
    {
        return _context.Notes
            .AsNoTracking()
            .FirstOrDefault(n => n.Id == id);
    }

    public async Task<Note> AddNoteAsync(string title, string summary, string details,
        bool generateSummaryIfEmpty = true)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Note title cannot be empty or whitespace.", nameof(title));

        if (generateSummaryIfEmpty && string.IsNullOrWhiteSpace(summary) && !string.IsNullOrWhiteSpace(details))
            try
            {
                summary = await GenerateSummaryFromDetailsAsync(details);
            }
            catch
            {
                summary = string.Empty;
            }

        var note = new Note
        {
            Title = title.Trim(),
            Summary = summary?.Trim() ?? string.Empty,
            Details = details?.Trim() ?? string.Empty,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
        _context.Entry(note).State = EntityState.Detached;
        return note;
    }

    public void UpdateNote(int id, string title, string summary, string details)
    {
        var note = _context.Notes.Find(id);
        if (note != null)
        {
            note.Title = title;
            note.Summary = summary;
            note.Details = details;
            note.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            _context.Entry(note).State = EntityState.Detached;
        }
    }

    public void DeleteNote(int id)
    {
        var note = _context.Notes.Find(id);
        if (note != null)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }

    public async Task<string> GenerateSummaryFromDetailsAsync(string details)
    {
        var apiHelper = new OpenAIApiHelper();
        return await apiHelper.GenerateSummaryAsync(details);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing) _context.Dispose();
            _disposed = true;
        }
    }
}