using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using Playnite.SDK;
using PlayniteSounds.Models;


namespace PlayniteSounds.Downloaders
{
    internal class YtDownloader : IDownloader
    {
        private static readonly ILogger Logger = LogManager.GetLogger();

        private readonly PlayniteSoundsSettings _settings;
        private readonly HttpClient _httpClient;

        public YtDownloader(HttpClient httpClient, PlayniteSoundsSettings settings)
        {
            _settings = settings;
            _httpClient = httpClient;
        }

        private const string BaseYtUrl = "https://www.youtube.com";
        public string BaseUrl() => BaseYtUrl;

        private const string youtubeDLArg = " -x --audio-format mp3 --audio-quality 0 --ffmpeg-location=\"{0}\" -o \"{3}\" {1}/watch?v={2}";

        private const Source DlSource = Source.Youtube;
        public Source DownloadSource() => DlSource;

        public IEnumerable<Album> GetAlbumsForGame(string gameName, bool auto = false)
            => GetAlbumsFromYoutubeClient(gameName, auto);

        public IEnumerable<Song> GetSongsFromAlbum(Album album)
            => album.Songs ?? GetSongsFromYoutubeClient(album);

        public bool DownloadSong(Song song, string path) => DownloadSongFromYoutubeDl(song, path);

        private IEnumerable<Album> GetAlbumsFromYoutubeClient(string gameName, bool auto)
        {
            try
            {
                return new YoutubeClient(_httpClient)
                    .Search(gameName + (auto ? " Soundtrack" : ""), 100)
                    .Select(x =>
                        new Album
                        {
                            Name = x.Title,
                            Id = x.Id,
                            Source = Source.Youtube,
                            IconUrl = x.ThumbnailUrl.ToString(),
                            Count = x.Count
                        })
                    .ToList();
            }
            catch {}

            return null;
        }

        private IEnumerable<Song> GetSongsFromYoutubeClient(Album album)
        {
            try
            {
                return new YoutubeClient(_httpClient)
                    .Playlist(album.Id)
                    .Select(x => new Song
                    {
                        Name = x.Title,
                        Id = x.Id,
                        Length = x.Duration,
                        Source = DlSource,
                        IconUrl = x.ThumbnailUrl.ToString()
                    });
            } 
            catch {}
            return null;
        }

        private bool DownloadSongFromYoutubeDl(Song song, string path)
        {
            string downloader = _settings.YtDlpPath;
            string arguments = string.Format(youtubeDLArg, _settings.FFmpegPath, BaseUrl(), song.Id, path);
            string workDir = Path.GetDirectoryName(_settings.YtDlpPath);
            
            try
            {
                Logger.Debug($"Starting downloader: {downloader}, {arguments}, {workDir}");
                var startupPath = downloader;
                if (downloader.Contains(".."))
                {
                    startupPath = Path.GetFullPath(downloader);
                }

                var info = new ProcessStartInfo(startupPath)
                {
                    Arguments = arguments,
                    WorkingDirectory = string.IsNullOrEmpty(workDir) ? (new FileInfo(startupPath)).Directory.FullName : workDir,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                int result = 0;
                using (var proc = Process.Start(info))
                {
                    proc.WaitForExit();
                    result = proc.ExitCode;
                    if (result != 0)
                    {
                        throw new Exception($"Fail to download. Error code is {result}");
                    }
                }             
            }
            catch (Exception e)
            {
                Logger.Error(e, $"Something went wrong when attempting to download from Youtube with Id '{song.Id}' and Path '{path}'");
                return false;
            }
            return true;
        }
    }
}
