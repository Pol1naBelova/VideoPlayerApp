using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Controls;

namespace VideoPlayerApp
{
    public partial class MainWindow : Window
    {
        private readonly List<MediaElement> _allMedia = new();
        private readonly DispatcherTimer _syncTimer;

        public MainWindow()
        {
            InitializeComponent();

            VolumeSlider.Value = 0.5;
            GlobalPositionSlider.Value = 0;

            _syncTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            _syncTimer.Tick += SyncTimer_Tick;
            _syncTimer.Start();
        }

        // Регистрируем каждый MediaElement для глобального управления
        public void RegisterMedia(MediaElement media)
        {
            if (!_allMedia.Contains(media))
                _allMedia.Add(media);
        }

        public void UnregisterMedia(MediaElement media)
        {
            _allMedia.Remove(media);
        }

        private void PlayAll_Click(object sender, RoutedEventArgs e)
            => _allMedia.ForEach(m => m.Play());

        private void PauseAll_Click(object sender, RoutedEventArgs e)
            => _allMedia.ForEach(m => m.Pause());

        private void StopAll_Click(object sender, RoutedEventArgs e)
            => _allMedia.ForEach(m => m.Stop());

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            => _allMedia.ForEach(m => m.Volume = VolumeSlider.Value);

        private void GlobalPositionSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var pos = TimeSpan.FromSeconds(GlobalPositionSlider.Value);
            _allMedia.ForEach(m => m.Position = pos);
        }

        private void SyncTimer_Tick(object sender, EventArgs e)
        {
            // Синхронизируем положение по первому неприглушённому видео
            foreach (var m in _allMedia)
            {
                if (m.IsMuted) continue;
                if (m.NaturalDuration.HasTimeSpan)
                {
                    GlobalPositionSlider.Maximum = m.NaturalDuration.TimeSpan.TotalSeconds;
                    GlobalPositionSlider.Value   = m.Position.TotalSeconds;
                }
                break;
            }
        }
    }
}
