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


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                errorLabel.Text = "Please enter email and password.";
                return;
            }

            var user = _auth.Authenticate(email, password);
            if (user == null)
            {
                errorLabel.Text = "Invalid email or password.";
                return;
            }

            // clear error & open main form
            errorLabel.Text = "";
            this.Hide();

            using (var scope = _services.CreateScope())
            {
                var main = scope.ServiceProvider.GetRequiredService<MainForm>();
                var prop = main.GetType().GetProperty("CurrentUser");
                if (prop != null && prop.PropertyType == typeof(User))
                    prop.SetValue(main, user);

                main.StartPosition = FormStartPosition.CenterScreen;
                main.ShowDialog();
            }

            this.Close();
        }

       
    }
}
