namespace NoteMe
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();

            // Modern font and colors
            var modernFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            this.listBoxNotes.Font = modernFont;
            this.listBoxNotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtTitle.Font = modernFont;
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtSummary.Font = modernFont;
            this.txtSummary.BackColor = System.Drawing.Color.White;
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtDetails.Font = modernFont;
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnNew.Font = modernFont;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.FlatAppearance.BorderSize = 0;

            this.btnSave.Font = modernFont;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 153, 51);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;

            this.btnDelete.Font = modernFont;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;

            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Font = this.label1.Font;
            this.label3.Font = this.label1.Font;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.label2.ForeColor = this.label1.ForeColor;
            this.label3.ForeColor = this.label1.ForeColor;

            this.listBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxNotes.Location = new System.Drawing.Point(12, 12);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(200, 420);
            this.listBoxNotes.TabIndex = 0;
            this.listBoxNotes.SelectedIndexChanged += new System.EventHandler(this.listBoxNotes_SelectedIndexChanged);

            // Adjusted vertical spacing for better alignment
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.Text = "Title:";

            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(220, 38);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(552, 27);
            this.txtTitle.TabIndex = 1;

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.Text = "Summary:";

            this.txtSummary.Anchor = this.txtTitle.Anchor;
            this.txtSummary.Location = new System.Drawing.Point(220, 98);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(552, 27);
            this.txtSummary.TabIndex = 2;

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.Text = "Details:";

            this.txtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetails.Location = new System.Drawing.Point(220, 158);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(552, 235);
            this.txtDetails.TabIndex = 3;

            int buttonWidth = 100;
            int buttonHeight = 32;
            int buttonSpacing = 16;
            int buttonY = 409;
            this.btnNew.Location = new System.Drawing.Point(220, buttonY);
            this.btnNew.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnSave.Location = new System.Drawing.Point(220 + buttonWidth + buttonSpacing, buttonY);
            this.btnSave.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnDelete.Location = new System.Drawing.Point(220 + 2 * (buttonWidth + buttonSpacing), buttonY);
            this.btnDelete.Size = new System.Drawing.Size(buttonWidth, buttonHeight);

            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnNew.Name = "btnNew";
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.listBoxNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "Form1";
            this.Text = "NoteMe";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
