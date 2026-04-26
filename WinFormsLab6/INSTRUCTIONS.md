## ЛР6 — WinForms: Каталог фільмів — ІНСТРУКЦІЯ ЗАПУСКУ

### 📁 Структура проекту
```
Project_Liashenko/
├── Core/
│   ├── Movie.cs
│   ├── MovieStorage.cs         ← JSON серіалізація
│   └── ... (інші класи)
│
├── ConsoleUI/                   ← Попередня ЛР (Console App)
│
└── WinFormsLab6/                ← НОВА ЛР6 (WinForms App)
    ├── Program.cs
    ├── MainForm.cs + MainForm.Designer.cs
    ├── EditForm.cs + EditForm.Designer.cs
    ├── WinFormsLab6.csproj
    └── README.md
```

---

## 🚀 ЯК ЗАПУСТИТИ

### 1️⃣ У Visual Studio
1. Відкрийте **Solution Explorer**
2. Клацніть правою кнопкою на **WinFormsLab6** проект
3. Виберіть **Set as Startup Project**
4. Натисніть **F5** або **Debug → Start Debugging**

### 2️⃣ З командного рядка
```powershell
cd C:\Users\ilya9\source\repos\Project_Liashenko
dotnet run --project WinFormsLab6/WinFormsLab6.csproj
```

---

## 📊 ФУНКЦІОНАЛЬНІСТЬ

| Функція | Опис |
|---------|------|
| **Додати** | Створює новий фільм через форму редагування |
| **Редакт.** | Редагує виділений фільм |
| **Видалити** | Видаляє з підтвердженням (MessageBox) |
| **Зберегти** | Зберігає колекцію в JSON файл (SaveFileDialog) |
| **Завант.** | Завантажує колекцію з JSON файлу (OpenFileDialog) |

---

## 🎯 ОСНОВНІ КОМПОНЕНТИ

### **MainForm.cs** — Головна форма
- **DataGridView** — таблиця з фільмами
- **BindingSource** — синхронізація даних
- **5 кнопок** — операції з фільмами
- **StatusStrip** — смуга статусу

### **EditForm.cs** — Форма редагування
- **TextBox** — для Title, Director, Genre
- **NumericUpDown** — для Year, Duration, Rating, Budget
- **CheckBox** — для IsAvailableOnline
- **Модальна** форма (ShowDialog)

### **MovieStorage.cs** (Core) — Робота з JSON
- `GetMovies()` — отримати список
- `AddMovie()` — додати
- `RemoveMovieAt()` — видалити за індексом
- `SaveToJson()` — серіалізація
- `LoadFromJson()` — десеріалізація

---

## 🔑 КЛЮЧОВІ ПОНЯТТЯ

### BindingSource (двосторонній binding)
```csharp
bindingSource.DataSource = _storage.GetMovies();
dataGridViewMovies.DataSource = bindingSource;
var movie = bindingSource.Current as Movie;  // Поточний об'єкт
```

### ShowDialog() — модальна форма
```csharp
using (var editForm = new EditForm(movie, true))
{
    if (editForm.ShowDialog() == DialogResult.OK)
    {
        // Користувач натиснув OK
    }
}
```

### MessageBox — підтвердження
```csharp
var result = MessageBox.Show(
    "Видалити?",
    "Підтвердження",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);
```

### Діалоги файлів
```csharp
// Збереження
if (saveFileDialog.ShowDialog() == DialogResult.OK)
    _storage.SaveToJson(saveFileDialog.FileName);

// Завантаження
if (openFileDialog.ShowDialog() == DialogResult.OK)
    _storage.LoadFromJson(openFileDialog.FileName);
```

---

## ⚠️ ВАЖЛИВО

- **STAThread** у `Program.Main()` — обов'язковий для WinForms
- **using (var form = new EditForm(...))** — гарантує очищення ресурсів
- **try-catch** у операціях з файлами
- **Валідація** перед збереженням

---

## 🐛 ТИПОВІ ПОМИЛКИ

| Помилка | Рішення |
|---------|---------|
| "dataGridViewMovies not found" | Перевірте `MainForm.Designer.cs` — має бути `partial class` |
| "MovieStorage not found" | Додайте reference на Core у `WinFormsLab6.csproj` |
| Form doesn't respond | Забули `[STAThread]` у `Program.Main()` |
| Changes не зберігаються | Натисніть "Зберегти" і виберіть JSON файл |

---

## 📝 ПРИКЛАД РОБОТИ

1. **Запустіть** програму
2. **Натисніть** "Додати"
3. Заповніть форму редагування
4. Натисніть **OK**
5. Фільм з'явиться у DataGridView
6. Натисніть **"Зберегти"** і виберіть місце для JSON файлу
7. Натисніть **"Завант."** щоб завантажити збережений JSON

---

## 🎓 ОСВІТНЯ ЦІННІСТЬ

Ця ЛР демонструє:
- ✅ WinForms GUI (DataGridView, TextBox, NumericUpDown, Button)
- ✅ Подієва модель (Click, ShowDialog, DialogResult)
- ✅ Двосторонній binding (BindingSource)
- ✅ Модальні форми (ShowDialog)
- ✅ JSON серіалізація (System.Text.Json)
- ✅ Обробка помилок (try-catch, MessageBox)
- ✅ МVС паттерн (MainForm, EditForm, MovieStorage)

---

**Задовго статус:** ✅ **Збірка успішна. Готово до запуску.**
