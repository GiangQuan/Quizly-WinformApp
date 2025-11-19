using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Quizly.Data.Models;

namespace Quizly.UI.UserUC
{
    public partial class UserManagementControl : UserControl
    {
        private readonly QuizlyDbContext _db;
        private readonly User _currentUser;

        public UserManagementControl()
        {
            InitializeComponent();
        }

        public UserManagementControl(QuizlyDbContext db, User currentUser) : this()
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            _ = LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            if (_db == null) return;

            try
            {
                dgvUsers.Rows.Clear();
                var users = await _db.Users
                    .OrderByDescending(u => u.CreatedAt)
                    .ToListAsync();

                foreach (var user in users)
                {
                    var quizCount = await _db.Results.CountAsync(r => r.UserId == user.Id);
                    dgvUsers.Rows.Add(
                        user.Id,
                        user.DisplayName,
                        user.Email,
                        user.Role.ToString(),
                        user.CreatedAt.ToString("yyyy-MM-dd"),
                        quizCount
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var displayName = txtDisplayName.Text.Trim();
            var password = txtPassword.Text.Trim();
            var role = (Role)cmbRole.SelectedIndex;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (existingUser != null)
                {
                    MessageBox.Show("Email already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newUser = new User
                {
                    Email = email,
                    DisplayName = displayName,
                    PasswordHash = HashPassword(password),
                    Role = role,
                    CreatedAt = DateTime.UtcNow
                };

                _db.Users.Add(newUser);
                await _db.SaveChangesAsync();

                MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var userId = (int)dgvUsers.SelectedRows[0].Cells[0].Value;
            
            if (userId == _currentUser.Id)
            {
                MessageBox.Show("You cannot delete your own account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var user = await _db.Users.FindAsync(userId);
                    if (user != null)
                    {
                        _db.Users.Remove(user);
                        await _db.SaveChangesAsync();
                        MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadUsersAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainForm;
            mainForm?.ShowAdminControl("panel");
        }

        private void ClearForm()
        {
            txtEmail.Clear();
            txtDisplayName.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 0;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
