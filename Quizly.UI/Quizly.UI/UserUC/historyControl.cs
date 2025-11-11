using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using Quizly.Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizly.UI.UserUC
{
    public partial class historyControl : UserControl
    {
        private readonly QuizlyDbContext _db;
        private readonly User _currentUser;
        private FlowLayoutPanel historyListPanel;

        // Constructor with dependency injection
        public historyControl(QuizlyDbContext db, User currentUser)
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

            // Initialize FlowLayoutPanel for history list
            InitializeHistoryListPanel();
        }

        // Parameterless constructor for Designer support
        public historyControl()
        {
            InitializeComponent();
            InitializeHistoryListPanel();
        }

        private void InitializeHistoryListPanel()
        {
            // Hide the original quizzPanel (it's just a template)
            if (quizzPanel != null)
            {
                quizzPanel.Visible = false;
            }

            // Create FlowLayoutPanel to hold multiple history panels
            historyListPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Dock = DockStyle.None,
                Location = new Point(26, 94),
                Width = this.Width - 52,
                Height = this.Height - 120,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.Transparent
            };

            this.Controls.Add(historyListPanel);
            historyListPanel.BringToFront();
        }

        private async void historyControl_Load(object sender, EventArgs e)
        {
            if (_db != null)
            {
                await LoadHistoryAsync();
            }
        }

        private async Task LoadHistoryAsync()
        {
            try
            {
                // Clear existing panels
                historyListPanel.Controls.Clear();

                // Show loading indicator
                var loadingLabel = new Guna2HtmlLabel
                {
                    Text = "Loading quiz history...",
                    Font = new Font("Segoe UI", 14F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(79, 65, 159),
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                historyListPanel.Controls.Add(loadingLabel);

                // Fetch all completed quizzes for current user
                var results = await _db.Results
                    .Include(r => r.Quiz)
                    .Where(r => r.UserId == _currentUser.Id)
                    .OrderByDescending(r => r.TakenAt)
                    .ToListAsync();

                // Remove loading label
                historyListPanel.Controls.Remove(loadingLabel);

                // Check if there are any results
                if (results == null || results.Count == 0)
                {
                    var noHistoryLabel = new Guna2HtmlLabel
                    {
                        Text = "You haven't completed any quizzes yet.",
                        Font = new Font("Segoe UI", 14F, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Margin = new Padding(10)
                    };
                    historyListPanel.Controls.Add(noHistoryLabel);
                    return;
                }

                // Create a panel for each result
                foreach (var result in results)
                {
                    var panel = CreateHistoryPanel(result);
                    historyListPanel.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading quiz history: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private Guna2Panel CreateHistoryPanel(Result result)
        {
            // Create main panel
            var panel = new Guna2Panel
            {
                Width = historyListPanel.Width - 30,
                Height = 130,
                BorderRadius = 17,
                FillColor = Color.White,
                Margin = new Padding(5, 5, 5, 10),
                Tag = result
            };

            // Enable shadow
            panel.ShadowDecoration.Enabled = true;
            panel.ShadowDecoration.Color = Color.DimGray;
            panel.ShadowDecoration.Depth = 10;
            panel.ShadowDecoration.BorderRadius = 15;

            // Title label
            var titleLabel = new Guna2HtmlLabel
            {
                Text = result.Quiz?.Title ?? "Unknown Quiz",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(79, 65, 159),
                Location = new Point(20, 15),
                AutoSize = true,
                Parent = panel
            };

            // Calculate score percentage
            decimal scorePercentage = result.MaxScore > 0
                ? (result.Score / result.MaxScore) * 100
                : 0;

            // Score label
            var scoreLabel = new Guna2HtmlLabel
            {
                Text = $"Score: {scorePercentage:F1}%",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = GetScoreColor(scorePercentage),
                Location = new Point(20, 50),
                AutoSize = true,
                Parent = panel
            };

            // Progress bar
            var progressBar = new Guna2ProgressBar
            {
                Location = new Point(20, 85),
                Size = new Size(550, 10),
                BorderRadius = 5,
                ProgressColor = GetScoreColor(scorePercentage),
                ProgressColor2 = GetScoreColor(scorePercentage),
                Value = (int)Math.Min(scorePercentage, 100),
                Parent = panel
            };

            // Date/Time label
            var dateLabel = new Guna2HtmlLabel
            {
                Text = $"📅 {result.TakenAt:MMM dd, yyyy} • ⏱️ {result.Duration.Minutes}m {result.Duration.Seconds}s",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 120),
                Location = new Point(20, 105),
                AutoSize = true,
                Parent = panel
            };

            // View Details button
            var detailsBtn = new Guna2GradientButton
            {
                Text = "Details",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(76, 62, 147),
                FillColor2 = Color.FromArgb(103, 93, 238),
                BorderRadius = 25,
                Size = new Size(100, 60),
                Location = new Point(panel.Width - 120, 35),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = result,
                Parent = panel
            };

            detailsBtn.Click += DetailsBtn_Click;

            return panel;
        }

        private Color GetScoreColor(decimal scorePercentage)
        {
            if (scorePercentage >= 80)
                return Color.FromArgb(46, 213, 115); // Green
            else if (scorePercentage >= 60)
                return Color.FromArgb(255, 195, 18); // Yellow/Orange
            else if (scorePercentage >= 40)
                return Color.FromArgb(255, 159, 67); // Orange
            else
                return Color.FromArgb(235, 77, 75); // Red
        }

        private void DetailsBtn_Click(object? sender, EventArgs e)
        {
            if (sender is Guna2GradientButton button && button.Tag is Result result)
            {
                // Load detailed results
                var detailsMessage = $"Quiz: {result.Quiz?.Title}\n\n" +
                                   $"Score: {(result.Score / result.MaxScore * 100):F1}%\n" +
                                   $"Points: {result.Score}/{result.MaxScore}\n" +
                                   $"Duration: {result.Duration.Minutes}m {result.Duration.Seconds}s\n" +
                                   $"Date: {result.TakenAt:MMM dd, yyyy HH:mm}";

                MessageBox.Show(detailsMessage, "Quiz Details",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainForm;

            if (mainForm != null)
            {
                // Call ShowMainContent to restore the main view
                mainForm.ShowMainContent();
            }
        }
    }
}