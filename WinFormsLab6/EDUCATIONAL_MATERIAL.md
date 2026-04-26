## 📚 ЛР6 — WinForms: Дидактичні матеріали

### ТЕМА: Побудова GUI на WinForms. Подієва модель,ModalForms, DataGridView

---

## 1️⃣ ЩО ТАКЕ WINFORMS?

**WinForms** — фреймворк для створення розумних додатків з графічним інтерфейсом (GUI).

**Замість того, щоб писати консольні команди:**
```csharp
// Console App (попередні ЛР):
Console.WriteLine("Додати фільм?");
string title = Console.ReadLine();
```

**На WinForms ми створюємо вікна з кнопками, таблицями, текстовими полями:**
```csharp
// WinForms GUI:
MainForm → [DataGridView] [Button "Додати"] [TextBox для вводу]
```

---

## 2️⃣ АРХІТЕКТУРА WINFORMS

```
┌─────────────────────────────────────────────┐
│          Program.Main()                     │
│  (STAThread) ← ОБОВ'ЯЗКОВО!                 │
│  Application.Run(new MainForm())            │
└────────────┬────────────────────────────────┘
             ↓
┌─────────────────────────────────────────────┐
│        MainForm : Form                      │
│  ┌─────────────────────────────────────┐   │
│  │ DataGridView (таблиця)              │   │
│  │ ┌───────────────────────────────┐   │   │
│  │ │ Id │ Title │ Director│Rating  │   │   │
│  │ ├───────────────────────────────┤   │   │
│  │ │1   │Початок│Нолан   │8.8      │   │   │
│  │ │2   │Матриця│Вачовськи│8.7      │   │   │
│  │ └───────────────────────────────┘   │   │
│  └─────────────────────────────────────┘   │
│                                             │
│  [Додати] [Редакт.] [Видалити]             │
│  [Зберегти] [Завант.]                      │
│                                             │
│  Статус: Готово                             │
└─────────────────────────────────────────────┘
        ↓ Користувач натискає кнопку
┌─────────────────────────────────────────────┐
│       EditForm : Form (Modal)               │
│  ┌─────────────────────────────────────┐   │
│  │ Назва:     [TextBox]                │   │
│  │ Режисер:   [TextBox]                │   │
│  │ Рейтинг:   [NumericUpDown 0-10]     │   │
│  │ Онлайн:    [CheckBox]               │   │
│  │                                     │   │
│  │          [OK]    [Скасувати]        │   │
│  └─────────────────────────────────────┘   │
└─────────────────────────────────────────────┘
```

---

## 3️⃣ ПОДІЄВА МОДЕЛЬ

**WinForms працює на **ПОДІЯХ** (Events):**

```csharp
// Крок 1: Користувач натискає кнопку "Додати"
buttonAdd.Click  // Génère une EVENT

// Крок 2: WinForms викликає обробник
private void ButtonAdd_Click(object sender, EventArgs e)
{
    // Крок 3: Ми виконуємо код
    var editForm = new EditForm(...);
    editForm.ShowDialog();
}
```

**Види подій:**
- `Button.Click` — натиск кнопки
- `TextBox.TextChanged` — зміна тексту
- `DataGridView.SelectionChanged` — виділення в таблиці
- `Form.Load` — завантаження форми
- `Form.Closing` — закриття форми

---

## 4️⃣ ОСНОВНІ КОНТРОЛИ

### **DataGridView** — таблиця
```csharp
// Встановлення джерела даних
dataGridViewMovies.DataSource = _storage.GetMovies();

// Получение текущего ряда
int rowIndex = dataGridViewMovies.CurrentRow.Index;

// Отримати об'єкт з BindingSource
var movie = bindingSource.Current as Movie;
```

### **BindingSource** — синхронізація
```csharp
// BindingSource — посередник між List<T> і DataGridView
bindingSource.DataSource = _storage.GetMovies();
dataGridViewMovies.DataSource = bindingSource;

// Автоматично:
// - Показує дані
// - Слідкує за виділеним рядком
// - bindingSource.Current = поточний об'єкт
```

