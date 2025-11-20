using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Core.Services;
using Quizly.Data.Models;

namespace Quizly.UI
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _auth;
        private readonly IServiceProvider _services;
        public LoginForm(IAuthService auth, IServiceProvider services)
        {
            _auth = auth;
            _services = services;
            InitializeComponent();

            this.AcceptButton = loginBtn;
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (!ValidateInput(email, password)) return;

            var user = _auth.Authenticate(email, password);
            if (user == null)
            {
                errorLabel.Text = "Invalid email or password.";
                return;
            }

            OpenMainForm(user);
        }

        private bool ValidateInput(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                errorLabel.Text = "Please enter email and password.";
                return false;
            }
            return true;
        }

        private void OpenMainForm(User user)
        {
            errorLabel.Text = "";
            this.Hide();

            using (var scope = _services.CreateScope())
            {
                var main = scope.ServiceProvider.GetRequiredService<MainForm>();
                main.CurrentUser = user;
                main.StartPosition = FormStartPosition.CenterScreen;
                main.ShowDialog();
            }

            this.Show();
            txtPassword.Clear();
            errorLabel.Text = "";
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e) { }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }
    }
}
