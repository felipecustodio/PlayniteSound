using Playnite.SDK;
using Playnite.SDK.Controls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PlayniteSounds.Controls 
{
    public partial class MusicControl : PluginUserControl, INotifyPropertyChanged
    {
        IPlayniteAPI PlayniteApi;
        private PlayniteSounds _playniteSounds;

        static MusicControl()
        {
            TagProperty.OverrideMetadata(typeof(MusicControl), new FrameworkPropertyMetadata(-1, OnTagChanged));
        }

        public MusicControl(IPlayniteAPI PlayniteApi, PlayniteSounds plugin)
        {
            this.PlayniteApi = PlayniteApi;
            InitializeComponent();
            DataContext = this;
            _playniteSounds = plugin;
        }
        private static void OnTagChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MusicControl).VideoIsPlaying = Convert.ToBoolean(e.NewValue);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public RelayCommand<bool> VideoPlayingCommand
            => new RelayCommand<bool>(videoIsPlaying => VideoIsPlaying = videoIsPlaying);

        private string _currentMusicName=string.Empty;
        public string CurrentMusicName
        {
            get => _currentMusicName;
            set
            {
                _currentMusicName = value;
                OnPropertyChanged(nameof(CurrentMusicName));
            }
        }

        private bool _videoIsPlaying = false;
        public bool VideoIsPlaying
        {
            get => _videoIsPlaying;
            set
            {
                _videoIsPlaying = value;
                if (_videoIsPlaying)
                    _playniteSounds.MusicPause();
                else 
                    _playniteSounds.MusicResume();

                OnPropertyChanged(nameof(VideoPlayingCommand));
                OnPropertyChanged(nameof(VideoIsPlaying));
            }
        }
    }
}
