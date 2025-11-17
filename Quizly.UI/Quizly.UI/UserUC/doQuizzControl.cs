using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using Quizly.UI.UserUC;

using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using Quizly.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizly.UI.UserUC
{
    public partial class doQuizzControl : UserControl
    {
        private readonly QuizlyDbContext _db;
        private readonly User _currentUser;
        private FlowLayoutPanel quizListPanel;

        // cached quizzes loaded from DB (used for client-side search)
        private List<Quiz> _loadedQuizzes = new List<Quiz>();

        // Constructor with dependency injection
        public doQuizzControl(QuizlyDbContext db, User currentUser)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            InitializeComponent();

            // Enable double buffering for smooth scrolling
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Initialize FlowLayoutPanel for quiz list
            InitializeQuizListPanel();
        }

        // Parameterless constructor for Designer support
        public doQuizzControl()
        {
            InitializeComponent();
            InitializeQuizListPanel();
        }

        private void InitializeQuizListPanel()
        {
            // Hide the original quizzPanel (it's just a template)
            if (quizzPanel != null)
            {
                quizzPanel.Visible = false;
            }

            // Create FlowLayoutPanel to hold multiple quiz panels
            quizListPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Dock = DockStyle.None,
                Location = new Point(26, 94),
                Width = this.Width - 52, // Account for margins
                Height = this.Height - 120,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.Transparent
            };

            this.Controls.Add(quizListPanel);
            quizListPanel.BringToFront();
        }

        private async void doQuizzControl_Load(object sender, EventArgs e)
        {
            if (_db != null)
            {
                await LoadQuizzesAsync();
            }
        }

        private async Task LoadQuizzesAsync()
        {
            try
            {
                // Clear existing panels and show loading indicator
                quizListPanel.Controls.Clear();
                var loadingLabel = new Guna2HtmlLabel
                {
                    Text = "Loading quizzes...",
                    Font = new Font("Segoe UI", 14F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(79, 65, 159),
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                quizListPanel.Controls.Add(loadingLabel);

                // Always include navigation properties we need
                IQueryable<Quiz> query = _db.Quizzes.Include(q => q.CreatedBy).Include(q => q.Questions);

                if (_currentUser != null)
                {
                    // Show only quizzes that belong to the signed-in user
                    query = query.Where(q => q.CreatedById == _currentUser.Id);
                }
                else
                {
                    // Not logged in — show only published quizzes
                    query = query.Where(q => q.IsPublished);
                }

                var quizzes = await query
                    .OrderByDescending(q => q.Id)
                    .ToListAsync();

                // cache quizzes for client-side search
                _loadedQuizzes = quizzes ?? new List<Quiz>();

                // Render quizzes
                RenderQuizzes(_loadedQuizzes);

                // Remove loading label if still present
                if (quizListPanel.Controls.Contains(loadingLabel))
                    quizListPanel.Controls.Remove(loadingLabel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading quizzes: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Render the provided quizzes into the UI (reusable for search results)
        private void RenderQuizzes(IEnumerable<Quiz> quizzes)
        {
            quizListPanel.Controls.Clear();

            var list = quizzes?.ToList() ?? new List<Quiz>();
            if (list.Count == 0)
            {
                var noQuizLabel = new Guna2HtmlLabel
                {
                    Text = "No quizzes available at the moment.",
                    Font = new Font("Segoe UI", 14F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                quizListPanel.Controls.Add(noQuizLabel);
                return;
            }

            foreach (var quiz in list)
            {
                var panel = CreateQuizPanel(quiz);
                quizListPanel.Controls.Add(panel);
            }
        }

        private Guna2Panel CreateQuizPanel(Quiz quiz)
        {
            // Create main panel
            var panel = new Guna2Panel
            {
                Width = quizListPanel.Width - 30,
                Height = 130,
                BorderRadius = 17,
                FillColor = Color.White,
                Margin = new Padding(5, 5, 5, 10),
                Tag = quiz // Store quiz object in Tag for later use
            };

            // Enable shadow
            panel.ShadowDecoration.Enabled = true;
            panel.ShadowDecoration.Color = Color.DimGray;
            panel.ShadowDecoration.Depth = 10;
            panel.ShadowDecoration.BorderRadius = 15;

            // Title label
            var titleLabel = new Guna2HtmlLabel
            {
                Text = quiz.Title,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(79, 65, 159),
                Location = new Point(20, 15),
                AutoSize = true,
                Parent = panel
            };

            // Description label
            var descriptionText = string.IsNullOrWhiteSpace(quiz.Description)
                ? "No description available"
                : (quiz.Description.Length > 100
                    ? quiz.Description.Substring(0, 100) + "..."
                    : quiz.Description);

            var descLabel = new Guna2HtmlLabel
            {
                Text = descriptionText,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                Location = new Point(20, 50),
                AutoSize = true,
                MaximumSize = new Size(550, 0),
                Parent = panel
            };

            // Info label (questions count, time limit, tags)
            var questionCount = quiz.Questions?.Count ?? 0;
            var timeLimit = quiz.TimeLimitSeconds > 0
                ? $"{quiz.TimeLimitSeconds / 60} min"
                : "No limit";
            var tags = string.IsNullOrWhiteSpace(quiz.Tags) ? "" : $"• {quiz.Tags}";

            var infoLabel = new Guna2HtmlLabel
            {
                Text = $"📝 {questionCount} question(s) • ⏱️ {timeLimit} {tags}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 120),
                Location = new Point(20, 85),
                AutoSize = true,
                Parent = panel
            };

            // Created by label
            var createdByText = quiz.CreatedBy?.DisplayName ?? "Unknown";
            var createdByLabel = new Guna2HtmlLabel
            {
                Text = $"By: {createdByText}",
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(150, 150, 150),
                Location = new Point(20, 105),
                AutoSize = true,
                Parent = panel
            };

            // Start button
            var startBtn = new Guna2GradientButton
            {
                Text = "Start",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(76, 62, 147),
                FillColor2 = Color.FromArgb(103, 93, 238),
                BorderRadius = 25,
                Size = new Size(100, 70),
                Location = new Point(panel.Width - 240, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = quiz,
                Parent = panel
            };

            startBtn.Click += StartQuiz_Click;

            // Edit button (visible only to owner / creator / admin)
            var editBtn = new Guna2GradientButton
            {
                Text = "Edit",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(95, 95, 95),
                FillColor2 = Color.FromArgb(70, 70, 70),
                BorderRadius = 12,
                Size = new Size(70, 34),
                Location = new Point(panel.Width - 120, 38),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = quiz,
                Parent = panel
            };

            // Permission: only show edit if current user is owner or has Creator/Admin role
            if (_currentUser != null && (_currentUser.Role == Role.Admin || _currentUser.Role == Role.Creator || quiz.CreatedById == _currentUser.Id))
            {
                editBtn.Visible = true;
                editBtn.Click += (s, e) => OpenQuickEdit(quiz);
            }
            else
            {
                editBtn.Visible = false;
            }

            panel.Controls.Add(startBtn);
            panel.Controls.Add(editBtn);

            return panel;
        }

        private async void OpenQuickEdit(Quiz quiz)
        {
            // Quick edit dialog edits and saves directly to DB
            using (var dlg = new QuickEditQuizForm(_db, quiz, _currentUser))
            {
                var res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    // reload quizzes to reflect changes
                    await LoadQuizzesAsync();
                }
            }
        }

        private async void StartQuiz_Click(object sender, EventArgs e)
        {
            if (sender is Guna2GradientButton button && button.Tag is Quiz quiz)
            {
                try
                {
                    // ✅ Sử dụng async để không block UI
                    var questionsCount = await _db.Questions
                        .Where(q => q.QuizId == quiz.Id)
                        .CountAsync();

                    // Validate quiz has questions
                    if (questionsCount == 0)
                    {
                        MessageBox.Show(
                            "This quiz has no questions yet. Please add questions before starting.",
                            "Cannot Start Quiz",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    var mainForm = this.FindForm() as MainForm;

                    if (mainForm != null)
                    {
                        // Create and show QuizzForm with the selected quiz
                        var quizzForm = new QuizzForm(_db, quiz, _currentUser);

                        // Hide MainForm
                        mainForm.Hide();

                        // Show QuizzForm as a modal dialog to keep it open until user finishes
                        quizzForm.ShowDialog(mainForm);

                        // After dialog closes, show MainForm again and reload quizzes
                        mainForm.Show();
                        await LoadQuizzesAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error starting quiz: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainForm;

            if (mainForm != null)
            {
                // Call ShowMainContent to restore the main view
                mainForm.ShowMainContent();
            }
        }

        // searchTxt is used as a fuzzy-ish search box (client-side filter of the last loaded list)
        private async void searchTxt_TextChanged(object sender, EventArgs e)
        {
            // if quizzes not yet loaded, load them first
            if (_loadedQuizzes == null || _loadedQuizzes.Count == 0)
            {
                await LoadQuizzesAsync();
            }

            var query = (searchTxt?.Text ?? "").Trim();
            if (string.IsNullOrEmpty(query))
            {
                RenderQuizzes(_loadedQuizzes);
                return;
            }

            // split into tokens and require each token to be present in title/description/tags (case-insensitive)
            var tokens = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(t => t.Trim())
                              .Where(t => t.Length > 0)
                              .ToArray();

            var filtered = _loadedQuizzes.Where(q =>
            {
                var hay = (q.Title ?? "") + " " + (q.Description ?? "") + " " + (q.Tags ?? "");
                return tokens.All(tok => hay.IndexOf(tok, StringComparison.OrdinalIgnoreCase) >= 0)
                       // also allow partial-match alternative (any token starts with)
                       || tokens.Any(tok => (q.Title ?? "").IndexOf(tok, StringComparison.OrdinalIgnoreCase) >= 0);
            }).ToList();

            RenderQuizzes(filtered);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {

        }
    }
}