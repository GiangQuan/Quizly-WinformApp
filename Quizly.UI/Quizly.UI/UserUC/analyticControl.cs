using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Quizly.Data.Models;

namespace Quizly.UI.UserUC
{
    public partial class analyticControl : UserControl
    {
        private readonly QuizlyDbContext? _db;
        private readonly User? _currentUser;

        // Designer needs the parameterless ctor
        public analyticControl()
        {
            InitializeComponent();
        }

        // Runtime ctor used by MainForm to pass DB and user
        public analyticControl(QuizlyDbContext db, User? currentUser) : this()
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUser = currentUser;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // safer check for design-time:
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            // fire-and-forget is ok because errors are caught inside LoadDataAsync
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            if (_db == null) return;

            try
            {
                await LoadKPIsAsync();
                await LoadTrendChartAsync();
                await LoadDetailsGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics: {ex.Message}", "Analytics", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadKPIsAsync()
        {
            var totalQuizzes = await _db.Quizzes.CountAsync();
            var totalAttempts = await _db.Results.CountAsync();

            var avgPercent = totalAttempts > 0
                ? await _db.Results.AverageAsync(r => (r.Score / (r.MaxScore == 0 ? 1 : r.MaxScore)) * 100m)
                : 0m;

            var passedCount = await _db.Results.CountAsync(r => (r.Score / (r.MaxScore == 0 ? 1 : r.MaxScore)) * 100m >= 60m);
            var passRate = totalAttempts == 0 ? 0m : (decimal)passedCount / totalAttempts * 100m;

            lblTotalQuizzesValue.Text = totalQuizzes.ToString();
            lblAttemptsValue.Text = totalAttempts.ToString();
            lblAvgScoreValue.Text = $"{avgPercent:F1}%";
            lblPassRateValue.Text = $"{passRate:F1}%";
        }

        private async Task LoadTrendChartAsync()
        {

            var since = DateTime.Today.AddDays(-29);
            var trend = await _db.Results
                .AsNoTracking()
                .Where(r => r.TakenAt.Date >= since)
                .GroupBy(r => r.TakenAt.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .ToListAsync();

            var days = Enumerable.Range(0, 30).Select(i => since.AddDays(i)).ToArray();
            var trendDict = trend.ToDictionary(t => t.Date, t => t.Count);

            double[] xs = days.Select(d => d.ToOADate()).ToArray();
            double[] ys = days.Select(d => (double)(trendDict.TryGetValue(d, out var count) ? count : 0)).ToArray();

            ConfigureChart(xs, ys);
        }

        private void ConfigureChart(double[] xs, double[] ys)
        {
            chartTrend.Plot.Clear();

            var scatter = chartTrend.Plot.Add.Scatter(xs, ys);
            scatter.LineWidth = 3;
            scatter.Color = ScottPlot.Color.FromHex("#675DD3");
            scatter.MarkerSize = 8;
            scatter.MarkerShape = ScottPlot.MarkerShape.FilledCircle;
            scatter.MarkerFillColor = ScottPlot.Color.FromHex("#4C3E93");
            scatter.MarkerLineWidth = 0;

            chartTrend.Plot.Title("Quiz Attempts Trend (Last 30 Days)");
            chartTrend.Plot.XLabel("Date");
            chartTrend.Plot.YLabel("Number of Attempts");
            chartTrend.Plot.FigureBackground.Color = ScottPlot.Color.FromHex("#FFFFFF");
            chartTrend.Plot.DataBackground.Color = ScottPlot.Color.FromHex("#FAFAFA");
            chartTrend.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#E8E8ED");
            chartTrend.Plot.Grid.MajorLineWidth = 1;
            chartTrend.Plot.Axes.DateTimeTicksBottom();
            chartTrend.Plot.Axes.SetLimits(xs.First(), xs.Last());
            chartTrend.Refresh();
        }

        private async Task LoadDetailsGridAsync()
        {
            dgvDetails.Rows.Clear();
            var details = await _db.Results
                .AsNoTracking()
                .Include(r => r.Quiz)
                .Include(r => r.User)
                .OrderByDescending(r => r.TakenAt)
                .Take(50)
                .ToListAsync();

            foreach (var r in details)
            {
                var time = r.TakenAt.ToString("yyyy-MM-dd HH:mm");
                var user = r.User?.DisplayName ?? r.UserId.ToString();
                var quiz = r.Quiz?.Title ?? $"Quiz #{r.QuizId}";
                var scoreText = r.MaxScore == 0 ? $"{r.Score:F1}" : $"{(r.Score / r.MaxScore * 100m):F1}%";
                dgvDetails.Rows.Add(time, user, quiz, scoreText);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is MainForm mainForm)
            {
                mainForm.ShowMainContent();
                return;
            }

            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }
    }
}
