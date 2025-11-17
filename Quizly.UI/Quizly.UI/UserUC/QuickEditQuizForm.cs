using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quizly.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Quizly.UI.UserUC
{
    public class QuickEditQuizForm : Form
    {
        private readonly QuizlyDbContext _db;
        private readonly Quiz _quiz;
        private readonly User _currentUser;

        private TextBox txtTitle;
        private TextBox txtDescription;
        private TextBox txtTags;
        private NumericUpDown nudTimeMinutes;
        private CheckBox chkPublished;
        private Button btnSave;
        private Button btnCancel;

        public QuickEditQuizForm(QuizlyDbContext db, Quiz quiz, User currentUser)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _quiz = quiz ?? throw new ArgumentNullException(nameof(quiz));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            InitializeComponents();
            LoadValues();
        }

        private void InitializeComponents()
        {
            this.Text = "Quick Edit Quiz";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(520, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblTitle = new Label { Text = "Title", Left = 12, Top = 12, AutoSize = true };
            txtTitle = new TextBox { Left = 12, Top = 32, Width = 488 };

            var lblDesc = new Label { Text = "Description", Left = 12, Top = 64, AutoSize = true };
            txtDescription = new TextBox { Left = 12, Top = 84, Width = 488, Height = 80, Multiline = true, ScrollBars = ScrollBars.Vertical };

            var lblTags = new Label { Text = "Tags (comma separated)", Left = 12, Top = 172, AutoSize = true };
            txtTags = new TextBox { Left = 12, Top = 192, Width = 300 };

            var lblTime = new Label { Text = "Time (minutes, 0 = no limit)", Left = 320, Top = 172, AutoSize = true };
            nudTimeMinutes = new NumericUpDown { Left = 320, Top = 192, Width = 80, Minimum = 0, Maximum = 10000 };

            chkPublished = new CheckBox { Text = "Published", Left = 420, Top = 192, AutoSize = true };

            btnSave = new Button { Text = "Save", Left = 320, Top = 240, Width = 80 };
            btnCancel = new Button { Text = "Cancel", Left = 412, Top = 240, Width = 88 };

            btnSave.Click += async (s, e) => await SaveClick();
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] { lblTitle, txtTitle, lblDesc, txtDescription, lblTags, txtTags, lblTime, nudTimeMinutes, chkPublished, btnSave, btnCancel });
        }

        private void LoadValues()
        {
            txtTitle.Text = _quiz.Title;
            txtDescription.Text = _quiz.Description;
            txtTags.Text = _quiz.Tags;
            nudTimeMinutes.Value = _quiz.TimeLimitSeconds / 60;
            chkPublished.Checked = _quiz.IsPublished;
        }

        private async Task SaveClick()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            try
            {
                // Reload entity in case it's detached
                var quizEntity = await _db.Quizzes.FirstOrDefaultAsync(q => q.Id == _quiz.Id);
                if (quizEntity == null)
                {
                    MessageBox.Show("Quiz not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Permission check: only owner or admin/creator can edit
                if (_currentUser.Id != quizEntity.CreatedById && _currentUser.Role != Role.Admin && _currentUser.Role != Role.Creator)
                {
                    MessageBox.Show("You do not have permission to edit this quiz.", "Permission denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                quizEntity.Title = txtTitle.Text.Trim();
                quizEntity.Description = txtDescription.Text.Trim();
                quizEntity.Tags = txtTags.Text.Trim();
                quizEntity.TimeLimitSeconds = (int)nudTimeMinutes.Value * 60;
                quizEntity.IsPublished = chkPublished.Checked;

                await _db.SaveChangesAsync();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving quiz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}