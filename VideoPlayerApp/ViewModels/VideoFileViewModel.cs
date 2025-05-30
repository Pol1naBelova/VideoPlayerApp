using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VideoPlayerApp.ViewModels
{
    public class VideoFileViewModel : INotifyPropertyChanged
    {
        public string FilePath { get; }
        private bool _isAudioSource;
        public bool IsAudioSource
        {
            get => _isAudioSource;
            set { _isAudioSource = value; OnPropertyChanged(); }
        }

        public VideoFileViewModel(string filePath)
        {
            FilePath = filePath;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}