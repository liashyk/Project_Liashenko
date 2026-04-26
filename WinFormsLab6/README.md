ЛР6 — WINFORMS: Каталог фільмів
═════════════════════════════════════════════════════════════════════

СТРУКТУРА ПРОЕКТУ
─────────────────────────────────────────────────────────────────────

WinFormsLab6/
├── Program.cs                 — точка входу (STAThread, Application.Run)
├── MainForm.cs                — головна форма (DataGridView + кнопки)
├── MainForm.Designer.cs       — дизайн MainForm (автоген)
├── EditForm.cs                — форма редагування фільму
├── EditForm.Designer.cs       — дизайн EditForm (автоген)
└── WinFormsLab6.csproj        — конфіг проекту

Core/
└── MovieStorage.cs            — клас для JSON-серіалізації


КЛЮЧОВІ КОМПОНЕНТИ WinForms
─────────────────────────────────────────────────────────────────────

1. DATAGRIDVIEW + BINDINGSOURCE (MainForm.cs)
   ───────────────────────────────────────────────
   bindingSource.DataSource = _storage.GetMovies();
   dataGridViewMovies.DataSource = bindingSource;

   ✓ BindingSource — посередник між даними та представленням
   ✓ Автоматично вказує на поточний виділений рядок
   ✓ bindingSource.Current — отримати поточний об'єкт

2. МОДАЛЬНІ ФОРМИ (ShowDialog)
   ───────────────────────────────────────────────
   using (var editForm = new EditForm(movie, isNewMovie: true))
   {
       if (editForm.ShowDialog() == DialogResult.OK)
       {
           // Користувач натиснув OK
       }
   }

   ✓ ShowDialog() — зупиняє виконання до закриття форми
   ✓ DialogResult — визначає, яку кнопку натиснув користувач
   ✓ using — гарантує очищення ресурсів (Dispose)

3. ДІАЛОГИ ФАЙЛІВ
   ───────────────────────────────────────────────
   SaveFileDialog — вибір місця збереження
   OpenFileDialog — вибір файлу для відкриття

   if (saveFileDialog.ShowDialog() == DialogResult.OK)
   {
       string filePath = saveFileDialog.FileName;
       _storage.SaveToJson(filePath);
   }

