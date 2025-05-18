using NoteMe.Controllers;
using NoteMe.Models;

namespace NoteMe;

public partial class NotesView : Form
{
    private readonly NoteController _noteController;
    private int? _currentNoteId;
    private bool _isNewNote;
    private Form? _loadingForm;

    public NotesView()
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

        bool needsSummary = string.IsNullOrWhiteSpace(txtSummary.Text) && !string.IsNullOrWhiteSpace(txtDetails.Text);
        if (needsSummary)
        {
            ShowLoadingScreen();
        }

        if (!_isNewNote && _currentNoteId.HasValue)
            _noteController.UpdateNote(_currentNoteId.Value, txtTitle.Text, txtSummary.Text, txtDetails.Text);
        else
            await _noteController.AddNoteAsync(txtTitle.Text, txtSummary.Text, txtDetails.Text);

        if (needsSummary)
        {
            HideLoadingScreen();
        }

        _isNewNote = false;
        ClearFields();
        RefreshNotesList();
        MessageBox.Show("Note saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ShowLoadingScreen()
    {
        _loadingForm = new Form
        {
            Size = new System.Drawing.Size(250, 100),
            StartPosition = FormStartPosition.Manual,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            ControlBox = false,
            Text = "Please wait..."
        };
        // Center the loading form on the parent (main) form
        var parent = this;
        int x = parent.Location.X + (parent.Width - _loadingForm.Width) / 2;
        int y = parent.Location.Y + (parent.Height - _loadingForm.Height) / 2;
        _loadingForm.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

        var label = new Label
        {
            Text = "Generating summary...",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 11F, FontStyle.Regular)
        };
        _loadingForm.Controls.Add(label);
        _loadingForm.Show(parent);
        _loadingForm.Refresh();
    }

    private void HideLoadingScreen()
    {
        if (_loadingForm != null)
        {
            _loadingForm.Close();
            _loadingForm.Dispose();
            _loadingForm = null;
        }
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