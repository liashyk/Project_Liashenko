using System;
using System.Collections.ObjectModel;
using System.Windows;
using Core;

namespace WpfLab7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
