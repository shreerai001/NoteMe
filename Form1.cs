using NoteMe.Controllers;
using NoteMe.Models;

namespace NoteMe;

public partial class Form1 : Form
{
    private readonly NoteController _noteController;
    private int? _currentNoteId;
    private bool _isNewNote;

    public Form1()
    {
        InitializeComponent();
        _noteController = new NoteController();
        RefreshNotesList();
    }

    private void RefreshNotesList()
    {
        listBoxNotes.DataSource = null;
        listBoxNotes.DataSource = _noteController.GetAllNotes();
        listBoxNotes.DisplayMember = "Title";
        listBoxNotes.ValueMember = "Id";
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Title is required!");
            return;
        }

        if (!_isNewNote && _currentNoteId.HasValue)
            _noteController.UpdateNote(_currentNoteId.Value, txtTitle.Text, txtSummary.Text, txtDetails.Text);
        else
            await _noteController.AddNoteAsync(txtTitle.Text, txtSummary.Text, txtDetails.Text);

        _isNewNote = false;
        ClearFields();
        RefreshNotesList();
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        _isNewNote = true;
        listBoxNotes.SelectedIndex = -1;
        ClearFields();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_currentNoteId.HasValue)
            if (MessageBox.Show("Are you sure you want to delete this note?", "Confirm Delete",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _noteController.DeleteNote(_currentNoteId.Value);
                ClearFields();
                RefreshNotesList();
            }
    }

    private void listBoxNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_isNewNote) return;

        if (listBoxNotes.SelectedItem is Note selectedNote)
        {
            _currentNoteId = selectedNote.Id;
            txtTitle.Text = selectedNote.Title;
            txtSummary.Text = selectedNote.Summary;
            txtDetails.Text = selectedNote.Details;
        }
    }

    private void ClearFields()
    {
        _currentNoteId = null;
        txtTitle.Text = string.Empty;
        txtSummary.Text = string.Empty;
        txtDetails.Text = string.Empty;
    }
}