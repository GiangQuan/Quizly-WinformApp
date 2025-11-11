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
        private historyControl? _historyControl; // Thêm field
        private readonly QuizlyDbContext _db;


        public MainForm(QuizlyDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            InitializeComponent(); // gọi phiên bản do Designer sinh ra
            // nếu bạn muốn thêm handler cho các control (nếu chưa auto-wire)
            this.Load += MainForm_Load;

            // đảm bảo event handlers cho các nút Designer (nếu chưa có)
            if (logOutBtn != null)
                logOutBtn.Click += logOutBtn_Click;

            // Wire the createBtn click event
            if (createBtn != null)
                createBtn.Click += createBtn_Click;

            // Wire the startBtn click event
            if (startBtn != null)
                startBtn.Click += startBtn_Click;

            // Wire the historyBtn click event
            if (historyBtn != null)
                historyBtn.Click += historyBtn_Click;

   
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            // Hiển thị tên user nếu có
            if (CurrentUser != null && usernameLabel != null)
            {
                usernameLabel.Text = CurrentUser.DisplayName ?? CurrentUser.Email;
                welcomeLabel.Text = $"Welcome back, {CurrentUser.DisplayName ?? CurrentUser.Email}";
            }
        }

        // handler cho logout (designer wired logOutBtn_Click)
        private void logOutBtn_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
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

        // Restore main content
        public void ShowMainContent()
        {
            // Remove create quiz control if exists
            if (_createQuizControl != null)
            {
                contentPanel.Controls.Remove(_createQuizControl);
                _createQuizControl.Dispose();
                _createQuizControl = null;
            }

            // Remove do quiz control if exists
            if (_doQuizControl != null)
            {
                contentPanel.Controls.Remove(_doQuizControl);
                _doQuizControl.Dispose();
                _doQuizControl = null;
            }

            // Remove history control if exists
            if (_historyControl != null)
            {
                contentPanel.Controls.Remove(_historyControl);
                _historyControl.Dispose();
                _historyControl = null;
            }

            // If you need to reload static content designed in Designer,
            // you can call a method to restore / re-add controls.
            // LoadDashboard(); // optional
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

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}