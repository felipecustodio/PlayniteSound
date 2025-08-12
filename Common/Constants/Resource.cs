using Playnite.SDK;
using System;

namespace PlayniteSounds.Common.Constants
{
    public class Resource
    {
        public static string Youtube => _youtube.Value;
        private static readonly Lazy<string> _youtube = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_Youtube"));

        public static string YoutubeSearch => _youtubeSearch.Value;
        private static readonly Lazy<string> _youtubeSearch = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_YoutubeSearch"));

        public static string Actions_Normalize => _actions_Normalize.Value;
        private static readonly Lazy<string> _actions_Normalize = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_Actions_Normalize"));

        public static string Actions_TrimSilence => _actions_TrimSilence.Value;
        private static readonly Lazy<string> _actions_TrimSilence = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_Actions_TrimSilence"));

        public static string DialogMessageNormalizingFiles => _dialogMessageNormalizingFiles.Value;
        private static readonly Lazy<string> _dialogMessageNormalizingFiles = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageNormalizingFiles"));

        public static string DialogMessageTrimmingFiles => _dialogMessageTrimmingFiles.Value;
        private static readonly Lazy<string> _dialogMessageTrimmingFiles = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageTrimmingFiles"));

        public static string NormTag => _normTag.Value;
        private static readonly Lazy<string> _normTag = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_NormTag"));

        public static string MissingTag => _missingTag.Value;
        private static readonly Lazy<string> _missingTag = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MissingTag"));

        public static string ActionsDownloadMusicForGames => _actionsDownloadMusicForGames.Value;
        private static readonly Lazy<string> _actionsDownloadMusicForGames = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsDownloadMusicForGames"));

        public static string DialogMessageDownloadingFiles => _dialogMessageDownloadingFiles.Value;
        private static readonly Lazy<string> _dialogMessageDownloadingFiles = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageDownloadingFiles"));

        public static string DialogMessageAlbumSelect => _dialogMessageAlbumSelect.Value;
        private static readonly Lazy<string> _dialogMessageAlbumSelect = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageAlbumSelect"));

        public static string DialogMessageSongSelect => _dialogMessageSongSelect.Value;
        private static readonly Lazy<string> _dialogMessageSongSelect = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageSongSelect"));

        public static string DialogMessageCaptionAlbum => _dialogMessageCaptionAlbum.Value;
        private static readonly Lazy<string> _dialogMessageCaptionAlbum = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageCaptionAlbum"));

        public static string DialogMessageCaptionSong => _dialogMessageCaptionSong.Value;
        private static readonly Lazy<string> _dialogMessageCaptionSong = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageCaptionSong"));

        public static string DialogMessageOverwriteSelect => _dialogMessageOverwriteSelect.Value;
        private static readonly Lazy<string> _dialogMessageOverwriteSelect = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageOverwriteSelect"));

        public static string DialogCaptionSelectOption => _dialogCaptionSelectOption.Value;
        private static readonly Lazy<string> _dialogCaptionSelectOption = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogCaptionSelectOption"));

        public static string DialogMessageDone => _dialogMessageDone.Value;
        private static readonly Lazy<string> _dialogMessageDone = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageDone"));

        public static string DialogMessageLibUpdateAutomaticDownload => _dialogMessageLibUpdateAutomaticDownload.Value;
        private static readonly Lazy<string> _dialogMessageLibUpdateAutomaticDownload = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogMessageLibUpdateAutomaticDownload"));

        public static string Settings => _settings.Value;
        private static readonly Lazy<string> _settings = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_Settings"));

        public static string Actions => _actions.Value;
        private static readonly Lazy<string> _actions = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_Actions"));

        public static string ActionsReloadAudioFiles => _actionsReloadAudioFiles.Value;
        private static readonly Lazy<string> _actionsReloadAudioFiles = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsReloadAudioFiles"));

        public static string ActionsOpenSoundsFolder => _actionsOpenSoundsFolder.Value;
        private static readonly Lazy<string> _actionsOpenSoundsFolder = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsOpenSoundsFolder"));

        public static string ActionsOpenMusicFolder => _actionsOpenMusicFolder.Value;
        private static readonly Lazy<string> _actionsOpenMusicFolder = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsOpenMusicFolder"));

        public static string ActionsOpenSelected => _actionsOpenSelected.Value;
        private static readonly Lazy<string> _actionsOpenSelected = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsOpenSelected"));

        public static string ActionsDeleteSelected => _actionsDeleteSelected.Value;
        private static readonly Lazy<string> _actionsDeleteSelected = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsDeleteSelected"));

        public static string ActionsHelp => _actionsHelp.Value;
        private static readonly Lazy<string> _actionsHelp = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsHelp"));

        public static string ActionsShowMusicFilename => _actionsShowMusicFilename.Value;
        private static readonly Lazy<string> _actionsShowMusicFilename = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsShowMusicFilename"));

        public static string ActionsCopySelectMusicFile => _actionsCopySelectMusicFile.Value;
        private static readonly Lazy<string> _actionsCopySelectMusicFile = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsCopySelectMusicFile"));

        public static string Actions_Download => _actions_Download.Value;
        private static readonly Lazy<string> _actions_Download = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_Actions_Download"));

