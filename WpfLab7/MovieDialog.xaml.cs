using System;
using System.Windows;
using Core;

namespace WpfLab7
{
    public partial class MovieDialog : Window
    {
        public Movie? Result { get; private set; }

        public MovieDialog()
        {
            InitializeComponent();
            ReleaseDatePicker.SelectedDate = DateTime.Now;
        }

        public MovieDialog(Movie existing) : this()
        {
            TitleBox.Text = existing.Title;
            DirectorBox.Text = existing.Director;
            ReleaseDatePicker.SelectedDate = existing.ReleaseDate;
            RatingBox.Text = existing.AverageRating.ToString();
            Result = existing;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(RatingBox.Text, out var rating)) rating = 0;

            Result = new Movie
            {
                Title = TitleBox.Text ?? string.Empty,
                Director = DirectorBox.Text ?? string.Empty,
                ReleaseDate = ReleaseDatePicker.SelectedDate ?? DateTime.Now,
                AverageRating = rating
            };

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