4. MESSAGEBOX — повідомлення користувачу
   ───────────────────────────────────────────────
   MessageBox.Show(
       "Видалити фільм?",
       "Підтвердження",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

   ✓ MessageBoxButtons — YesNo, OK, OKCancel та ін.
   ✓ MessageBoxIcon — Question, Warning, Error, Information
   ✓ Повертає DialogResult


ПОДІЄВА МОДЕЛЬ (Event Model)
─────────────────────────────────────────────────────────────────────

1. КНОПКА + ÉVÉNEMENT (ButtonAdd_Click)

   buttonAdd.Click += ButtonAdd_Click;  // у Designer

   private void ButtonAdd_Click(object sender, EventArgs e)
   {
       // Обробник викликається коли натиснута кнопка
   }

2. ДЕКЛАГУВАННЯ ДАНИХ (Two-Way Data Binding)

   MainForm:
   - LoadMovieData() — завантажити з Movie у контроли (TextBox, NumericUpDown)
   - SaveMovieData() — зберегти з контролів назад у Movie

   Це ручний binding (не через BindingSource у цій формі),
   але гарантує синхронізацію.

3. LIFECYCLE ФОРМ

   EditForm:
   - Конструктор: ініціалізація контролів
   - ShowDialog(): модальне відкриття
   - ButtonOK_Click: валідація → SaveMovieData() → DialogResult = OK
   - Close(): закриття форми


ВИХІД ДАНИХ (JSON)
─────────────────────────────────────────────────────────────────────

MovieStorage.SaveToJson(filePath):
  └─ JsonSerializer.Serialize(_movies) → JSON рядок
     └─ File.WriteAllText() → запис у файл

MovieStorage.LoadFromJson(filePath):
  └─ File.ReadAllText() → читання з файлу
     └─ JsonSerializer.Deserialize() → список Movie


ВАЖЛИВІ ВЛАСТИВОСТІ WinForms
─────────────────────────────────────────────────────────────────────

DataGridView:
  .AllowUserToAddRows = false       — заборонити користувачеві додавати
  .AllowUserToDeleteRows = false    — заборонити видаляти
  .ReadOnly = true                  — лише для читання
  .SelectionMode = FullRowSelect    — виділяти цілий рядок
  .CurrentRow                       — поточна строка
  .CurrentRow.Index                 — індекс поточної строки

NumericUpDown:
  .Minimum, .Maximum                — межі значень
  .DecimalPlaces                    — кількість десяткових знаків
  .Value                            — поточне значення (decimal)

Form:
  .ShowDialog()                     — модальне відкриття
  .DialogResult                     — результат (OK, Cancel, etc.)
  .AcceptButton = buttonOK          — кнопка за замовчуванням (Enter)
  .CancelButton = buttonCancel      — кнопка Esc


АЛГОРИТМ РОБОТИ
─────────────────────────────────────────────────────────────────────

ЗАПУСК:
  1. Program.Main() → STAThread → Application.Run(new MainForm())
  2. MainForm().ctor → InitializeComponent() → RefreshGrid()

ДОДАВАННЯ ФІЛЬМУ:
  1. Користувач натискає "Додати"
  2. ButtonAdd_Click → створює Movie() з default значеннями
  3. ShowDialog(new EditForm(movie, isNewMovie: true))
  4. EditForm.ctor → LoadMovieData()
  5. Користувач заповнює поля → натискає OK
  6. ButtonOK_Click → SaveMovieData() → DialogResult = OK
  7. MainForm: detectDiag = OK → _storage.AddMovie() → RefreshGrid()

ВИДАЛЕННЯ ФІЛЬМУ:
  1. Користувач виділяє рядок → натискає "Видалити"
  2. ButtonDelete_Click → GetSelectedRowIndex() → MessageBox для підтвердження
  3. Якщо YES → _storage.RemoveMovieAt(index) → RefreshGrid()

ЗБЕРЕЖЕННЯ:
  1. Користувач натискає "Зберегти"
  2. ButtonSave_Click → SaveFileDialog.ShowDialog()
  3. Якщо OK → _storage.SaveToJson(filePath)

ЗАВАНТАЖЕННЯ:
  1. Користувач натискає "Завант."
  2. ButtonLoad_Click → OpenFileDialog.ShowDialog()
  3. Якщо OK → _storage.Clear() → _storage.LoadFromJson(filePath) → RefreshGrid()


КОНТРОЛИ WINFORMS (ІНЖИНІРИНГ)
─────────────────────────────────────────────────────────────────────

TextBox:
  ✓ для введення рядків (Title, Director, Genre)
  ✓ .Text — отримати/встановити текст
  ✓ .ReadOnly = true — лише для читання

NumericUpDown:
  ✓ для введення чисел (DurationMinutes, AverageRating, Budget)
  ✓ .Value — отримати/встановити число (decimal)
  ✓ приймає мінімум/максимум обмеження
  ✓ автоматично перевіряє межі

CheckBox:
  ✓ для булевих значень (IsAvailableOnline)
  ✓ .Checked — отримати/встановити стан

Label:
  ✓ статичний текст (заголовки полів)

Button:
  ✓ .Click += Handler — підписатися на натискання
  ✓ .DialogResult = DialogResult.OK — встановити результат

Panel:
  ✓ контейнер для групування контролів
  ✓ .Dock = DockStyle.Bottom — прикріпити дно форми

StatusStrip:
  ✓ смуга статусу внизу форми
  ✓ .Items — колекція елементів


ОБРОБЛЕННЯ ПОМИЛОК
─────────────────────────────────────────────────────────────────────

try-catch:
  try
  {
      _storage.SaveToJson(filePath);
  }
  catch (Exception ex)
  {
      MessageBox.Show($"Помилка: {ex.Message}", "Помилка", 
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
  }

Валідація:
  if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
  {
      MessageBox.Show("Введіть назву фільму.", "Помилка", 
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
  }


ЗАПУСК ПРОГРАМИ
─────────────────────────────────────────────────────────────────────

1. В Visual Studio встановіть WinFormsLab6 як StartupProject
2. Натисніть F5 або "Start Debugging"
3. Головна форма відкриється з DataGridView
4. Додавайте/редагуйте/видаляйте фільми
5. Зберігайте/завантажуйте JSON


ПИТАННЯ ДЛЯ ПЕРЕВІРКИ
─────────────────────────────────────────────────────────────────────

1. Що таке BindingSource і навіщо його використовувати?
   → Посередник між даними й DataGridView, автоматично синхронізує вибір

2. Яка різниця між Show() та ShowDialog()?
   → Show() — немодальна, ShowDialog() — модальна (зупиняє виконання)

3. Як передати дані з EditForm назад у MainForm?
   → Через DialogResult або зміни об'єкта (reference type)

4. Що таке STAThread у Program.Main()?
   → Однопоточна модель для WinForms (обов'язково)

5. Як валідувати дані перед закриттям EditForm?
   → У ButtonOK_Click перед встановленням DialogResult = OK


РЕКОМЕНДАЦІЇ
─────────────────────────────────────────────────────────────────────

✓ Завжди використовуйте try-catch для файлових операцій
✓ Валідуйте дані перед збереженням
✓ Показуйте MessageBox для критичних дій (видалення)
✓ Оновлюйте UI (StatusStrip) після кожної операції
✓ Використовуйте DataGridView.ReadOnly для захисту від випадкових змін
✓ Встановлюйте AcceptButton/CancelButton для швидкого введення

═════════════════════════════════════════════════════════════════════
