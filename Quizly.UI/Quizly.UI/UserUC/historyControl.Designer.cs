namespace Quizly.UI.UserUC
{
    partial class historyControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            backBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            quizzPanel = new Guna.UI2.WinForms.Guna2Panel();
            score = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            desQuizz = new Guna.UI2.WinForms.Guna2HtmlLabel();
            titleQuizz = new Guna.UI2.WinForms.Guna2HtmlLabel();
            startQuizz = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            quizzPanel.SuspendLayout();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            backBtn.BackColor = Color.Transparent;
            backBtn.BorderRadius = 16;
            backBtn.CustomizableEdges = customizableEdges1;
            backBtn.DisabledState.BorderColor = Color.DarkGray;
            backBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            backBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            backBtn.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            backBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            backBtn.FillColor = Color.FromArgb(76, 62, 147);
            backBtn.FillColor2 = Color.FromArgb(103, 93, 238);
            backBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(745, 32);
            backBtn.Name = "backBtn";
            backBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            backBtn.Size = new Size(100, 33);
            backBtn.TabIndex = 18;
            backBtn.Text = "Back";
            backBtn.Click += backBtn_Click;
            // 
            // quizzPanel
            // 
            quizzPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            quizzPanel.AutoScrollMargin = new Size(0, 20);
            quizzPanel.BackColor = Color.Transparent;
            quizzPanel.BorderRadius = 17;
            quizzPanel.Controls.Add(score);
            quizzPanel.Controls.Add(guna2ProgressBar1);
            quizzPanel.Controls.Add(desQuizz);
            quizzPanel.Controls.Add(titleQuizz);
            quizzPanel.Controls.Add(startQuizz);
            quizzPanel.CustomizableEdges = customizableEdges7;
            quizzPanel.FillColor = Color.White;
            quizzPanel.Location = new Point(32, 90);
            quizzPanel.Name = "quizzPanel";
            quizzPanel.ShadowDecoration.BorderRadius = 15;
            quizzPanel.ShadowDecoration.Color = Color.DimGray;
            quizzPanel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            quizzPanel.ShadowDecoration.Depth = 10;
            quizzPanel.ShadowDecoration.Enabled = true;
            quizzPanel.Size = new Size(813, 104);
            quizzPanel.TabIndex = 17;
            // 
            // score
            // 
            score.BackColor = Color.Transparent;
            score.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            score.ForeColor = Color.FromArgb(79, 65, 159);
            score.Location = new Point(724, 27);
            score.Name = "score";
            score.Size = new Size(75, 23);
            score.TabIndex = 16;
            score.Text = "Quizz title";
            // 
            // guna2ProgressBar1
            // 
            guna2ProgressBar1.BorderRadius = 3;
            guna2ProgressBar1.CustomizableEdges = customizableEdges3;
            guna2ProgressBar1.Location = new Point(108, 69);
            guna2ProgressBar1.Name = "guna2ProgressBar1";
            guna2ProgressBar1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ProgressBar1.Size = new Size(691, 10);
            guna2ProgressBar1.TabIndex = 15;
            guna2ProgressBar1.Text = "guna2ProgressBar1";
            guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
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
            startQuizz.CustomizableEdges = customizableEdges5;
            startQuizz.DisabledState.BorderColor = Color.DarkGray;
            startQuizz.DisabledState.CustomBorderColor = Color.DarkGray;
            startQuizz.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            startQuizz.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            startQuizz.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            startQuizz.FillColor = Color.FromArgb(76, 62, 147);
            startQuizz.FillColor2 = Color.FromArgb(103, 93, 238);
            startQuizz.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            startQuizz.ForeColor = Color.White;
            startQuizz.Location = new Point(1346, 18);
            startQuizz.Name = "startQuizz";
            startQuizz.ShadowDecoration.CustomizableEdges = customizableEdges6;
            startQuizz.Size = new Size(90, 68);
            startQuizz.TabIndex = 12;
            startQuizz.Text = "Start";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(79, 65, 159);
            guna2HtmlLabel1.Location = new Point(32, 18);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(113, 47);
            guna2HtmlLabel1.TabIndex = 16;
            guna2HtmlLabel1.Text = "History";
            // 
            // historyControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(backBtn);
            Controls.Add(quizzPanel);
            Controls.Add(guna2HtmlLabel1);
            Name = "historyControl";
            Size = new Size(878, 588);
            Load += historyControl_Load;
            quizzPanel.ResumeLayout(false);
            quizzPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton backBtn;
        private Guna.UI2.WinForms.Guna2Panel quizzPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel score;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private Guna.UI2.WinForms.Guna2HtmlLabel desQuizz;
        private Guna.UI2.WinForms.Guna2HtmlLabel titleQuizz;
        private Guna.UI2.WinForms.Guna2GradientButton startQuizz;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
