using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Data;
using Quizly.Data.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Quizly.UI
{
    public partial class MainForm : Form
    {
        private readonly QuizlyDbContext _db;
        public User? CurrentUser { get; set; }

        private Guna2GradientPanel bgPanel = null!;
        private Label lblWelcome = null!;
        private Guna2Button btnLogout = null!;
        private Guna2DataGridView quizGrid = null!;
        private Guna2Button btnPlay = null!;
        private Label lblTitle = null!;

        public MainForm(QuizlyDbContext db)
        {
            _db = db;
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "Quizly - Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            // === Gradient Background ===
            bgPanel = new Guna2GradientPanel()
            {
                Dock = DockStyle.Fill,
                FillColor = ColorTranslator.FromHtml("#4A148C"),
                FillColor2 = ColorTranslator.FromHtml("#7B1FA2"),
                GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
            };
            this.Controls.Add(bgPanel);

            // === Title ===
            lblTitle = new Label()
            {
                Text = "Available Quizzes",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };
            bgPanel.Controls.Add(lblTitle);

            // === Welcome label ===
            lblWelcome = new Label()
            {
                Text = "Welcome!",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };
            bgPanel.Controls.Add(lblWelcome);

            // === Logout button ===
            btnLogout = new Guna2Button()
            {
                Text = "Logout",
                Size = new Size(100, 35),
                BorderRadius = 8,
                Location = new Point(670, 15),
                FillColor = Color.FromArgb(255, 64, 129),
                HoverState = { FillColor = Color.FromArgb(244, 67, 54) },
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White
            };
            btnLogout.Click += BtnLogout_Click;
            bgPanel.Controls.Add(btnLogout);

            // === Quiz Grid ===
            quizGrid = new Guna2DataGridView()
            {
                Location = new Point(60, 100),
                Size = new Size(680, 280),
                
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Theme = DataGridViewPresetThemes.DeepPurple,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false
            };
            bgPanel.Controls.Add(quizGrid);

            // === Play button ===
            btnPlay = new Guna2Button()
            {
                Text = "Play Quiz",
                BorderRadius = 10,
                Size = new Size(200, 45),
                Location = new Point(300, 400),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FillColor = ColorTranslator.FromHtml("#673AB7"),
                HoverState = { FillColor = ColorTranslator.FromHtml("#5E35B1") },
                ForeColor = Color.White
            };
            btnPlay.Click += BtnPlay_Click;
            bgPanel.Controls.Add(btnPlay);

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            if (CurrentUser != null)
                lblWelcome.Text = $"Welcome, {CurrentUser.DisplayName}!";

            LoadQuizList();
        }

        private void LoadQuizList()
        {
            var quizzes = _db.Quizzes
                .AsNoTracking()
                .Include(q => q.Questions)
                .Select(q => new
                {
                    q.Id,
                    q.Title,
                    q.Description,
                    QuestionCount = q.Questions.Count,
                    q.IsPublished,
                    q.Tags
                })
                .ToList();

            quizGrid.DataSource = quizzes;
        }

        private void BtnPlay_Click(object? sender, EventArgs e)
        {
            if (quizGrid.CurrentRow == null)
            {
                MessageBox.Show("Please select a quiz to play.");
                return;
            }

            var quizId = (int)quizGrid.CurrentRow.Cells["Id"].Value;
            var quiz = _db.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Choices)
                .FirstOrDefault(q => q.Id == quizId);

            if (quiz == null)
            {
                MessageBox.Show("Quiz not found.");
                return;
            }

            MessageBox.Show($"Starting quiz: {quiz.Title}\nQuestions: {quiz.Questions.Count}");

            // 🚧 Sau này bạn sẽ mở PlayQuizForm tại đây:
            // var playForm = new PlayQuizForm(_db, quiz, CurrentUser);
            // playForm.ShowDialog();
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                using var scope = Program.CreateScope().Services.CreateScope();
                var login = scope.ServiceProvider.GetRequiredService<LoginForm>();
                login.ShowDialog();
                this.Close();
            }
        }
    }
}
