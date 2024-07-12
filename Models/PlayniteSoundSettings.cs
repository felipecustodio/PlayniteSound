using Playnite.SDK.Data;
using System;
using System.Collections.Generic;

namespace PlayniteSounds.Models
{
    public class PlayniteSoundsSettings: ObservableObject
    {
        public AudioState MusicState { get; set; } = AudioState.Always;
        public AudioState SoundState { get; set; } = AudioState.Always;
        public MusicType MusicType { get; set; } = MusicType.Game;

        [DontSerialize]
        public int MusicVolume
        {
            get => (int)(100 * PlayniteSounds.FullscreenSettings.BackgroundVolume);
            set
            {
                PlayniteSounds.FullscreenSettings.BackgroundVolume = (float)value / 100;
                OnPropertyChanged();
            }
        }

        public bool StopMusic { get; set; } = true;
        public bool SkipFirstSelectSound { get; set; }
        public bool PlayBackupMusic { get; set; }

        [DontSerialize]
        public bool PauseOnDeactivate
        {
            get => PlayniteSounds.FullscreenSettings.MuteInBackground;
            set { PlayniteSounds.FullscreenSettings.MuteInBackground = value; }
        }

        public bool RandomizeOnEverySelect { get; set; }
        public bool RandomizeOnMusicEnd { get; set; } = true;
        public bool TagMissingEntries { get; set; }
        public bool AutoDownload { get; set; }
        public bool AutoParallelDownload { get; set; }
        public bool ManualParallelDownload { get; set; } = true;
        public bool YtPlaylists { get; set; } = true;
        public bool NormalizeMusic { get; set; } = true;
        public bool TagNormalizedGames { get; set; }

        [DontSerialize]
        private string ytDlpPath { get; set; }
        public string YtDlpPath {
            get => ytDlpPath;
            set
            {
                ytDlpPath = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private string ffmpegPath { get; set; }
        public string FFmpegPath
        {
            get => ffmpegPath;
            set
            {
                ffmpegPath = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private string ffmpegNormalizePath { get; set; }
        public string FFmpegNormalizePath
        {
            get => ffmpegNormalizePath;
            set
            {
                ffmpegNormalizePath = value;
                OnPropertyChanged();
            }
        }


        public string FFmpegNormalizeArgs { get; set; }
        public IList<Source> Downloaders { get; set; } = new List<Source> { Source.Youtube };
        public DateTime LastAutoLibUpdateAssetsDownload { get; set; } = DateTime.Now;
        public bool PromptedForMigration { get; set; }

        [DontSerialize]
        private bool videoIsPlaying { get; set; }
        [DontSerialize]
        public bool VideoIsPlaying
        {
            get => videoIsPlaying;
            set {
                videoIsPlaying = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private string currentMusicName { get; set; } = string.Empty;
        [DontSerialize]
        public string CurrentMusicName
        {
            get => currentMusicName;
            set {
                currentMusicName = value;
                OnPropertyChanged();
            }
        }

        public bool PauseOnTrailer { get; set; } = true;
    }
}
