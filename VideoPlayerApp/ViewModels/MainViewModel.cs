using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using VideoPlayerApp.Helpers;

namespace VideoPlayerApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<VideoFileViewModel> Videos { get; } = new();

        public ICommand LoadFilesCommand { get; }
        public ICommand SetAudioSourceCommand { get; }
        public ICommand RemoveVideoCommand { get; }

        public MainViewModel()
        {
            LoadFilesCommand = new RelayCommand(_ => LoadFiles());
            SetAudioSourceCommand = new RelayCommand(param =>
            {
                if (param is VideoFileViewModel vm)
                {
                    foreach (var v in Videos) v.IsAudioSource = false;
                    vm.IsAudioSource = true;
                }
            }, _ => Videos.Any());
            RemoveVideoCommand = new RelayCommand(param =>
            {
                if (param is VideoFileViewModel vm)
                    Videos.Remove(vm);
            }, param => param is VideoFileViewModel vm && Videos.Contains(vm));
        }

        private void LoadFiles()
        {
            var dlg = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Видео-файлы|*.mp4;*.avi;*.mkv|Все файлы|*.*"
            };
            if (dlg.ShowDialog() != true) return;

            foreach (var path in dlg.FileNames)
            {
                if (Videos.Any(x => x.FilePath == path)) continue;
                Videos.Add(new VideoFileViewModel(path));
            }

            if (!Videos.Any(v => v.IsAudioSource) && Videos.Count > 0)
                Videos[0].IsAudioSource = true;
        }
    }
}