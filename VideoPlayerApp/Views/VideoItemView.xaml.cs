using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using VideoPlayerApp.ViewModels;

namespace VideoPlayerApp.Views
{
    public partial class VideoItemView : UserControl
    {
        private readonly DispatcherTimer _positionTimer;

        public VideoItemView()
        {
            InitializeComponent();

            Loaded   += (s, e) => (Application.Current.MainWindow as VideoPlayerApp.MainWindow)?.RegisterMedia(mediaElement);
            Unloaded += (s, e) => (Application.Current.MainWindow as VideoPlayerApp.MainWindow)?.UnregisterMedia(mediaElement);

            // Таймер синхронизации ползунка
            _positionTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            _positionTimer.Tick += (_, __) =>
            {
                if (mediaElement.NaturalDuration.HasTimeSpan)
                {
                    PositionSlider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                    PositionSlider.Value   = mediaElement.Position.TotalSeconds;
                }
            };

            mediaElement.MediaOpened += (_, __) => _positionTimer.Start();
            mediaElement.MediaEnded  += (_, __) => _positionTimer.Stop();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
            => mediaElement.Play();

        private void PauseButton_Click(object sender, RoutedEventArgs e)
            => mediaElement.Pause();

        private void StopButton_Click(object sender, RoutedEventArgs e)
            => mediaElement.Stop();

        private void PositionSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            => mediaElement.Position = TimeSpan.FromSeconds(PositionSlider.Value);
    }
}
