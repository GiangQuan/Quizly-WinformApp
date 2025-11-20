using Microsoft.EntityFrameworkCore;
using Quizly.Data;
using Quizly.Data.Models;
using Quizly.UI.UserUC;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Quizly.UI
{
    public partial class MainForm : Form
    {
        public User? CurrentUser { get; set; }
        private createQuizzControl? _createQuizControl;
        private doQuizzControl? _doQuizControl;
        private historyControl? _historyControl;
        private analyticControl? _analyticControl;
        private AdminPanelControl? _adminPanelControl;
        private UserManagementControl? _userManagementControl;
        private readonly QuizlyDbContext _db;


        public MainForm(QuizlyDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            InitializeComponent();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            // Hiển thị tên user nếu có
            if (CurrentUser != null && usernameLabel != null)
            {
                usernameLabel.Text = CurrentUser.DisplayName ?? CurrentUser.Email;
                welcomeLabel.Text = $"Welcome back, {CurrentUser.DisplayName ?? CurrentUser.Email}";
            }

            // Show admin button only for admin users
            if (adminBtn != null && CurrentUser != null)
            {
                adminBtn.Visible = CurrentUser.Role == Role.Admin;
            }

            // Load recent quizzes
            LoadRecentQuizzes();
        }

        private void LoadRecentQuizzes()
        {
            if (CurrentUser == null) return;

            try
            {
                var recentResults = _db.Results
                    .AsNoTracking()
                    .Where(r => r.UserId == CurrentUser.Id)
                    .Include(r => r.Quiz)
                    .OrderByDescending(r => r.TakenAt)
                    .Take(2)
                    .ToList();

                var containerPanel = contentPanel.Controls.OfType<Guna.UI2.WinForms.Guna2GradientPanel>()
                    .FirstOrDefault(p => p.Controls.OfType<Guna.UI2.WinForms.Guna2HtmlLabel>()
                        .Any(l => l.Text == "Your recently quizz"));

                if (containerPanel == null) return;

                ClearOldPanels(containerPanel);

                if (!recentResults.Any())
                {
                    ShowNoQuizzesMessage(containerPanel);
                    return;
                }

                AddRecentQuizPanels(containerPanel, recentResults);
            }
            catch (Exception ex)
            {
                ShowError($"Error loading recent quizzes: {ex.Message}");
            }
        }

        private void ClearOldPanels(Control containerPanel)
        {
            var panelsToRemove = containerPanel.Controls.OfType<Guna.UI2.WinForms.Guna2GradientPanel>().ToList();
            foreach (var panel in panelsToRemove)
            {
                containerPanel.Controls.Remove(panel);
                panel.Dispose();
            }
        }

        private void ShowNoQuizzesMessage(Control containerPanel)
        {
            var noQuizLabel = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(23, 57),
                Text = "No recent quizzes. Start taking quizzes to see them here!",
                AutoSize = true
            };
            containerPanel.Controls.Add(noQuizLabel);
        }

        private void AddRecentQuizPanels(Control containerPanel, List<Result> results)
        {
            int yPosition = 57;
            foreach (var result in results)
            {
                var quizPanel = CreateRecentQuizPanel(result);
                quizPanel.Location = new Point(23, yPosition);
                containerPanel.Controls.Add(quizPanel);
                quizPanel.BringToFront();
                yPosition += 95;
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Guna.UI2.WinForms.Guna2GradientPanel CreateRecentQuizPanel(Result result)
        {
            var panel = new Guna.UI2.WinForms.Guna2GradientPanel
            {
                BackColor = System.Drawing.Color.Transparent,
                BorderRadius = 15,
                Size = new System.Drawing.Size(903, 82),
                FillColor = System.Drawing.Color.White,
                FillColor2 = System.Drawing.Color.White
            };

            // Enable shadow
            panel.ShadowDecoration.Enabled = true;
            panel.ShadowDecoration.BorderRadius = 20;
            panel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(90, 78, 195);
            panel.ShadowDecoration.Depth = 200;
            panel.ShadowDecoration.Shadow = new Padding(0, 10, 0, 0);

            // Quiz title
            var titleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic),
                ForeColor = System.Drawing.Color.FromArgb(76, 62, 147),
                Location = new System.Drawing.Point(11, 6),
                Text = result.Quiz.Title,
                AutoSize = true
            };

            // Quiz description/score
            var scoreText = $"Score: {result.Score}/{result.MaxScore} - {(result.Score / result.MaxScore * 100):F0}%";
            var descLabel = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(76, 62, 147),
                Location = new System.Drawing.Point(14, 37),
                Text = scoreText,
                AutoSize = true
            };

            // Progress bar
            var progressBar = new Guna.UI2.WinForms.Guna2ProgressBar
            {
                BorderRadius = 4,
                Location = new System.Drawing.Point(15, 64),
                Size = new System.Drawing.Size(863, 6),
                ProgressColor = System.Drawing.Color.FromArgb(103, 93, 238),
                ProgressColor2 = System.Drawing.Color.FromArgb(76, 62, 147),
                Value = (int)(result.Score / result.MaxScore * 100)
            };

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(descLabel);
            panel.Controls.Add(progressBar);

            // Make panel clickable to view details
            panel.Cursor = Cursors.Hand;
            panel.Click += (s, e) => ShowQuizResultDetails(result.Id);

            return panel;
        }

        private void ShowQuizResultDetails(int resultId)
        {
            try
            {
                var result = _db.Results
                    .AsNoTracking()
                    .Include(r => r.Quiz)
                    .FirstOrDefault(r => r.Id == resultId);

                if (result == null)
                {
                    ShowError("Quiz result not found.");
                    return;
                }

                var percentage = result.MaxScore > 0 ? (result.Score / result.MaxScore * 100) : 0;
                var message = $"Quiz: {result.Quiz.Title}\n" +
                             $"Score: {result.Score}/{result.MaxScore} ({percentage:F1}%)\n" +
                             $"Duration: {result.Duration.TotalMinutes:F1} minutes\n" +
                             $"Taken: {result.TakenAt:g}";

                MessageBox.Show(message, "Quiz Result Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError($"Error loading result details: {ex.Message}");
            }
        }

        // Show analytics control
        private void ShowAnalyticControl()
        {
            if (_analyticControl != null) return;

            _analyticControl = new analyticControl(_db, CurrentUser);
            _analyticControl.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(_analyticControl);
            _analyticControl.BringToFront();
        }

        // handler cho logout (designer wired logOutBtn_Click)
        private void logOutBtn_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Close the MainForm so the LoginForm.ShowDialog() returns to the login form.
                this.Close();
            }
        }

        // Show create quiz UC
        private void ShowCreateQuizControl()
        {
            if (_createQuizControl != null) return;

            // Pass database context and current user to the control
            _createQuizControl = new createQuizzControl(_db, CurrentUser);
            ((Control)_createQuizControl).Dock = DockStyle.Fill;

            contentPanel.Controls.Add((Control)_createQuizControl);
            ((Control)_createQuizControl).BringToFront();
        }

        // Show do quiz UC
        private void ShowDoQuizControl()
        {
            if (_doQuizControl != null) return;

            // Pass database context and current user to the control
            _doQuizControl = new doQuizzControl(_db, CurrentUser);
            ((Control)_doQuizControl).Dock = DockStyle.Fill;


            contentPanel.Controls.Add(_doQuizControl);
            _doQuizControl.BringToFront();
        }

        // Thêm method để show history
        private void ShowHistoryControl()
        {
            if (_historyControl != null) return;

            // Pass database context and current user to the control
            _historyControl = new historyControl(_db, CurrentUser);
            _historyControl.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(_historyControl);
            _historyControl.BringToFront();
        }

        public void ShowMainContent()
        {
            DisposeControl(ref _createQuizControl);
            DisposeControl(ref _doQuizControl);
            DisposeControl(ref _historyControl);
            DisposeControl(ref _analyticControl);
            DisposeControl(ref _adminPanelControl);
            DisposeControl(ref _userManagementControl);
        }

        private void DisposeControl<T>(ref T? control) where T : Control
        {
            if (control != null)
            {
                contentPanel.Controls.Remove(control);
                control.Dispose();
                control = null;
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            ShowCreateQuizControl();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            ShowDoQuizControl();
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            ShowHistoryControl();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e) { }

        private void anaBtn_Click(object sender, EventArgs e)
        {
            ShowAnalyticControl();
        }

        // Call this method from a button or menu when you add the admin button
        public void ShowAdminPanel()
        {
            if (CurrentUser?.Role != Role.Admin)
            {
                MessageBox.Show("Access denied. Admin privileges required.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowAdminControl("panel");
        }

        public void ShowAdminControl(string section)
        {
            // Clear all existing controls
            ShowMainContent();

            switch (section.ToLower())
            {
                case "panel":
                    if (_adminPanelControl == null)
                    {
                        _adminPanelControl = new AdminPanelControl(_db, CurrentUser!);
                        _adminPanelControl.Dock = DockStyle.Fill;
                        contentPanel.Controls.Add(_adminPanelControl);
                        _adminPanelControl.BringToFront();
                    }
                    break;

                case "users":
                    if (_userManagementControl == null)
                    {
                        _userManagementControl = new UserManagementControl(_db, CurrentUser!);
                        _userManagementControl.Dock = DockStyle.Fill;
                        contentPanel.Controls.Add(_userManagementControl);
                        _userManagementControl.BringToFront();
                    }
                    break;

                case "quizzes":
                    // Reuse existing create quiz control for now
                    ShowCreateQuizControl();
                    break;

                case "analytics":
                    ShowAnalyticControl();
                    break;
            }
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            ShowAdminPanel();
        }
    }
}