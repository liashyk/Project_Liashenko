using System;
using System.Collections.ObjectModel;
using System.Windows;
using Core;

namespace WpfLab7
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Movie> _movies = new();

        public MainWindow()
        {
            InitializeComponent();

            // initial movies from data
            _movies.Add(new Movie { Id = 1, Title = "Початок", Director = "Крістофер Нолан", Genre = "Трилер", ReleaseDate = new DateTime(2010,7,16), DurationMinutes = 148, AverageRating = 8.8, IsAvailableOnline = true, Budget = 160000000 });
            _movies.Add(new Movie { Id = 2, Title = "Темний лицар", Director = "Крістофер Нолан", Genre = "Бойовик", ReleaseDate = new DateTime(2008,7,18), DurationMinutes = 152, AverageRating = 9.0, IsAvailableOnline = true, Budget = 185000000 });
            _movies.Add(new Movie { Id = 3, Title = "Інтерстеллар", Director = "Крістофер Нолан", Genre = "Фантастика", ReleaseDate = new DateTime(2014,11,7), DurationMinutes = 169, AverageRating = 8.6, IsAvailableOnline = true, Budget = 165000000 });

            MoviesGrid.ItemsSource = _movies;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MovieDialog();
            if (dialog.ShowDialog() == true && dialog.Result is Movie m)
                _movies.Add(m);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (MoviesGrid.SelectedItem is not Movie selected) return;
            var dialog = new MovieDialog(selected);
            if (dialog.ShowDialog() == true && dialog.Result is Movie m)
            {
                var idx = _movies.IndexOf(selected);
                if (idx >= 0) _movies[idx] = m;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MoviesGrid.SelectedItem is Movie selected)
                _movies.Remove(selected);
        }
    }
}
