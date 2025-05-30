using System;
using System.Windows;
using System.Windows.Input;
using VideoPlayerApp.ViewModels;

namespace VideoPlayerApp.Views
{
    public partial class FullScreenWindow : Window
    {
        private readonly TimeSpan _startPosition;
        public TimeSpan FinalPosition { get; private set; }

        public FullScreenWindow(VideoFileViewModel vm, TimeSpan startPosition)
        {
            InitializeComponent();

            fullScreenMedia.Source = new Uri(vm.FilePath, UriKind.Absolute);
            _startPosition         = startPosition;
            fullScreenMedia.MediaOpened += OnMediaOpened;
        }

        private void OnMediaOpened(object sender, RoutedEventArgs e)
        {
            fullScreenMedia.Position = _startPosition;
            fullScreenMedia.Play();
            fullScreenMedia.MediaOpened -= OnMediaOpened;
        }

        private void FullScreenMedia_MouseDown(object sender, MouseButtonEventArgs e)
            => CloseAndSave();

        private void ExitFullscreen_Click(object sender, RoutedEventArgs e)
            => CloseAndSave();

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                CloseAndSave();
        }

        private void CloseAndSave()
        {
            FinalPosition = fullScreenMedia.Position;
            fullScreenMedia.Stop();
            Close();
        }
    }
}