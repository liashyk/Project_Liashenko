using System;
using System.Windows.Forms;
using Core;

namespace WinFormsLab6
{
    /// <summary>
    /// Форма для редагування/додавання фільму.
    /// Демонструє:
    /// - TextBox для рядкових даних (Title, Director, Genre)
    /// - NumericUpDown для числових даних (Year, Duration, Rating, Budget)
    /// - CheckBox для булевих даних (IsAvailableOnline)
    /// - Модальне відкриття (ShowDialog) з MainForm
    /// - DialogResult для повернення результату
    /// </summary>
    public partial class EditForm : Form
    {
        private Movie _movie;
        private bool _isNewMovie;

        /// <summary>
        /// Конструктор форми редагування.
        /// </summary>
        /// <param name="movie">Об'єкт фільму для редагування</param>
        /// <param name="isNewMovie">true — додавання нового, false — редагування існуючого</param>
        public EditForm(Movie movie, bool isNewMovie)
        {
            InitializeComponent();
            _movie = movie ?? throw new ArgumentNullException(nameof(movie));
            _isNewMovie = isNewMovie;

            // Завантажуємо дані в контроли
            LoadMovieData();

            // Налаштовуємо форму
            Text = isNewMovie ? "Додавання фільму" : "Редагування фільму";
        }

        /// <summary>
        /// Завантажує дані фільму у контроли форми.
        /// Демонструє двосторонній binding — не через BindingSource, а ручно.
        /// </summary>
        private void LoadMovieData()
        {
            textBoxId.Text = _movie.Id.ToString();
            textBoxTitle.Text = _movie.Title;
            textBoxDirector.Text = _movie.Director;
            textBoxGenre.Text = _movie.Genre;
            numericUpDownYear.Value = _movie.ReleaseDate.Year;
            numericUpDownDuration.Value = _movie.DurationMinutes;
            numericUpDownRating.Value = (decimal)_movie.AverageRating;
            numericUpDownBudget.Value = (decimal)_movie.Budget;
            checkBoxOnline.Checked = _movie.IsAvailableOnline;
        }

        /// <summary>
        /// Зберігає дані з контролів назад у об'єкт фільму.
        /// </summary>
        private void SaveMovieData()
        {
            _movie.Title = textBoxTitle.Text;
            _movie.Director = textBoxDirector.Text;
            _movie.Genre = textBoxGenre.Text;
            _movie.ReleaseDate = new DateTime((int)numericUpDownYear.Value, 1, 1);
            _movie.DurationMinutes = (int)numericUpDownDuration.Value;
            _movie.AverageRating = (double)numericUpDownRating.Value;
            _movie.Budget = (double)numericUpDownBudget.Value;
            _movie.IsAvailableOnline = checkBoxOnline.Checked;
        }

        /// <summary>
        /// Обробник кнопки OK.
        /// Зберігає дані та закриває форму з DialogResult.OK.
        /// </summary>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // Валідація
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Введіть назву фільму.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Зберігаємо дані
            SaveMovieData();

            // DialogResult = OK сигналізує MainForm, що користувач натиснув OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
