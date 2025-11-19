using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using ScottPlot.WinForms;

namespace Quizly.UI.UserUC
{
    partial class analyticControl
    {
        private IContainer components = null;

        private TableLayoutPanel tableLayoutPanelMain;
        private Panel panelFilters;
        private ComboBox cbQuizFilter;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnRefresh;
        private FlowLayoutPanel flowPanelKpis;
        private Panel pnlKpiTotalQuizzes;
        private Label lblTotalQuizzesTitle;
        private Label lblTotalQuizzesValue;
        private Panel pnlKpiAttempts;
        private Label lblAttemptsTitle;
        private Label lblAttemptsValue;
        private Panel pnlKpiAvgScore;
        private Label lblAvgScoreTitle;
        private Label lblAvgScoreValue;
        private Panel pnlKpiPassRate;
        private Label lblPassRateTitle;
        private Label lblPassRateValue;
        private SplitContainer splitContainerMain;
        private FormsPlot chartTrend; // ScottPlot chart control
        private DataGridView dgvDetails;
        private Button btnExport;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tableLayoutPanelMain = new TableLayoutPanel();
            panelFilters = new Panel();
            cbQuizFilter = new ComboBox();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            btnRefresh = new Button();
            btnExport = new Button();
            flowPanelKpis = new FlowLayoutPanel();
            splitContainerMain = new SplitContainer();
            chartTrend = new FormsPlot();
            dgvDetails = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            backBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            tableLayoutPanelMain.SuspendLayout();
            panelFilters.SuspendLayout();
            ((ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.Controls.Add(panelFilters, 0, 0);
            tableLayoutPanelMain.Controls.Add(flowPanelKpis, 0, 1);
            tableLayoutPanelMain.Controls.Add(splitContainerMain, 0, 2);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 3;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Size = new Size(754, 473);
            tableLayoutPanelMain.TabIndex = 0;
            tableLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(backBtn);
            panelFilters.Controls.Add(cbQuizFilter);
            panelFilters.Controls.Add(dtpFrom);
            panelFilters.Controls.Add(dtpTo);
            panelFilters.Controls.Add(btnRefresh);
            panelFilters.Controls.Add(btnExport);
            panelFilters.Dock = DockStyle.Fill;
            panelFilters.Location = new Point(3, 3);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(12);
            panelFilters.Size = new Size(748, 60);
            panelFilters.TabIndex = 0;
            panelFilters.BackColor = System.Drawing.Color.FromArgb(250, 250, 252);
            // 
            // cbQuizFilter
            // 
            cbQuizFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbQuizFilter.Items.AddRange(new object[] { "All quizzes" });
            cbQuizFilter.Location = new Point(12, 16);
            cbQuizFilter.Name = "cbQuizFilter";
            cbQuizFilter.Size = new Size(200, 23);
            cbQuizFilter.TabIndex = 0;
            cbQuizFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(225, 16);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 23);
            dtpFrom.TabIndex = 2;
            dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(355, 16);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 23);
            dtpTo.TabIndex = 4;
            dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.Location = new Point(485, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(85, 28);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(103, 93, 238);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Cursor = Cursors.Hand;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Right;
            btnExport.AutoSize = true;
            btnExport.Location = new Point(1208, 8);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 25);
            btnExport.TabIndex = 6;
            btnExport.Text = "📊 Export";
            btnExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnExport.BackColor = System.Drawing.Color.FromArgb(76, 62, 147);
            btnExport.ForeColor = System.Drawing.Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Cursor = Cursors.Hand;
            // 
            // flowPanelKpis
            // 
            flowPanelKpis.AutoSize = true;
            flowPanelKpis.Dock = DockStyle.Fill;
            flowPanelKpis.Location = new Point(3, 66);
            flowPanelKpis.Name = "flowPanelKpis";
            flowPanelKpis.Padding = new Padding(12);
            flowPanelKpis.Size = new Size(748, 16);
            flowPanelKpis.TabIndex = 1;
            flowPanelKpis.WrapContents = false;
            flowPanelKpis.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            // 
            // Add KPI panels (ensure label fields are initialized so LoadDataAsync won't NRE)
            var kpiTotal = CreateKpiPanel(out lblTotalQuizzesTitle, out lblTotalQuizzesValue, "Total quizzes", "0");
            var kpiAttempts = CreateKpiPanel(out lblAttemptsTitle, out lblAttemptsValue, "Attempts", "0");
            var kpiAvg = CreateKpiPanel(out lblAvgScoreTitle, out lblAvgScoreValue, "Avg score", "0%");
            var kpiPass = CreateKpiPanel(out lblPassRateTitle, out lblPassRateValue, "Pass rate", "0%");
            flowPanelKpis.Controls.AddRange(new Control[] { kpiTotal, kpiAttempts, kpiAvg, kpiPass });
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(3, 79);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(chartTrend);
            splitContainerMain.Panel1.Padding = new Padding(12, 8, 12, 8);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(dgvDetails);
            splitContainerMain.Panel2.Padding = new Padding(12, 8, 12, 12);
            splitContainerMain.Size = new Size(748, 391);
            splitContainerMain.SplitterDistance = 200;
            splitContainerMain.TabIndex = 2;
            splitContainerMain.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            // 
            // chartTrend
            // 
            chartTrend.DisplayScale = 1F;
            chartTrend.Dock = DockStyle.Fill;
            chartTrend.Location = new Point(0, 0);
            chartTrend.Name = "chartTrend";
            chartTrend.Size = new Size(603, 391);
            chartTrend.TabIndex = 0;
            chartTrend.BackColor = System.Drawing.Color.White;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Location = new Point(0, 0);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.Size = new Size(141, 391);
            dgvDetails.TabIndex = 0;
            dgvDetails.BackgroundColor = System.Drawing.Color.White;
            dgvDetails.BorderStyle = BorderStyle.None;
            dgvDetails.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDetails.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(76, 62, 147);
            dgvDetails.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvDetails.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvDetails.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgvDetails.ColumnHeadersHeight = 40;
            dgvDetails.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(103, 93, 238);
            dgvDetails.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvDetails.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvDetails.DefaultCellStyle.Padding = new Padding(6);
            dgvDetails.GridColor = System.Drawing.Color.FromArgb(240, 240, 245);
            dgvDetails.RowTemplate.Height = 35;
            dgvDetails.EnableHeadersVisualStyles = false;
            dgvDetails.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 252);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.HeaderText = "Date & Time";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.FillWeight = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.HeaderText = "User";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.FillWeight = 25;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.HeaderText = "Quiz";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.FillWeight = 35;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.HeaderText = "Score";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.FillWeight = 15;
            // 
            // backBtn
            // 
            backBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            backBtn.BackColor = Color.Transparent;
            backBtn.BorderRadius = 10;
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
            backBtn.Location = new Point(667, 6);
            backBtn.Name = "backBtn";
            backBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            backBtn.Size = new Size(70, 27);
            backBtn.TabIndex = 10;
            backBtn.Text = "Back";
            backBtn.Click += backBtn_Click;
            // 
            // analyticControl
            // 
            Controls.Add(tableLayoutPanelMain);
            Name = "analyticControl";
            Size = new Size(754, 473);
            BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
        }

        private Panel CreateKpiPanel(out Label titleLabel, out Label valueLabel, string title, string value)
        {
            var panel = new Panel();
            panel.Size = new Size(180, 90);
            panel.Padding = new Padding(12);
            panel.Margin = new Padding(8);
            panel.BackColor = System.Drawing.Color.White;
            
            // Add subtle shadow effect with border
            panel.BorderStyle = BorderStyle.None;
            panel.Paint += (s, e) =>
            {
                var rect = panel.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                using (var pen = new Pen(System.Drawing.Color.FromArgb(230, 230, 235), 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };

            titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            titleLabel.ForeColor = System.Drawing.Color.FromArgb(120, 120, 140);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(12, 12);

            valueLabel = new Label();
            valueLabel.Text = value;
            valueLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            valueLabel.ForeColor = System.Drawing.Color.FromArgb(76, 62, 147);
            valueLabel.AutoSize = true;
            valueLabel.Location = new Point(12, 38);

            // Add icon label
            var iconLabel = new Label();
            iconLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            iconLabel.ForeColor = System.Drawing.Color.FromArgb(103, 93, 238);
            iconLabel.AutoSize = true;
            iconLabel.Location = new Point(panel.Width - 40, 12);
            
            // Set icon based on title
            if (title.Contains("quiz", StringComparison.OrdinalIgnoreCase))
                iconLabel.Text = "📝";
            else if (title.Contains("attempt", StringComparison.OrdinalIgnoreCase))
                iconLabel.Text = "🎯";
            else if (title.Contains("score", StringComparison.OrdinalIgnoreCase))
                iconLabel.Text = "⭐";
            else if (title.Contains("pass", StringComparison.OrdinalIgnoreCase))
                iconLabel.Text = "✅";

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(valueLabel);
            panel.Controls.Add(iconLabel);

            return panel;
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton backBtn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}