### **TextBox** — введення рядків
```csharp
textBoxTitle.Text = "Введіть назву";
string title = textBoxTitle.Text;  // Отримати

textBoxTitle.ReadOnly = true;  // Лише читання
textBoxTitle.MaxLength = 50;   // Максимум символів
```

### **NumericUpDown** — введення чисел
```csharp
numericUpDownYear.Minimum = 1900;
numericUpDownYear.Maximum = 2100;
numericUpDownYear.DecimalPlaces = 0;  // Цілі числа
numericUpDownYear.Value = 2025;

// Отримати/встановити
decimal value = numericUpDownYear.Value;
int year = (int)numericUpDownYear.Value;
```

### **CheckBox** — булеве значення
```csharp
checkBoxOnline.Checked = true;
bool isChecked = checkBoxOnline.Checked;
```

### **Button** — кнопка
```csharp
// У Designer або коді:
button.Click += Button_Click;

private void Button_Click(object sender, EventArgs e)
{
    // Обробник
}
```

---

## 5️⃣ МОДАЛЬНІ ФОРМИ (ShowDialog)

**Різниця:**

```csharp
// ❌ Немодальна (Show)
var form = new EditForm(...);
form.Show();  // ← Програма продовжує роботу!

// ✅ Модальна (ShowDialog)
var form = new EditForm(...);
form.ShowDialog();  // ← ЗУПИНЯЄ виконання до закриття
```

**Приклад з результатом:**
```csharp
using (var editForm = new EditForm(movie, isNewMovie: true))
{
    // Відкриває модально
    if (editForm.ShowDialog() == DialogResult.OK)
    {
        // Користувач натиснув OK
        _storage.AddMovie(movie);
        RefreshGrid();
    }
    // Якщо Cancel — нічого не робимо
}
```

**DialogResult:**
- `OK` — користувач натиснув OK (button.DialogResult = DialogResult.OK)
- `Cancel` — користувач натиснув Cancel або закрив форму
- `None` — форма ще не закрита

---

## 6️⃣ MESSAGEBOX — ДІАЛОГИ

**Простий діалог:**
```csharp
MessageBox.Show("Операція завершена!", "Успіх");
```

**Діалог з кнопками:**
```csharp
var result = MessageBox.Show(
    "Видалити фільм?",           // Текст
    "Підтвердження",             // Заголовок
    MessageBoxButtons.YesNo,      // Кнопки: Yes, No
    MessageBoxIcon.Question       // Іконка
);

if (result == DialogResult.Yes)
{
    // Користувач вибрав Yes
}
```

**Варіанти MessageBoxButtons:**
- `OK` — одна кнопка OK
- `OKCancel` — OK і Cancel
- `YesNo` — Yes і No
- `YesNoCancel` — Yes, No, Cancel

**Варіанти MessageBoxIcon:**
- `Information` — 💡 Інформація
- `Question` — ❓ Питання
- `Warning` — ⚠️ Попередження
- `Error` — ❌ Помилка

---

## 7️⃣ ДІАЛОГИ ФАЙЛІВ

### **SaveFileDialog** — вибір місця збереження
```csharp
SaveFileDialog dialog = new SaveFileDialog
{
    Title = "Зберегти файл",
    Filter = "JSON файли (*.json)|*.json|Всі файли (*.*)|*.*",
    DefaultExt = "json"
};

if (dialog.ShowDialog() == DialogResult.OK)
{
    string filePath = dialog.FileName;
    _storage.SaveToJson(filePath);
}
```

### **OpenFileDialog** — вибір файлу для відкриття
```csharp
OpenFileDialog dialog = new OpenFileDialog
{
    Title = "Завантажити файл",
    Filter = "JSON файли (*.json)|*.json|Всі файли (*.*)|*.*"
};

if (dialog.ShowDialog() == DialogResult.OK)
{
    string filePath = dialog.FileName;
    _storage.LoadFromJson(filePath);
}
```

---

## 8️⃣ ОБРОБКА ПОМИЛОК

```csharp
try
{
    _storage.SaveToJson(filePath);
    MessageBox.Show("Збережено успішно!", "Успіх");
}
catch (FileNotFoundException ex)
{
    MessageBox.Show($"Файл не знайдено: {ex.Message}", "Помилка");
}
catch (Exception ex)
{
    MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
}
```

---

