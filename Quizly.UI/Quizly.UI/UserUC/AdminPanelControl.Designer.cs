using System.Drawing;
using System.Windows.Forms;

namespace Quizly.UI.UserUC
{
    partial class AdminPanelControl
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
            panelHeader = new Panel();
            lblTitle = new Label();
            btnBackToDashboard = new Guna.UI2.WinForms.Guna2GradientButton();
            flowPanelStats = new FlowLayoutPanel();
            flowPanelActions = new FlowLayoutPanel();
            btnManageUsers = new Guna.UI2.WinForms.Guna2GradientButton();
            btnManageQuizzes = new Guna.UI2.WinForms.Guna2GradientButton();
            btnViewAnalytics = new Guna.UI2.WinForms.Guna2GradientButton();
            panelHeader.SuspendLayout();
            flowPanelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(248, 248, 252);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnBackToDashboard);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20);
            panelHeader.Size = new Size(1013, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(76, 62, 147);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Admin Panel";
            // 
            // btnBackToDashboard
            // 
            btnBackToDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackToDashboard.BorderRadius = 10;
            btnBackToDashboard.CustomizableEdges = customizableEdges1;
            btnBackToDashboard.FillColor = Color.FromArgb(76, 62, 147);
            btnBackToDashboard.FillColor2 = Color.FromArgb(103, 93, 238);
            btnBackToDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBackToDashboard.ForeColor = Color.White;
            btnBackToDashboard.Location = new Point(863, 20);
            btnBackToDashboard.Name = "btnBackToDashboard";
            btnBackToDashboard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBackToDashboard.Size = new Size(130, 40);
            btnBackToDashboard.TabIndex = 1;
            btnBackToDashboard.Text = "← Back";
            btnBackToDashboard.Click += btnBackToDashboard_Click;
            // 
            // flowPanelStats
            // 
            flowPanelStats.BackColor = Color.FromArgb(248, 248, 252);
            flowPanelStats.Dock = DockStyle.Top;
            flowPanelStats.Location = new Point(0, 80);
            flowPanelStats.Name = "flowPanelStats";
            flowPanelStats.Padding = new Padding(20, 10, 20, 10);
            flowPanelStats.Size = new Size(1013, 157);
            flowPanelStats.TabIndex = 1;
            // 
            // flowPanelActions
            // 
            flowPanelActions.BackColor = Color.White;
            flowPanelActions.Controls.Add(btnManageUsers);
            flowPanelActions.Controls.Add(btnManageQuizzes);
            flowPanelActions.Controls.Add(btnViewAnalytics);
            flowPanelActions.Dock = DockStyle.Fill;
            flowPanelActions.Location = new Point(0, 237);
            flowPanelActions.Name = "flowPanelActions";
            flowPanelActions.Padding = new Padding(30);
            flowPanelActions.Size = new Size(1013, 363);
            flowPanelActions.TabIndex = 2;
            // 
            // btnManageUsers
            // 
            btnManageUsers.BorderRadius = 15;
            btnManageUsers.CustomizableEdges = customizableEdges3;
            btnManageUsers.FillColor = Color.FromArgb(76, 62, 147);
            btnManageUsers.FillColor2 = Color.FromArgb(103, 93, 238);
            btnManageUsers.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnManageUsers.ForeColor = Color.White;
            btnManageUsers.Location = new Point(30, 30);
            btnManageUsers.Margin = new Padding(0, 0, 15, 15);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnManageUsers.Size = new Size(350, 100);
            btnManageUsers.TabIndex = 0;
            btnManageUsers.Text = "👥 Manage Users";
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // btnManageQuizzes
            // 
            btnManageQuizzes.BorderRadius = 15;
            btnManageQuizzes.CustomizableEdges = customizableEdges5;
            btnManageQuizzes.FillColor = Color.FromArgb(76, 62, 147);
            btnManageQuizzes.FillColor2 = Color.FromArgb(103, 93, 238);
            btnManageQuizzes.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnManageQuizzes.ForeColor = Color.White;
            btnManageQuizzes.Location = new Point(395, 30);
            btnManageQuizzes.Margin = new Padding(0, 0, 15, 15);
            btnManageQuizzes.Name = "btnManageQuizzes";
            btnManageQuizzes.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnManageQuizzes.Size = new Size(350, 100);
            btnManageQuizzes.TabIndex = 1;
            btnManageQuizzes.Text = "📝 Manage Quizzes";
            btnManageQuizzes.Click += btnManageQuizzes_Click;
            // 
            // btnViewAnalytics
            // 
            btnViewAnalytics.BorderRadius = 15;
            btnViewAnalytics.CustomizableEdges = customizableEdges7;
            btnViewAnalytics.FillColor = Color.FromArgb(76, 62, 147);
            btnViewAnalytics.FillColor2 = Color.FromArgb(103, 93, 238);
            btnViewAnalytics.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnViewAnalytics.ForeColor = Color.White;
            btnViewAnalytics.Location = new Point(30, 145);
            btnViewAnalytics.Margin = new Padding(0, 0, 15, 15);
            btnViewAnalytics.Name = "btnViewAnalytics";
            btnViewAnalytics.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnViewAnalytics.Size = new Size(350, 100);
            btnViewAnalytics.TabIndex = 2;
            btnViewAnalytics.Text = "📊 System Analytics";
            btnViewAnalytics.Click += btnViewAnalytics_Click;
            // 
            // AdminPanelControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flowPanelActions);
            Controls.Add(flowPanelStats);
            Controls.Add(panelHeader);
            Name = "AdminPanelControl";
            Size = new Size(1013, 600);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            flowPanelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel CreateKpiPanel(out Label titleLabel, out Label valueLabel, string title, string value)
        {
            var panel = new Panel();
            panel.Size = new Size(170, 90);
            panel.Padding = new Padding(12);
            panel.Margin = new Padding(8);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.None;
            panel.Paint += (s, e) =>
            {
                var rect = panel.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                using (var pen = new Pen(Color.FromArgb(230, 230, 235), 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };

            titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            titleLabel.ForeColor = Color.FromArgb(120, 120, 140);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(12, 12);

            valueLabel = new Label();
            valueLabel.Text = value;
            valueLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            valueLabel.ForeColor = Color.FromArgb(76, 62, 147);
            valueLabel.AutoSize = true;
            valueLabel.Location = new Point(12, 38);

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(valueLabel);

            return panel;
        }

        private Panel panelHeader;
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2GradientButton btnBackToDashboard;
        private FlowLayoutPanel flowPanelStats;
        private FlowLayoutPanel flowPanelActions;
        private Guna.UI2.WinForms.Guna2GradientButton btnManageUsers;
        private Guna.UI2.WinForms.Guna2GradientButton btnManageQuizzes;
        private Guna.UI2.WinForms.Guna2GradientButton btnViewAnalytics;
        
        private Label lblTotalUsersTitle;
        private Label lblTotalUsersValue;
        private Label lblTotalQuizzesTitle;
        private Label lblTotalQuizzesValue;
        private Label lblTotalAttemptsTitle;
        private Label lblTotalAttemptsValue;
        private Label lblTotalQuestionsTitle;
        private Label lblTotalQuestionsValue;
    }
}
