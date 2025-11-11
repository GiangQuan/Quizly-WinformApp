using Guna.UI2.WinForms;
using Quizly.UI.UserUC;
using System.ComponentModel;
using Quizly.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizly.UI.UserUC
{
    public partial class createQuizzControl : UserControl
    {
        // Class to represent a question in the DataGridView
        private class QuestionRow
        {
            public int No { get; set; }
            public string Question { get; set; } = "";
            public string AnswerA { get; set; } = "";
            public string AnswerB { get; set; } = "";
            public string AnswerC { get; set; } = "";
            public string AnswerD { get; set; } = "";
            public string CorrectAnswer { get; set; } = "";
        }

        private BindingList<QuestionRow> questions = new BindingList<QuestionRow>();
        private readonly QuizlyDbContext _db;
        private readonly User _currentUser;

        // Constructor with dependency injection
        public createQuizzControl(QuizlyDbContext db, User currentUser)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            InitializeComponent();

            // Enable double buffering for smooth scrolling
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();

            if (mainPanel != null)
            {
                typeof(Panel).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.SetProperty |
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic,
                    null, mainPanel, new object[] { true });
            }

            // Initialize DataGridView
            InitializeQuestionDataGridView();
        }

        // Parameterless constructor for Designer support
        public createQuizzControl()
        {
            InitializeComponent();
            InitializeQuestionDataGridView();
        }

        private void InitializeQuestionDataGridView()
        {
            // Configure DataGridView
            questionDgv.AutoGenerateColumns = false;
            questionDgv.AllowUserToAddRows = false;
            questionDgv.AllowUserToDeleteRows = false;
            questionDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            questionDgv.MultiSelect = false;
            questionDgv.ReadOnly = true;
            questionDgv.RowHeadersVisible = false;
            questionDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set row height
            questionDgv.RowTemplate.Height = 35;
            questionDgv.ColumnHeadersHeight = 40;

            // Add columns
            questionDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "No",
                HeaderText = "No",
                DataPropertyName = "No",
                Width = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            questionDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Question",
                HeaderText = "Question",
                DataPropertyName = "Question",
                FillWeight = 150
            });

            questionDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnswerA",
                HeaderText = "Answer A",
                DataPropertyName = "AnswerA",
                FillWeight = 100
            });

            questionDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnswerB",
                HeaderText = "Answer B",
                DataPropertyName = "AnswerB",
                FillWeight = 100
            });

            questionDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnswerC",
                HeaderText = "Answer C",
                DataPropertyName = "AnswerC",
                FillWeight = 100
            });

            questionDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnswerD",
                HeaderText = "Answer D",
                DataPropertyName = "AnswerD",
                FillWeight = 100
            });

            questionDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CorrectAnswer",
                HeaderText = "Correct",
                DataPropertyName = "CorrectAnswer",
                Width = 70,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // Bind data source
            questionDgv.DataSource = questions;

            // Wire up the Add Question button
            guna2Button1.Click += AddQuestionBtn_Click;
        }

        private void createQuizzControl_Load(object sender, EventArgs e)
        {
            // Additional optimization for smooth scrolling
            if (mainPanel != null)
            {
                mainPanel.AutoScroll = true;

                // Optimize scroll performance
                mainPanel.HorizontalScroll.Enabled = false;
                mainPanel.HorizontalScroll.Visible = false;
            }
        }

        private void AddQuestionBtn_Click(object sender, EventArgs e)
        {
            // Show a dialog to add a new question
            using (var addQuestionForm = new AddQuestionDialog())
            {
                if (addQuestionForm.ShowDialog() == DialogResult.OK)
                {
                    var newQuestion = new QuestionRow
                    {
                        No = questions.Count + 1,
                        Question = addQuestionForm.QuestionText,
                        AnswerA = addQuestionForm.AnswerA,
                        AnswerB = addQuestionForm.AnswerB,
                        AnswerC = addQuestionForm.AnswerC,
                        AnswerD = addQuestionForm.AnswerD,
                        CorrectAnswer = addQuestionForm.CorrectAnswer
                    };

                    questions.Add(newQuestion);
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            // Find the parent MainForm
            var mainForm = this.FindForm() as MainForm;

            if (mainForm != null)
            {
                // Call ShowMainContent to restore the main view
                mainForm.ShowMainContent();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Confirm before clearing
            var result = MessageBox.Show(
                "Are you sure you want to clear all data? This will remove all questions and reset all fields.",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear all textboxes in the control
                titleTb?.Clear();
                desTb?.Clear();
                tagsTb?.Clear();
                timeTb?.Clear();

                // Clear all questions
                questions.Clear();

                MessageBox.Show("All data has been cleared.", "Clear Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Confirm cancellation
            var result = MessageBox.Show(
                "Are you sure you want to cancel? All unsaved changes will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Call backBtn_Click to return to main form
                backBtn_Click(sender, e);
            }
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            // Check if database context is available
            if (_db == null || _currentUser == null)
            {
                MessageBox.Show("Database connection not available. Please restart the application.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate quiz title
            if (string.IsNullOrWhiteSpace(titleTb?.Text))
            {
                MessageBox.Show("Please enter a quiz title.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                titleTb?.Focus();
                return;
            }

            // Validate questions
            if (questions.Count == 0)
            {
                MessageBox.Show("Please add at least one question.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse time limit
            int timeLimitSeconds = 0;
            if (!string.IsNullOrWhiteSpace(timeTb?.Text))
            {
                if (!int.TryParse(timeTb.Text, out int timeInMinutes) || timeInMinutes < 0)
                {
                    MessageBox.Show("Please enter a valid time limit in minutes (0 for no limit).",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    timeTb?.Focus();
                    return;
                }
                timeLimitSeconds = timeInMinutes * 60; // Convert to seconds
            }

            try
            {
                // Disable save button to prevent double-clicking
                saveBtn.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // Create new Quiz object
                var newQuiz = new Quiz
                {
                    Title = titleTb.Text.Trim(),
                    Description = desTb?.Text?.Trim() ?? "",
                    Tags = tagsTb?.Text?.Trim() ?? "",
                    TimeLimitSeconds = timeLimitSeconds,
                    IsPublished = false, // Default to unpublished
                    CreatedById = _currentUser.Id,
                    Questions = new List<Question>()
                };

                // Add questions to the quiz
                int order = 1;
                foreach (var questionRow in questions)
                {
                    var question = new Question
                    {
                        Text = questionRow.Question,
                        Type = QuestionType.MultipleChoice,
                        Order = order++,
                        Choices = new List<Choice>
                        {
                            new Choice
                            {
                                Text = questionRow.AnswerA,
                                IsCorrect = questionRow.CorrectAnswer == "A"
                            },
                            new Choice
                            {
                                Text = questionRow.AnswerB,
                                IsCorrect = questionRow.CorrectAnswer == "B"
                            },
                            new Choice
                            {
                                Text = questionRow.AnswerC,
                                IsCorrect = questionRow.CorrectAnswer == "C"
                            },
                            new Choice
                            {
                                Text = questionRow.AnswerD,
                                IsCorrect = questionRow.CorrectAnswer == "D"
                            }
                        }
                    };

                    newQuiz.Questions.Add(question);
                }

                // Add quiz to database
                _db.Quizzes.Add(newQuiz);
                await _db.SaveChangesAsync();

                // Show success message
                MessageBox.Show(
                    $"Quiz '{newQuiz.Title}' has been successfully saved with {questions.Count} question(s)!",
                    "Save Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Clear the form
                clearBtn_Click(sender, e);

                // Optionally, go back to main form
                var shouldGoBack = MessageBox.Show(
                    "Do you want to create another quiz?",
                    "Continue",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (shouldGoBack == DialogResult.No)
                {
                    backBtn_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while saving the quiz:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable save button and restore cursor
                saveBtn.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    }

    // Dialog form for adding/editing questions
    public class AddQuestionDialog : Form
    {
        private Guna2TextBox txtQuestion;
        private Guna2TextBox txtAnswerA;
        private Guna2TextBox txtAnswerB;
        private Guna2TextBox txtAnswerC;
        private Guna2TextBox txtAnswerD;
        private Guna2ComboBox cbCorrectAnswer;
        private Guna2GradientButton btnAdd;
        private Guna2Button btnCancel;

        public string QuestionText { get; private set; } = "";
        public string AnswerA { get; private set; } = "";
        public string AnswerB { get; private set; } = "";
        public string AnswerC { get; private set; } = "";
        public string AnswerD { get; private set; } = "";
        public string CorrectAnswer { get; private set; } = "";

        public AddQuestionDialog()
        {
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.Text = "Add Question";
            this.Size = new Size(600, 540);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(244, 244, 255);

            int yPos = 20;

            // Question
            var lblQuestion = new Guna2HtmlLabel
            {
                Text = "Question:",
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(79, 65, 159),
                Location = new Point(20, yPos),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblQuestion);

            yPos += 30;
            txtQuestion = new Guna2TextBox
            {
                Location = new Point(20, yPos),
                Size = new Size(540, 36),
                PlaceholderText = "Enter question",
                BorderRadius = 8
            };
            this.Controls.Add(txtQuestion);

            // Answer A
            yPos += 50;
            var lblAnswerA = new Guna2HtmlLabel
            {
                Text = "Answer A:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(79, 65, 159),
                Location = new Point(20, yPos),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblAnswerA);

            yPos += 25;
            txtAnswerA = new Guna2TextBox
            {
                Location = new Point(20, yPos),
                Size = new Size(540, 32),
                PlaceholderText = "Enter answer A",
                BorderRadius = 8
            };
            this.Controls.Add(txtAnswerA);

            // Answer B
            yPos += 45;
            var lblAnswerB = new Guna2HtmlLabel
            {
                Text = "Answer B:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(79, 65, 159),
                Location = new Point(20, yPos),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblAnswerB);

            yPos += 25;
            txtAnswerB = new Guna2TextBox
            {
                Location = new Point(20, yPos),
                Size = new Size(540, 32),
                PlaceholderText = "Enter answer B",
                BorderRadius = 8
            };
            this.Controls.Add(txtAnswerB);

            // Answer C
            yPos += 45;
            var lblAnswerC = new Guna2HtmlLabel
            {
                Text = "Answer C:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(79, 65, 159),
                Location = new Point(20, yPos),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblAnswerC);

            yPos += 25;
            txtAnswerC = new Guna2TextBox
            {
                Location = new Point(20, yPos),
                Size = new Size(540, 32),
                PlaceholderText = "Enter answer C",
                BorderRadius = 8
            };
            this.Controls.Add(txtAnswerC);

            // Answer D
            yPos += 45;
            var lblAnswerD = new Guna2HtmlLabel
            {
                Text = "Answer D:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(79, 65, 159),
                Location = new Point(20, yPos),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblAnswerD);

            yPos += 25;
            txtAnswerD = new Guna2TextBox
            {
                Location = new Point(20, yPos),
                Size = new Size(540, 32),
                PlaceholderText = "Enter answer D",
                BorderRadius = 8
            };
            this.Controls.Add(txtAnswerD);

            // Correct Answer
            yPos += 45;
            var lblCorrect = new Guna2HtmlLabel
            {
                Text = "Correct Answer:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(79, 65, 159),
                Location = new Point(20, yPos),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblCorrect);

            cbCorrectAnswer = new Guna2ComboBox
            {
                Location = new Point(150, yPos - 5),
                Size = new Size(100, 36),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BorderRadius = 8,
                ForeColor = Color.FromArgb(79, 65, 159)
            };
            cbCorrectAnswer.Items.AddRange(new object[] { "A", "B", "C", "D" });
            this.Controls.Add(cbCorrectAnswer);

            // Buttons
            yPos += 60;
            btnCancel = new Guna2Button
            {
                Text = "Cancel",
                Location = new Point(340, yPos),
                Size = new Size(100, 40),
                DialogResult = DialogResult.Cancel,
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(79, 65, 159),
                FillColor = Color.FromArgb(245, 245, 255),
                ForeColor = Color.FromArgb(79, 65, 159),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);

            btnAdd = new Guna2GradientButton
            {
                Text = "Add Question",
                Location = new Point(450, yPos),
                Size = new Size(130, 40),
                BorderRadius = 12,
                FillColor = Color.FromArgb(76, 62, 147),
                FillColor2 = Color.FromArgb(103, 93, 238),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            this.CancelButton = btnCancel;
            this.AcceptButton = btnAdd;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Validate question
            if (string.IsNullOrWhiteSpace(txtQuestion?.Text))
            {
                MessageBox.Show("Please enter a question.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuestion?.Focus();
                return;
            }

            // Validate all answers
            if (string.IsNullOrWhiteSpace(txtAnswerA?.Text) ||
                string.IsNullOrWhiteSpace(txtAnswerB?.Text) ||
                string.IsNullOrWhiteSpace(txtAnswerC?.Text) ||
                string.IsNullOrWhiteSpace(txtAnswerD?.Text))
            {
                MessageBox.Show("Please enter all answers (A, B, C, D).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Focus on first empty field
                if (string.IsNullOrWhiteSpace(txtAnswerA?.Text))
                    txtAnswerA?.Focus();
                else if (string.IsNullOrWhiteSpace(txtAnswerB?.Text))
                    txtAnswerB?.Focus();
                else if (string.IsNullOrWhiteSpace(txtAnswerC?.Text))
                    txtAnswerC?.Focus();
                else if (string.IsNullOrWhiteSpace(txtAnswerD?.Text))
                    txtAnswerD?.Focus();

                return;
            }

            // Validate correct answer selection
            if (cbCorrectAnswer.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the correct answer.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCorrectAnswer?.Focus();
                return;
            }

            // Save values
            QuestionText = txtQuestion.Text.Trim();
            AnswerA = txtAnswerA.Text.Trim();
            AnswerB = txtAnswerB.Text.Trim();
            AnswerC = txtAnswerC.Text.Trim();
            AnswerD = txtAnswerD.Text.Trim();
            CorrectAnswer = cbCorrectAnswer.SelectedItem?.ToString() ?? "";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}