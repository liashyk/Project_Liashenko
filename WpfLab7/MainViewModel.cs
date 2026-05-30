using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Core;
using System.Linq;

namespace WpfLab7
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Movie> Movies { get; } = new();

        private Movie? _selected;
        public Movie? Selected
        {
            get => _selected; set { _selected = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            AddCommand = new RelayCommand(_ => AddMovie());
            DeleteCommand = new RelayCommand(_ => DeleteSelected(), _ => Selected != null);

            // sample movies (from movies.json)
            Movies.Add(new Movie { Id = 1, Title = "Початок", Director = "Крістофер Нолан", Genre = "Трилер", ReleaseDate = new System.DateTime(2010,7,16), DurationMinutes = 148, AverageRating = 8.8, IsAvailableOnline = true, Budget = 160_000_000 });
            Movies.Add(new Movie { Id = 2, Title = "Темний лицар", Director = "Крістофер Нолан", Genre = "Бойовик", ReleaseDate = new System.DateTime(2008,7,18), DurationMinutes = 152, AverageRating = 9.0, IsAvailableOnline = true, Budget = 185_000_000 });
            Movies.Add(new Movie { Id = 3, Title = "Інтерстеллар", Director = "Крістофер Нолан", Genre = "Фантастика", ReleaseDate = new System.DateTime(2014,11,7), DurationMinutes = 169, AverageRating = 8.6, IsAvailableOnline = true, Budget = 165_000_000 });
        }

        private void AddMovie()
        {
            var m = new Movie { Title = "Новий фільм", Director = "", ReleaseDate = System.DateTime.Now, AverageRating = 0 };
            Movies.Add(m);
            Selected = m;
        }

        private void DeleteSelected()
        {
            if (Selected != null) Movies.Remove(Selected);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // business helpers
        public double AverageRating() => Movies.Count == 0 ? 0 : Movies.Average(m => m.AverageRating);
        public long TotalBudget() => (long)Movies.Sum(m => m.Budget);

        public IEnumerable<Movie> FilterByTitle(string q) => Movies.Where(m => m.Title.Contains(q, System.StringComparison.OrdinalIgnoreCase));
    }
}
