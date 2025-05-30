using System.Windows;
using VideoPlayerApp.ViewModels;

namespace VideoPlayerApp.Views
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