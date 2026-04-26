using System;
using System.Windows.Forms;
using Core;

namespace WinFormsLab6
{
    /// <summary>
    /// Головна форма для управління колекцією фільмів.
    /// Демонструє:
    /// - DataGridView з BindingSource для відображення даних
    /// - Кнопки для додавання, редагування, видалення фільмів
    /// - Серіалізацію/десеріалізацію JSON
    /// - Подієву модель WinForms
    /// </summary>
    public partial class MainForm : Form
    {
        private MovieStorage _storage;
        private string _currentFilePath = null;

        public MainForm()
        {
            InitializeComponent();
            _storage = new MovieStorage();
            RefreshGrid();
        }

        /// <summary>
        /// Оновлює DataGridView — прив'язує дані через BindingSource.
        /// BindingSource служить посередником між даними та DataGridView,
        /// автоматично відслідковуючи виділений рядок.
        /// </summary>
        private void RefreshGrid()
        {
            // Прив'язуємо список фільмів через BindingSource
            bindingSource.DataSource = _storage.GetMovies();

            // Налаштовуємо колони (приховуємо зайві, встановлюємо ширину)
            ConfigureColumns();

            UpdateStatus($"Всього фільмів: {_storage.Count}");
        }

        /// <summary>
        /// Налаштовує властивості колон DataGridView.
        /// </summary>
        private void ConfigureColumns()
        {
            if (dataGridViewMovies.Columns.Count == 0)
                return;

            // Зробимо колони видимими та встановимо ширину
            foreach (System.Windows.Forms.DataGridViewColumn col in dataGridViewMovies.Columns)
            {
                col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Приховуємо непотрібні колони, якщо є
            if (dataGridViewMovies.Columns["IsAvailableOnline"] != null)
                dataGridViewMovies.Columns["IsAvailableOnline"].Visible = false;
        }

        /// <summary>
        /// Поточно виділена строка (index), або -1, якщо немає.
        /// </summary>
        private int GetSelectedRowIndex()
        {
            return dataGridViewMovies.CurrentRow?.Index ?? -1;
        }

        // ════════════════════════════════════════════════════════════════════
        // ОБРОБНИКИ ПОДІЙ — КНОПКИ
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Обробник: Додати новий фільм
        /// Створює порожній об'єкт Movie і відкриває форму редагування модально.
        /// </summary>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var newMovie = new Movie
            {
                Id = _storage.Count + 1,  // Простий перебір ID
                Title = "",
                Director = "",
                Genre = "",
                ReleaseDate = DateTime.Now,
                DurationMinutes = 0,
                AverageRating = 5.0,
                IsAvailableOnline = false,
                Budget = 0
            };

            using (var editForm = new EditForm(newMovie, isNewMovie: true))
            {
                // ShowDialog() — модальне відкриття форми
                // Програма зупиняється, поки форма не закриється
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _storage.AddMovie(newMovie);
                    RefreshGrid();
                    UpdateStatus("Фільм додано.");
                }
            }
        }

        /// <summary>
        /// Обробник: Редагувати виділений фільм
        /// Отримує об'єкт з BindingSource та відкриває форму редагування.
        /// </summary>
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = GetSelectedRowIndex();
            if (rowIndex < 0)
            {
                MessageBox.Show("Виберіть фільм для редагування.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Отримуємо об'єкт з BindingSource
            var movie = bindingSource.Current as Movie;
            if (movie == null)
                return;

            using (var editForm = new EditForm(movie, isNewMovie: false))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                    UpdateStatus("Фільм оновлено.");
                }
            }
        }

        /// <summary>
        /// Обробник: Видалити виділений фільм
        /// Використовує MessageBox для підтвердження перед видаленням.
        /// </summary>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = GetSelectedRowIndex();
            if (rowIndex < 0)
            {
                MessageBox.Show("Виберіть фільм для видалення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // MessageBox.Show() — показує діалог із кнопками
            var result = MessageBox.Show(
                $"Видалити фільм '{(bindingSource.Current as Movie)?.Title}'?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _storage.RemoveMovieAt(rowIndex);
                RefreshGrid();
                UpdateStatus("Фільм видалено.");
            }
        }

        /// <summary>
        /// Обробник: Зберегти колекцію в JSON файл
        /// Використовує SaveFileDialog для вибору місця збереження.
        /// </summary>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // SaveFileDialog — діалог вибору файлу для збереження
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _currentFilePath = saveFileDialog.FileName;
                    _storage.SaveToJson(_currentFilePath);
                    UpdateStatus($"Збережено: {_currentFilePath}");
                    MessageBox.Show("Колекція успішно збережена.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatus("Помилка при збереженні.");
                }
            }
        }

        /// <summary>
        /// Обробник: Завантажити колекцію з JSON файлу
        /// Використовує OpenFileDialog для вибору файлу.
        /// </summary>
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            // OpenFileDialog — діалог вибору файлу для відкриття
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _currentFilePath = openFileDialog.FileName;
                    _storage.Clear();
                    _storage.LoadFromJson(_currentFilePath);
                    RefreshGrid();
                    UpdateStatus($"Завантажено: {_currentFilePath}");
                    MessageBox.Show("Колекція успішно завантажена.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при завантаженні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatus("Помилка при завантаженні.");
                }
            }
        }

        /// <summary>
        /// Допоміжний метод для оновлення статус-бара.
        /// </summary>
        private void UpdateStatus(string message)
        {
            toolStripStatusLabel.Text = message;
        }
    }
}
