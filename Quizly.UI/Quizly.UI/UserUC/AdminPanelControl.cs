using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Quizly.Data.Models;

namespace Quizly.UI.UserUC
{
    public partial class AdminPanelControl : UserControl
    {
        private readonly QuizlyDbContext _db;
        private readonly User _currentUser;

        public AdminPanelControl()
        {
            InitializeComponent();
        }

        public AdminPanelControl(QuizlyDbContext db, User currentUser) : this()
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadDashboardStats();
        }

        private async void LoadDashboardStats()
        {
            if (_db == null) return;

            try
            {
                var totalUsers = await _db.Users.CountAsync();
                var totalQuizzes = await _db.Quizzes.CountAsync();
                var totalAttempts = await _db.Results.CountAsync();
                var totalQuestions = await _db.Questions.CountAsync();

                lblTotalUsersValue.Text = totalUsers.ToString();
                lblTotalQuizzesValue.Text = totalQuizzes.ToString();
                lblTotalAttemptsValue.Text = totalAttempts.ToString();
                lblTotalQuestionsValue.Text = totalQuestions.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainForm;
            mainForm?.ShowAdminControl("users");
        }

        private void btnManageQuizzes_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainForm;
            mainForm?.ShowAdminControl("quizzes");
        }

        private void btnViewAnalytics_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainForm;
            mainForm?.ShowAdminControl("analytics");
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainForm;
            mainForm?.ShowMainContent();
        }
    }
}
