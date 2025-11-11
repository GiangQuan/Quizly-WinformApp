namespace Quizly.UI.UserUC
{
    partial class doQuizzControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            quizzPanel = new Guna.UI2.WinForms.Guna2Panel();
            desQuizz = new Guna.UI2.WinForms.Guna2HtmlLabel();
            titleQuizz = new Guna.UI2.WinForms.Guna2HtmlLabel();
            startQuizz = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            backBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            quizzPanel.SuspendLayout();
            SuspendLayout();
            // 
            // quizzPanel
            // 
            quizzPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            quizzPanel.AutoScrollMargin = new Size(0, 20);
            quizzPanel.BackColor = Color.Transparent;
            quizzPanel.BorderRadius = 17;
            quizzPanel.Controls.Add(desQuizz);
            quizzPanel.Controls.Add(titleQuizz);
            quizzPanel.Controls.Add(startQuizz);
            quizzPanel.CustomizableEdges = customizableEdges9;
            quizzPanel.FillColor = Color.White;
            quizzPanel.Location = new Point(26, 94);
            quizzPanel.Name = "quizzPanel";
            quizzPanel.ShadowDecoration.BorderRadius = 15;
            quizzPanel.ShadowDecoration.Color = Color.DimGray;
            quizzPanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            quizzPanel.ShadowDecoration.Depth = 10;
            quizzPanel.ShadowDecoration.Enabled = true;
            quizzPanel.Size = new Size(849, 104);
            quizzPanel.TabIndex = 14;
            // 
            // desQuizz
            // 
            desQuizz.BackColor = Color.Transparent;
            desQuizz.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            desQuizz.ForeColor = Color.FromArgb(79, 65, 159);
            desQuizz.Location = new Point(20, 61);
            desQuizz.Name = "desQuizz";
            desQuizz.Size = new Size(75, 23);
            desQuizz.TabIndex = 14;
            desQuizz.Text = "Quizz title";
            // 
            // titleQuizz
            // 
            titleQuizz.BackColor = Color.Transparent;
            titleQuizz.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleQuizz.ForeColor = Color.FromArgb(79, 65, 159);
            titleQuizz.Location = new Point(20, 16);
            titleQuizz.Name = "titleQuizz";
            titleQuizz.Size = new Size(141, 34);
            titleQuizz.TabIndex = 12;
            titleQuizz.Text = "Information";
            // 
            // startQuizz
            // 
            startQuizz.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startQuizz.BackColor = Color.Transparent;
            startQuizz.BorderRadius = 30;
            startQuizz.CustomizableEdges = customizableEdges7;
            startQuizz.DisabledState.BorderColor = Color.DarkGray;
            startQuizz.DisabledState.CustomBorderColor = Color.DarkGray;
            startQuizz.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            startQuizz.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            startQuizz.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            startQuizz.FillColor = Color.FromArgb(76, 62, 147);
            startQuizz.FillColor2 = Color.FromArgb(103, 93, 238);
            startQuizz.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            startQuizz.ForeColor = Color.White;
            startQuizz.Location = new Point(733, 18);
            startQuizz.Name = "startQuizz";
            startQuizz.ShadowDecoration.CustomizableEdges = customizableEdges8;
            startQuizz.Size = new Size(90, 68);
            startQuizz.TabIndex = 12;
            startQuizz.Text = "Start";
            startQuizz.Click += startQuizz_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(79, 65, 159);
            guna2HtmlLabel1.Location = new Point(17, 22);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(178, 47);
            guna2HtmlLabel1.TabIndex = 13;
            guna2HtmlLabel1.Text = "Select quizz";
            // 
            // backBtn
            // 
            backBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            backBtn.BackColor = Color.Transparent;
            backBtn.BorderRadius = 16;
            backBtn.CustomizableEdges = customizableEdges11;
            backBtn.DisabledState.BorderColor = Color.DarkGray;
            backBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            backBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            backBtn.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            backBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            backBtn.FillColor = Color.FromArgb(76, 62, 147);
            backBtn.FillColor2 = Color.FromArgb(103, 93, 238);
            backBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(759, 36);
            backBtn.Name = "backBtn";
            backBtn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            backBtn.Size = new Size(100, 33);
            backBtn.TabIndex = 15;
            backBtn.Text = "Back";
            backBtn.Click += backBtn_Click_1;
            // 
            // doQuizzControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(244, 244, 255);
            Controls.Add(backBtn);
            Controls.Add(quizzPanel);
            Controls.Add(guna2HtmlLabel1);
            Name = "doQuizzControl";
            Size = new Size(903, 598);
            Load += doQuizzControl_Load;
            quizzPanel.ResumeLayout(false);
            quizzPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel quizzPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel desQuizz;
        private Guna.UI2.WinForms.Guna2HtmlLabel titleQuizz;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2GradientButton startQuizz;
        private Guna.UI2.WinForms.Guna2GradientButton backBtn;
    }
}
