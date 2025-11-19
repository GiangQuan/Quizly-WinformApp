using System.Drawing;
using System.Windows.Forms;

namespace Quizly.UI.UserUC
{
    partial class UserManagementControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.splitContainer = new SplitContainer();
            this.dgvUsers = new DataGridView();
            this.colId = new DataGridViewTextBoxColumn();
            this.colName = new DataGridViewTextBoxColumn();
            this.colEmail = new DataGridViewTextBoxColumn();
            this.colRole = new DataGridViewTextBoxColumn();
            this.colCreated = new DataGridViewTextBoxColumn();
            this.colQuizzes = new DataGridViewTextBoxColumn();
            this.panelForm = new Panel();
            this.lblFormTitle = new Label();
            this.lblEmail = new Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDisplayName = new Label();
            this.txtDisplayName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRole = new Label();
            this.cmbRole = new ComboBox();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnDeleteUser = new Guna.UI2.WinForms.Guna2GradientButton();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(248, 248, 252);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnBack);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new Padding(20);
            this.panelHeader.Size = new Size(900, 70);
            this.panelHeader.TabIndex = 0;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(76, 62, 147);
            this.lblTitle.Location = new Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(250, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User Management";
            
            // btnBack
            this.btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnBack.BorderRadius = 8;
            this.btnBack.CustomizableEdges = customizableEdges1;
            this.btnBack.FillColor = Color.FromArgb(76, 62, 147);
            this.btnBack.FillColor2 = Color.FromArgb(103, 93, 238);
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.White;
            this.btnBack.Location = new Point(780, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.btnBack.Size = new Size(100, 40);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "← Back";
            this.btnBack.Click += btnBack_Click;
            
            // splitContainer
            this.splitContainer.Dock = DockStyle.Fill;
            this.splitContainer.Location = new Point(0, 70);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Orientation.Horizontal;
            this.splitContainer.Panel1.Controls.Add(this.dgvUsers);
            this.splitContainer.Panel2.Controls.Add(this.panelForm);
            this.splitContainer.Size = new Size(900, 530);
            this.splitContainer.SplitterDistance = 330;
            this.splitContainer.TabIndex = 1;
            
            // dgvUsers
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = Color.White;
            this.dgvUsers.BorderStyle = BorderStyle.None;
            this.dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 62, 147);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            this.dgvUsers.ColumnHeadersHeight = 40;
            this.dgvUsers.Columns.AddRange(new DataGridViewColumn[] {
                this.colId, this.colName, this.colEmail, this.colRole, this.colCreated, this.colQuizzes});
            this.dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(103, 93, 238);
            this.dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            this.dgvUsers.DefaultCellStyle.Padding = new Padding(6);
            this.dgvUsers.Dock = DockStyle.Fill;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = Color.FromArgb(240, 240, 245);
            this.dgvUsers.Location = new Point(0, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 35;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new Size(900, 330);
            this.dgvUsers.TabIndex = 0;
            
            // colId
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.FillWeight = 10;
            
            // colName
            this.colName.HeaderText = "Display Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.FillWeight = 25;
            
            // colEmail
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.FillWeight = 30;
            
            // colRole
            this.colRole.HeaderText = "Role";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.FillWeight = 15;
            
            // colCreated
            this.colCreated.HeaderText = "Created";
            this.colCreated.Name = "colCreated";
            this.colCreated.ReadOnly = true;
            this.colCreated.FillWeight = 15;
            
            // colQuizzes
            this.colQuizzes.HeaderText = "Quizzes Taken";
            this.colQuizzes.Name = "colQuizzes";
            this.colQuizzes.ReadOnly = true;
            this.colQuizzes.FillWeight = 15;
            
            // panelForm
            this.panelForm.BackColor = Color.FromArgb(248, 248, 252);
            this.panelForm.Controls.Add(this.lblFormTitle);
            this.panelForm.Controls.Add(this.lblEmail);
            this.panelForm.Controls.Add(this.txtEmail);
            this.panelForm.Controls.Add(this.lblDisplayName);
            this.panelForm.Controls.Add(this.txtDisplayName);
            this.panelForm.Controls.Add(this.lblPassword);
            this.panelForm.Controls.Add(this.txtPassword);
            this.panelForm.Controls.Add(this.lblRole);
            this.panelForm.Controls.Add(this.cmbRole);
            this.panelForm.Controls.Add(this.btnAddUser);
            this.panelForm.Controls.Add(this.btnDeleteUser);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.Location = new Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new Padding(20);
            this.panelForm.Size = new Size(900, 196);
            this.panelForm.TabIndex = 0;
            
            // lblFormTitle
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblFormTitle.ForeColor = Color.FromArgb(76, 62, 147);
            this.lblFormTitle.Location = new Point(20, 15);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new Size(120, 21);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Add New User";
            
            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = Color.FromArgb(80, 80, 100);
            this.lblEmail.Location = new Point(20, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 15);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            
            // txtEmail
            this.txtEmail.BorderColor = Color.FromArgb(220, 220, 230);
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.CustomizableEdges = customizableEdges3;
            this.txtEmail.DefaultText = "";
            this.txtEmail.FocusedState.BorderColor = Color.FromArgb(103, 93, 238);
            this.txtEmail.Font = new Font("Segoe UI", 9F);
            this.txtEmail.Location = new Point(20, 70);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "user@example.com";
            this.txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.txtEmail.Size = new Size(200, 36);
            this.txtEmail.TabIndex = 2;
            
            // lblDisplayName
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new Font("Segoe UI", 9F);
            this.lblDisplayName.ForeColor = Color.FromArgb(80, 80, 100);
            this.lblDisplayName.Location = new Point(240, 50);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new Size(83, 15);
            this.lblDisplayName.TabIndex = 3;
            this.lblDisplayName.Text = "Display Name";
            
            // txtDisplayName
            this.txtDisplayName.BorderColor = Color.FromArgb(220, 220, 230);
            this.txtDisplayName.BorderRadius = 6;
            this.txtDisplayName.CustomizableEdges = customizableEdges5;
            this.txtDisplayName.DefaultText = "";
            this.txtDisplayName.FocusedState.BorderColor = Color.FromArgb(103, 93, 238);
            this.txtDisplayName.Font = new Font("Segoe UI", 9F);
            this.txtDisplayName.Location = new Point(240, 70);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.PlaceholderText = "John Doe";
            this.txtDisplayName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            this.txtDisplayName.Size = new Size(200, 36);
            this.txtDisplayName.TabIndex = 4;
            
            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 9F);
            this.lblPassword.ForeColor = Color.FromArgb(80, 80, 100);
            this.lblPassword.Location = new Point(460, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(57, 15);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            
            // txtPassword
            this.txtPassword.BorderColor = Color.FromArgb(220, 220, 230);
            this.txtPassword.BorderRadius = 6;
            this.txtPassword.CustomizableEdges = customizableEdges7;
            this.txtPassword.DefaultText = "";
            this.txtPassword.FocusedState.BorderColor = Color.FromArgb(103, 93, 238);
            this.txtPassword.Font = new Font("Segoe UI", 9F);
            this.txtPassword.Location = new Point(460, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Enter password";
            this.txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            this.txtPassword.Size = new Size(180, 36);
            this.txtPassword.TabIndex = 6;
            
            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new Font("Segoe UI", 9F);
            this.lblRole.ForeColor = Color.FromArgb(80, 80, 100);
            this.lblRole.Location = new Point(660, 50);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(30, 15);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "Role";
            
            // cmbRole
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new Font("Segoe UI", 9F);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] { "User", "Creator", "Admin" });
            this.cmbRole.Location = new Point(660, 70);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new Size(120, 23);
            this.cmbRole.TabIndex = 8;
            this.cmbRole.SelectedIndex = 0;
            
            // btnAddUser
            this.btnAddUser.BorderRadius = 8;
            this.btnAddUser.CustomizableEdges = customizableEdges1;
            this.btnAddUser.FillColor = Color.FromArgb(76, 62, 147);
            this.btnAddUser.FillColor2 = Color.FromArgb(103, 93, 238);
            this.btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddUser.ForeColor = Color.White;
            this.btnAddUser.Location = new Point(20, 130);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.btnAddUser.Size = new Size(150, 40);
            this.btnAddUser.TabIndex = 9;
            this.btnAddUser.Text = "➕ Add User";
            this.btnAddUser.Click += btnAddUser_Click;
            
            // btnDeleteUser
            this.btnDeleteUser.BorderRadius = 8;
            this.btnDeleteUser.CustomizableEdges = customizableEdges1;
            this.btnDeleteUser.FillColor = Color.FromArgb(220, 53, 69);
            this.btnDeleteUser.FillColor2 = Color.FromArgb(200, 35, 51);
            this.btnDeleteUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDeleteUser.ForeColor = Color.White;
            this.btnDeleteUser.Location = new Point(190, 130);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.btnDeleteUser.Size = new Size(150, 40);
            this.btnDeleteUser.TabIndex = 10;
            this.btnDeleteUser.Text = "🗑️ Delete User";
            this.btnDeleteUser.Click += btnDeleteUser_Click;
            
            // UserManagementControl
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelHeader);
            this.Name = "UserManagementControl";
            this.Size = new Size(900, 600);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2GradientButton btnBack;
        private SplitContainer splitContainer;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colCreated;
        private DataGridViewTextBoxColumn colQuizzes;
        private Panel panelForm;
        private Label lblFormTitle;
        private Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Label lblDisplayName;
        private Guna.UI2.WinForms.Guna2TextBox txtDisplayName;
        private Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Label lblRole;
        private ComboBox cmbRole;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddUser;
        private Guna.UI2.WinForms.Guna2GradientButton btnDeleteUser;
    }
}