        public static string ActionsCopyDeleteMusicFile => _actionsCopyDeleteMusicFile.Value;
        private static readonly Lazy<string> _actionsCopyDeleteMusicFile = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsCopyDeleteMusicFile"));

        public static string ActionsCopyPlayMusicFile => _actionsCopyPlayMusicFile.Value;
        private static readonly Lazy<string> _actionsCopyPlayMusicFile = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsCopyPlayMusicFile"));

        public static string ActionsSubMenuSongs => _actionsSubMenuSongs.Value;
        private static readonly Lazy<string> _actionsSubMenuSongs = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsSubMenuSongs"));

        public static string ActionsPlatform => _actionsPlatform.Value;
        private static readonly Lazy<string> _actionsPlatform = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsPlatform"));

        public static string ActionsFilter => _actionsFilter.Value;
        private static readonly Lazy<string> _actionsFilter = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsFilter"));

        public static string ActionsDefault => _actionsDefault.Value;
        private static readonly Lazy<string> _actionsDefault = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ActionsDefault"));

        public static string DialogDeleteMusicDirectory => _dialogDeleteMusicDirectory.Value;
        private static readonly Lazy<string> _dialogDeleteMusicDirectory = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogDeleteMusicDirectory"));

        public static string DialogDeleteMusicFile => _dialogDeleteMusicFile.Value;
        private static readonly Lazy<string> _dialogDeleteMusicFile = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogDeleteMusicFile"));

        public static string DialogUpdateLegacyOrphans => _dialogUpdateLegacyOrphans.Value;
        private static readonly Lazy<string> _dialogUpdateLegacyOrphans = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_DialogUpdateLegacyOrphans"));

        public static string MsgAudioFilesReloaded => _msgAudioFilesReloaded.Value;
        private static readonly Lazy<string> _msgAudioFilesReloaded = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgAudioFilesReloaded"));

        public static string MsgSelectSingleGame => _msgSelectSingleGame.Value;
        private static readonly Lazy<string> _msgSelectSingleGame = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgSelectSingleGame"));

        public static string MsgMusicPath => _msgMusicPath.Value;
        private static readonly Lazy<string> _msgMusicPath = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgMusicPath"));

        public static string MsgHelp1 => _msgHelp1.Value;
        private static readonly Lazy<string> _msgHelp1 = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgHelp1"));

        public static string MsgHelp2 => _msgHelp2.Value;
        private static readonly Lazy<string> _msgHelp2 = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgHelp2"));

        public static string MsgHelp3 => _msgHelp3.Value;
        private static readonly Lazy<string> _msgHelp3 = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgHelp3"));

        public static string MsgHelp4 => _msgHelp4.Value;
        private static readonly Lazy<string> _msgHelp4 = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgHelp4"));

        public static string MsgHelp5 => _msgHelp5.Value;
        private static readonly Lazy<string> _msgHelp5 = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgHelp5"));

        public static string MsgHelp6 => _msgHelp6.Value;
        private static readonly Lazy<string> _msgHelp6 = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgHelp6"));

        public static string MsgHelp7 => _msgHelp7.Value;
        private static readonly Lazy<string> _msgHelp7 = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MsgHelp7"));

        public static string MusicVolume => _musicVolume.Value;
        private static readonly Lazy<string> _musicVolume = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_MusicVolume"));

        public static string Manager => _manager.Value;
        private static readonly Lazy<string> _manager = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_Manager"));

        public static string ManagerLoad => _managerLoad.Value;
        private static readonly Lazy<string> _managerLoad = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ManagerLoad"));

        public static string ManagerSave => _managerSave.Value;
        private static readonly Lazy<string> _managerSave = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ManagerSave"));

        public static string ManagerSaveConfirm => _managerSaveConfirm.Value;
        private static readonly Lazy<string> _managerSaveConfirm = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ManagerSaveConfirm"));

        public static string ManagerLoadConfirm => _managerLoadConfirm.Value;
        private static readonly Lazy<string> _managerLoadConfirm = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ManagerLoadConfirm"));

        public static string ManagerDeleteConfirm => _managerDeleteConfirm.Value;
        private static readonly Lazy<string> _managerDeleteConfirm = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ManagerDeleteConfirm"));

        public static string ManagerRemove => _managerRemove.Value;
        private static readonly Lazy<string> _managerRemove = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ManagerRemove"));

        public static string ManagerImport => _managerImport.Value;
        private static readonly Lazy<string> _managerImport = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ManagerImport"));

        public static string ManagerOpenManagerFolder => _managerOpenManagerFolder.Value;
        private static readonly Lazy<string> _managerOpenManagerFolder = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_ManagerOpenManagerFolder"));

        public static string Migrate => _migrate.Value;
        private static readonly Lazy<string> _migrate = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_Migrate"));

        public static string CreateBackup => _createBackup.Value;
        private static readonly Lazy<string> _createBackup = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_CreateBackup"));

        public static string TimeoutError => _timeoutError.Value;
        private static readonly Lazy<string> _timeoutError = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_TimeoutError"));

        public static string WereErrors => _wereErrors.Value;
        private static readonly Lazy<string> _wereErrors = new Lazy<string>(() => ToId("LOC_PLAYNITESOUNDS_WereError"));

        private static string ToId(string id) => ResourceProvider.GetString(id);
     }
 }
