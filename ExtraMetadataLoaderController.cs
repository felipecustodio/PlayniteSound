using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using Playnite.SDK;
using PlayniteSounds.Models;

namespace PlayniteSounds
{
    static class ExtraMetaDataLoaderController
    {
        private static IPlayniteAPI PlayniteApi;
        private static PlayniteSoundsSettings Settings;
        private static dynamic ExtraMetadataLoader;
        private static readonly ILogger Logger = LogManager.GetLogger();

        static public bool Attach(IPlayniteAPI api, PlayniteSoundsSettings settings) {
            PlayniteApi = api;
            Settings = settings;
            var plugins = PlayniteApi.Addons.Plugins;
            ExtraMetadataLoader = plugins.FirstOrDefault(p => p.ToString() == "ExtraMetadataLoader.ExtraMetadataLoader");
            var emlSettings = ExtraMetadataLoader.settings.Settings as ObservableObject;
            emlSettings.PropertyChanged += OnExtraMetadataLoaderPropertyChanged;
            return true;
        }

        static private void AttachVideoControl(dynamic videoControl)
        {
            videoControl.PropertyChanged += new PropertyChangedEventHandler(OnVideoControlPropertyChanged);
        }

        static List<dynamic> GetVideoControls() {
            return new List<dynamic>(ExtraMetadataLoader
                .GetType()
                .GetField("configuredVideoControls", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(ExtraMetadataLoader));
        }

        static void OnVideoControlChanged() {

            bool videoSoundIsPlaying = ExtraMetadataLoader.settings.Settings.IsVideoPlaying &&
                GetVideoControls().Any(vc => vc.IsVisible && vc.IsSoundEnabled && !vc.IsPlayerMuted);

            if (Settings.VideoIsPlaying != videoSoundIsPlaying)
            {
                Settings.VideoIsPlaying = videoSoundIsPlaying;
            }
        }

        static private void OnVideoControlPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if  (args.PropertyName == "PlaybackTimeProgress")
            {
                dynamic videoControl = sender;
                if (!videoControl.IsVisible && Settings.VideoIsPlaying) {
                    OnVideoControlChanged();
                }
            }
            else if (new List<string> {
                 "IsPlayerMuted",
                 "VideoPlayCommand",
                 "VideoPauseCommand",
                 "ControlVisibility"}.Contains(args.PropertyName)) {
                OnVideoControlChanged();
            }
        }

        static private void OnExtraMetadataLoaderPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            dynamic settings = sender;
            if  (args.PropertyName == "IsVideoPlaying" && settings.IsVideoPlaying)
            {
                foreach (dynamic videoControl in GetVideoControls())
                {
                    AttachVideoControl(videoControl);
                }
                OnVideoControlChanged();
            }
        }

    }
}