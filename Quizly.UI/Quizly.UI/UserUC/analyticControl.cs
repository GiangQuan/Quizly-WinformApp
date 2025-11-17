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
            // copy to local to satisfy nullable analysis and avoid race conditions
            var db = _db;
            if (db == null) return;

            System.Diagnostics.Debug.WriteLine($"_db != null: {db != null}");
            var sampleCount = await db.Results.CountAsync();
            System.Diagnostics.Debug.WriteLine($"Results count: {sampleCount}");

            try
            {
                // KPIs
                var totalQuizzes = await db.Quizzes.CountAsync();
                var totalAttempts = await db.Results.CountAsync();

                var avgPercent = 0m;
                if (await db.Results.AnyAsync())
                {
                    avgPercent = await db.Results.AverageAsync(r => (r.Score / (r.MaxScore == 0 ? 1 : r.MaxScore)) * 100m);
                }

                // Pass rate using 60% threshold (adjust if needed)
                var passedCount = await db.Results.CountAsync(r => (r.Score / (r.MaxScore == 0 ? 1 : r.MaxScore)) * 100m >= 60m);
                var passRate = totalAttempts == 0 ? 0m : (decimal)passedCount / totalAttempts * 100m;

                lblTotalQuizzesValue.Text = totalQuizzes.ToString();
                lblAttemptsValue.Text = totalAttempts.ToString();
                lblAvgScoreValue.Text = $"{avgPercent:F1}%";
                lblPassRateValue.Text = $"{passRate:F1}%";

                // Trend chart: attempts per day (last 30 days)
                var since = DateTime.Today.AddDays(-29);
                var trend = await db.Results
                    .Where(r => r.TakenAt.Date >= since)
                    .GroupBy(r => r.TakenAt.Date)
                    .Select(g => new { Date = g.Key, Count = g.Count() })
                    .ToListAsync();

                var days = Enumerable.Range(0, 30).Select(i => since.AddDays(i)).ToArray();
                double[] xs = days.Select(d => d.ToOADate()).ToArray();
                double[] ys = days.Select(d =>
                {
                    var item = trend.FirstOrDefault(t => t.Date == d);
                    return (double)(item?.Count ?? 0);
                }).ToArray();

                chartTrend.Plot.Clear();

                // ScottPlot v5 API: use the fluent Add namespace
                chartTrend.Plot.Add.Scatter(xs, ys);

                // ScottPlot v5: use SetAxisLimits to restrict X axis (use NaN for auto Y)
                // Replace this line:
                // chartTrend.Plot.SetAxisLimits(xs.First(), xs.Last(), double.NaN, double.NaN);

                // With this line:
                chartTrend.Plot.Axes.SetLimits(xs.First(), xs.Last());

                chartTrend.Refresh();

                // Details grid: last 50 attempts
                dgvDetails.Rows.Clear();
                var details = await db.Results
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics: {ex.Message}", "Analytics", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                mainForm.ShowMainContent();
                return;
            }

            var parent = this.Parent;
            if (parent != null)
            {
                parent.Controls.Remove(this);
                this.Dispose();
            }
        }

       
    }
}
