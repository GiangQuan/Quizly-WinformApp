using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using Quizly.Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizly.UI
{
    public partial class QuizzForm : Form
    {
        private readonly QuizlyDbContext _db;
        private readonly Quiz _quiz;
        private readonly User _currentUser;
        private List<Question> _questions = null!;
        private int _currentQuestionIndex = 0;
        private Dictionary<int, int?> _userAnswers = null!; // QuestionId -> ChoiceId
        private DateTime _startTime;
        private System.Windows.Forms.Timer? _countdownTimer;
        private int _remainingSeconds;

        public QuizzForm(QuizlyDbContext db, Quiz quiz, User currentUser)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _quiz = quiz ?? throw new ArgumentNullException(nameof(quiz));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            InitializeComponent();

            // Initialize collections
            _userAnswers = new Dictionary<int, int?>();

            // Set form properties
            this.Text = $"Quiz: {_quiz.Title}";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Wire up event handlers
            nextBtn.Click += NextBtn_Click;
            A.Click += AnswerButton_Click;
            B.Click += AnswerButton_Click;
            C.Click += AnswerButton_Click;
            D.Click += AnswerButton_Click;

            // Load quiz data
            LoadQuizAsync();
        }

        // Parameterless constructor for Designer
        public QuizzForm()
        {
            InitializeComponent();
            // Designer constructor - not used at runtime
            _db = null!;
            _quiz = null!;
            _currentUser = null!;
        }

        private async void LoadQuizAsync()
        {
            try
            {
                // Load questions with choices
                _questions = await _db.Questions
                    .Include(q => q.Choices)
                    .Where(q => q.QuizId == _quiz.Id)
                    .OrderBy(q => q.Order)
                    .ToListAsync();

                if (_questions == null || _questions.Count == 0)
                {
                    MessageBox.Show("This quiz has no questions.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Initialize user answers dictionary
                foreach (var question in _questions)
                {
                    _userAnswers[question.Id] = null;
                }

                // Start the quiz
                _startTime = DateTime.Now;
                InitializeTimer();
                DisplayCurrentQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading quiz: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void InitializeTimer()
        {
            if (_quiz.TimeLimitSeconds > 0)
            {
                _remainingSeconds = _quiz.TimeLimitSeconds;

                _countdownTimer = new System.Windows.Forms.Timer
                {
                    Interval = 1000 // 1 second
                };
                _countdownTimer.Tick += CountdownTimer_Tick;
                _countdownTimer.Start();

                UpdateTimeDisplay();
            }
            else
            {
                // No time limit
                timeTxt.Text = "∞";
                timeTxt.ForeColor = Color.FromArgb(99, 88, 225);
            }
        }

        private void CountdownTimer_Tick(object? sender, EventArgs e)
        {
            _remainingSeconds--;

            if (_remainingSeconds <= 0)
            {
                _countdownTimer?.Stop();
                MessageBox.Show("Time's up! Your quiz will be submitted automatically.",
                    "Time Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubmitQuiz();
            }
            else
            {
                UpdateTimeDisplay();
            }
        }

        private void UpdateTimeDisplay()
        {
            int minutes = _remainingSeconds / 60;
            int seconds = _remainingSeconds % 60;
            timeTxt.Text = $"{minutes:D2}:{seconds:D2}";

            // Change color when time is running low
            if (_remainingSeconds <= 60)
            {
                timeTxt.ForeColor = Color.Red;
            }
            else if (_remainingSeconds <= 300)
            {
                timeTxt.ForeColor = Color.Orange;
            }
            else
            {
                timeTxt.ForeColor = Color.FromArgb(99, 88, 225);
            }
        }

        private void DisplayCurrentQuestion()
        {
            if (_currentQuestionIndex >= _questions.Count)
                return;

            var currentQuestion = _questions[_currentQuestionIndex];

            // Update question counter
            countQuestion.Text = $"{_currentQuestionIndex + 1} of {_questions.Count} questions";

            // Update progress bar
            int progress = (int)(((double)(_currentQuestionIndex + 1) / _questions.Count) * 100);
            progessBar.Value = progress;

            // Display question text
            questionTxt.Text = $"{_currentQuestionIndex + 1}. {currentQuestion.Text}";

            // Get choices for this question
            var choices = currentQuestion.Choices.ToList();

            // Display choices (A, B, C, D)
            DisplayChoice(A, choices, 0);
            DisplayChoice(B, choices, 1);
            DisplayChoice(C, choices, 2);
            DisplayChoice(D, choices, 3);

            // Restore previously selected answer if exists
            RestoreSelectedAnswer(currentQuestion.Id);

            // Update Next button text
            if (_currentQuestionIndex == _questions.Count - 1)
            {
                nextBtn.Text = "Submit";
            }
            else
            {
                nextBtn.Text = "Next";
            }
        }

        private void DisplayChoice(Guna2TileButton button, List<Choice> choices, int index)
        {
            if (index < choices.Count)
            {
                button.Visible = true;
                button.Text = $"{(char)('A' + index)}. {choices[index].Text}";
                button.Tag = choices[index].Id; // Store Choice ID in Tag
            }
            else
            {
                button.Visible = false;
            }
        }

        private void RestoreSelectedAnswer(int questionId)
        {
            // Reset all buttons
            A.Checked = false;
            B.Checked = false;
            C.Checked = false;
            D.Checked = false;

            // Restore selection if exists
            if (_userAnswers.ContainsKey(questionId) && _userAnswers[questionId].HasValue)
            {
                int selectedChoiceId = _userAnswers[questionId]!.Value;

                if (A.Tag != null && (int)A.Tag == selectedChoiceId)
                    A.Checked = true;
                else if (B.Tag != null && (int)B.Tag == selectedChoiceId)
                    B.Checked = true;
                else if (C.Tag != null && (int)C.Tag == selectedChoiceId)
                    C.Checked = true;
                else if (D.Tag != null && (int)D.Tag == selectedChoiceId)
                    D.Checked = true;
            }
        }

        private void AnswerButton_Click(object? sender, EventArgs e)
        {
            if (sender is Guna2TileButton button && button.Tag != null)
            {
                var currentQuestion = _questions[_currentQuestionIndex];
                int choiceId = (int)button.Tag;

                // Save the answer
                _userAnswers[currentQuestion.Id] = choiceId;
            }
        }

        private void NextBtn_Click(object? sender, EventArgs e)
        {
            if (_currentQuestionIndex < _questions.Count - 1)
            {
                // Move to next question
                _currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
            else
            {
                // Last question - submit quiz
                SubmitQuiz();
            }
        }

        private async void SubmitQuiz()
        {
            try
            {
                // Stop timer
                _countdownTimer?.Stop();

                // Confirm submission
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to submit your quiz?\n\n" +
                    $"Answered: {_userAnswers.Count(a => a.Value.HasValue)} / {_questions.Count}",
                    "Confirm Submission",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult != DialogResult.Yes)
                {
                    // Resume timer if user cancels
                    _countdownTimer?.Start();
                    return;
                }

                // Calculate score
                int correctAnswers = 0;
                var attemptDetails = new List<AttemptDetail>();

                foreach (var question in _questions)
                {
                    var correctChoice = question.Choices.FirstOrDefault(c => c.IsCorrect);
                    var userChoiceId = _userAnswers.ContainsKey(question.Id)
                        ? _userAnswers[question.Id]
                        : null;

                    bool isCorrect = userChoiceId.HasValue &&
                                   correctChoice != null &&
                                   userChoiceId.Value == correctChoice.Id;

                    if (isCorrect)
                        correctAnswers++;

                    attemptDetails.Add(new AttemptDetail
                    {
                        QuestionId = question.Id,
                        SelectedChoiceId = userChoiceId,
                        IsCorrect = isCorrect
                    });
                }

                // Calculate final score
                decimal score = ((decimal)correctAnswers / _questions.Count) * 100;
                TimeSpan duration = DateTime.Now - _startTime;

                // Save result to database
                var result = new Result
                {
                    UserId = _currentUser.Id,
                    QuizId = _quiz.Id,
                    Score = score,
                    MaxScore = 100,
                    Duration = duration,
                    TakenAt = DateTime.Now,
                    Details = attemptDetails
                };

                _db.Results.Add(result);
                await _db.SaveChangesAsync();

                // Show result
                ShowResultDialog(correctAnswers, _questions.Count, score, duration);

                // Close form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting quiz: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowResultDialog(int correctAnswers, int totalQuestions, decimal score, TimeSpan duration)
        {
            string message = $"Quiz Completed!\n\n" +
                           $"✓ Correct Answers: {correctAnswers} / {totalQuestions}\n" +
                           $"📊 Score: {score:F1}%\n" +
                           $"⏱️ Time Taken: {duration.Minutes}m {duration.Seconds}s\n\n";

            if (score >= 80)
                message += "🎉 Excellent work!";
            else if (score >= 60)
                message += "👍 Good job!";
            else if (score >= 40)
                message += "💪 Keep practicing!";
            else
                message += "📚 Study more and try again!";

            MessageBox.Show(message, "Quiz Results",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Stop timer when form closes
            _countdownTimer?.Stop();
            _countdownTimer?.Dispose();

            // Confirm if user wants to quit mid-quiz
            if (_currentQuestionIndex < _questions.Count - 1)
            {
                var result = MessageBox.Show(
                    "Are you sure you want to quit? Your progress will be lost.",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    _countdownTimer?.Start();
                }
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            // Logo click - do nothing
        }

        private void QuizzForm_Load(object sender, EventArgs e)
        {

        }
    }
}