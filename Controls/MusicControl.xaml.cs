using Playnite.SDK;
using Playnite.SDK.Controls;
using PlayniteSounds.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PlayniteSounds.Controls
{
    public partial class MusicControl : PluginUserControl, INotifyPropertyChanged
    {
        private PlayniteSoundsSettings _settings;

        static MusicControl()
        {
            TagProperty.OverrideMetadata(typeof(MusicControl), new FrameworkPropertyMetadata(-1, OnTagChanged));
        }

        public MusicControl(PlayniteSoundsSettings settings)
        {
            InitializeComponent();
            DataContext = this;
            _settings = settings;
            _settings.PropertyChanged += OnSettingsChanged;
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

        public string CurrentMusicName
        {
            get => _settings.CurrentMusicName;
            set => _settings.CurrentMusicName = value;
        }

        public bool VideoIsPlaying
        {
            get => _settings.VideoIsPlaying;
            set => _settings.VideoIsPlaying = value;
        }

        public void OnSettingsChanged( object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(_settings.VideoIsPlaying))
            {
                OnPropertyChanged(nameof(VideoPlayingCommand));
                OnPropertyChanged(nameof(VideoIsPlaying));
            }
            else if (args.PropertyName == nameof(_settings.CurrentMusicName))
            {
                OnPropertyChanged(nameof(CurrentMusicName));
            }
        }
    }
}
