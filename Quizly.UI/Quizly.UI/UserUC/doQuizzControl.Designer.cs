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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            quizzPanel = new Guna.UI2.WinForms.Guna2Panel();
            editBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            desQuizz = new Guna.UI2.WinForms.Guna2HtmlLabel();
            titleQuizz = new Guna.UI2.WinForms.Guna2HtmlLabel();
            startQuizz = new Guna.UI2.WinForms.Guna2GradientButton();
            sdasd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            backBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            searchTxt = new Guna.UI2.WinForms.Guna2TextBox();
            quizzPanel.SuspendLayout();
            SuspendLayout();
            // 
            // quizzPanel
            // 
            quizzPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            quizzPanel.AutoScrollMargin = new Size(0, 20);
            quizzPanel.BackColor = Color.Transparent;
            quizzPanel.BorderRadius = 17;
            quizzPanel.Controls.Add(editBtn);
            quizzPanel.Controls.Add(desQuizz);
            quizzPanel.Controls.Add(titleQuizz);
            quizzPanel.Controls.Add(startQuizz);
            quizzPanel.CustomizableEdges = customizableEdges5;
            quizzPanel.FillColor = Color.White;
            quizzPanel.Location = new Point(17, 123);
            quizzPanel.Name = "quizzPanel";
            quizzPanel.ShadowDecoration.BorderRadius = 15;
            quizzPanel.ShadowDecoration.Color = Color.DimGray;
            quizzPanel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            quizzPanel.ShadowDecoration.Depth = 10;
            quizzPanel.ShadowDecoration.Enabled = true;
            quizzPanel.Size = new Size(858, 104);
            quizzPanel.TabIndex = 14;
            quizzPanel.Paint += quizzPanel_Paint;
            // 
            // editBtn
            // 
            editBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editBtn.BackColor = Color.Transparent;
            editBtn.BorderRadius = 30;
            editBtn.CustomizableEdges = customizableEdges1;
            editBtn.DisabledState.BorderColor = Color.DarkGray;
            editBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            editBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            editBtn.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            editBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            editBtn.FillColor = Color.FromArgb(255, 192, 192);
            editBtn.FillColor2 = Color.FromArgb(255, 128, 128);
            editBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            editBtn.ForeColor = Color.White;
            editBtn.Location = new Point(615, 18);
            editBtn.Name = "editBtn";
            editBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            editBtn.Size = new Size(98, 68);
            editBtn.TabIndex = 15;
            editBtn.Text = "Edit";
            editBtn.Click += editBtn_Click;
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
            startQuizz.CustomizableEdges = customizableEdges3;
            startQuizz.DisabledState.BorderColor = Color.DarkGray;
            startQuizz.DisabledState.CustomBorderColor = Color.DarkGray;
            startQuizz.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            startQuizz.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            startQuizz.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            startQuizz.FillColor = Color.FromArgb(76, 62, 147);
            startQuizz.FillColor2 = Color.FromArgb(103, 93, 238);
            startQuizz.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            startQuizz.ForeColor = Color.White;
            startQuizz.Location = new Point(734, 18);
            startQuizz.Name = "startQuizz";
            startQuizz.ShadowDecoration.CustomizableEdges = customizableEdges4;
            startQuizz.Size = new Size(98, 68);
            startQuizz.TabIndex = 12;
            startQuizz.Text = "Start";
            startQuizz.Click += StartQuiz_Click;
            // 
            // sdasd
            // 
            sdasd.BackColor = Color.Transparent;
            sdasd.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sdasd.ForeColor = Color.FromArgb(79, 65, 159);
            sdasd.Location = new Point(17, 22);
            sdasd.Name = "sdasd";
            sdasd.Size = new Size(178, 47);
            sdasd.TabIndex = 13;
            sdasd.Text = "Select quizz";
            // 
            // backBtn
            // 
            backBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            backBtn.BackColor = Color.Transparent;
            backBtn.BorderRadius = 16;
            backBtn.CustomizableEdges = customizableEdges7;
            backBtn.DisabledState.BorderColor = Color.DarkGray;
            backBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            backBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            backBtn.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            backBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            backBtn.FillColor = Color.FromArgb(76, 62, 147);
            backBtn.FillColor2 = Color.FromArgb(103, 93, 238);
            backBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(768, 36);
            backBtn.Name = "backBtn";
            backBtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            backBtn.Size = new Size(100, 33);
            backBtn.TabIndex = 15;
            backBtn.Text = "Back";
            backBtn.Click += backBtn_Click_1;
            // 
            // searchTxt
            // 
            searchTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTxt.BackColor = Color.Transparent;
            searchTxt.BorderRadius = 4;
            searchTxt.CustomizableEdges = customizableEdges9;
            searchTxt.DefaultText = "";
            searchTxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            searchTxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            searchTxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            searchTxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            searchTxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            searchTxt.Font = new Font("Segoe UI", 9F);
            searchTxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            searchTxt.Location = new Point(221, 33);
            searchTxt.Name = "searchTxt";
            searchTxt.PlaceholderText = "Tim kiem Quizz";
            searchTxt.SelectedText = "";
            searchTxt.ShadowDecoration.CustomizableEdges = customizableEdges10;
            searchTxt.Size = new Size(509, 36);
            searchTxt.TabIndex = 16;
            searchTxt.TextChanged += searchTxt_TextChanged;
            // 
            // doQuizzControl
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = Color.FromArgb(244, 244, 255);
            Controls.Add(searchTxt);
            Controls.Add(backBtn);
            Controls.Add(quizzPanel);
            Controls.Add(sdasd);
            Name = "doQuizzControl";
            Size = new Size(912, 598);
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
        private Guna.UI2.WinForms.Guna2HtmlLabel sdasd;
        private Guna.UI2.WinForms.Guna2GradientButton startQuizz;
        private Guna.UI2.WinForms.Guna2GradientButton backBtn;
        private Guna.UI2.WinForms.Guna2TextBox searchTxt;
        private Guna.UI2.WinForms.Guna2GradientButton editBtn;
    }
}