## 9️⃣ ВАЛІДАЦІЯ ДАНИХ

```csharp
// Перед додаванням в БД
if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
{
    MessageBox.Show("Введіть назву фільму!", "Помилка");
    return;  // Не додавати
}

if (numericUpDownYear.Value < 1900)
{
    MessageBox.Show("Рік не може бути менше 1900!", "Помилка");
    return;
}

if (numericUpDownDuration.Value <= 0)
{
    MessageBox.Show("Тривалість повинна бути > 0!", "Помилка");
    return;
}
```

---

## 🔟 ПРАКТИЧНИЙ ПРИКЛАД: ЦИКЛ ДОДАВАННЯ ФІЛЬМУ

```
1. Користувач натискає "Додати"
   ↓
2. ButtonAdd_Click() запускається
   ↓
3. Створюємо new Movie() з default значеннями
   ↓
4. Відкриваємо EditForm.ShowDialog(movie)
   ↓
5. Користувач заповнює поля (TextBox, NumericUpDown)
   ↓
6. Натискає OK → EditForm.ButtonOK_Click()
   ↓
7. SaveMovieData() → копіюємо дані з контролів у Movie об'єкт
   ↓
8. DialogResult = DialogResult.OK
   ↓
9. EditForm закривається
   ↓
10. MainForm отримує DialogResult.OK
    ↓
11. _storage.AddMovie(movie)
    ↓
12. RefreshGrid() → BindingSource.DataSource = _storage.GetMovies()
    ↓
13. DataGridView оновлюється
    ↓
14. Фільм видно у таблиці ✅
```

---

## 1️⃣1️⃣ ПОРІВНЯННЯ: CONSOLE VS WINFORMS

| Аспект | Console | WinForms |
|--------|---------|----------|
| **Введення** | `Console.ReadLine()` | `TextBox.Text` |
| **Числа** | `int.Parse()` | `NumericUpDown.Value` |
| **Вибір** | `if (choice == "y")` | `Checkbox.Checked` |
| **Таблиця** | Рядки в консолі | `DataGridView` |
| **Подія** | Цикл while | `Click`, `TextChanged` |
| **Діалоги** | Текстові меню | `MessageBox`, `Dialog` |
| **Модальність** | - | `ShowDialog()` |
| **Потік** | Main thread | STAThread (обов'язково) |

---

## 1️⃣2️⃣ ТИПОВІ ПОМИЛКИ

| Помилка | Причина | Рішення |
|--------|--------|---------|
| "Object reference not set" | Контроль не ініціалізований | Перевірте `InitializeComponent()` |
| "Type not found" | Забули using | Додайте `using Core;` |
| "ShowDialog not responding" | Забули STAThread | Додайте `[STAThread]` |
| DataGridView порожня | Забули прив'язати дані | Встановіть `DataSource` |
| Користувач не може редагувати | `ReadOnly = true` | Встановіть `ReadOnly = false` |

---

## 1️⃣3️⃣ КОНТРОЛЬНІ ПИТАННЯ

1. **Що таке BindingSource?**
   - Посередник між даними й UI, автоматично синхронізує вибір

2. **Чому нам потрібен STAThread?**
   - WinForms використовує однопоточну модель

3. **Як передати дані з EditForm?**
   - Через reference type (Movie об'єкт передається за посиланням)

4. **ShowDialog() vs Show()?**
   - ShowDialog() модальна (зупиняє), Show() немодальна

5. **Як перевірити, що користувач натиснув OK?**
   - `if (form.ShowDialog() == DialogResult.OK)`

---

## 🎯 РЕЗЮМЕ

**ЛР6 навчає:**
1. ✅ Створення WinForms форм
2. ✅ Прив'язка даних через BindingSource
3. ✅ Обробка подій (Click, TextChanged)
4. ✅ Модальні форми (ShowDialog)
5. ✅ DataGridView для таблиць
6. ✅ Валідація та обробка помилок
7. ✅ JSON серіалізація через GUI

**Практичне застосування:**
- ✅ Управління даними через GUI
- ✅ Збереження/завантаження з файлів
- ✅ Користувацькі діалоги
- ✅ МVС архітектура (Model-View)

---

**Статус:** Готово до навчання! 🎓
