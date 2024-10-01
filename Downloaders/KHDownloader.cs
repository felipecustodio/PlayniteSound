using Playnite.SDK;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System;
using HtmlAgilityPack;
using PlayniteSounds.Common;
using PlayniteSounds.Models;

namespace PlayniteSounds.Downloaders
{
    internal class KhDownloader : IDownloader
    {
        private static readonly ILogger Logger = LogManager.GetLogger();

        private readonly HttpClient _httpClient;
        private readonly HtmlWeb _web;

        private const string KhInsiderBaseUrl = @"https://downloads.khinsider.com/";
        public string BaseUrl() => KhInsiderBaseUrl;

        private const Source Source = Models.Source.KHInsider;
        public Source DownloadSource() => Source;

        public KhDownloader(HttpClient httpClient, HtmlWeb web)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
            _web = web;
        }

        public IEnumerable<Album> GetAlbumsForGame(string gameName, CancellationToken cancellationToken, bool auto = false)
        {

            var albumsToPartialUrls = new List<Album>();
            try
            {
                var htmlDoc=_web.LoadFromWebAsync($"{KhInsiderBaseUrl}search?search={gameName}", cancellationToken).Result;

                var tableRows = htmlDoc.DocumentNode.Descendants("tr").Skip(1);
                foreach (var row in tableRows)
                {
                    var columnEntries = row.Descendants("td").ToList();

                    var iconUrl = string.Empty;
                    var iconField = columnEntries.FirstOrDefault();
                    if (iconField != null)
                    {
                        var img = iconField.Descendants("img").FirstOrDefault();
                        if (img != null)
                        {
                            iconUrl = img.GetAttributeValue("src", string.Empty);
                        }
                    }

                    var titleField = columnEntries.ElementAtOrDefault(1);
                    if (titleField == null)
                    {
                        Logger.Info($"Found album entry of game '{gameName}' without title field");
                        continue;
                    }

                    var htmlLink = titleField.Descendants("a").FirstOrDefault();
                    if (htmlLink == null)
                    {
                        Logger.Info($"Found entry for album entry of game '{gameName}' without title");
                        continue;
                    }

                    var albumName = htmlLink.InnerHtml;
                    var albumPartialLink = htmlLink.GetAttributeValue("href", null);
                    if (albumPartialLink == null)
                    {
                        Logger.Info($"Found entry for album '{albumName}' of game '{gameName}' without link in title");
                        continue;
                    }

                    var album = new Album
                    {
                        Name = StringUtilities.StripStrings(albumName),
                        Id = albumPartialLink,
                        Source = Source.KHInsider,
                        IconUrl = iconUrl
                    };

                    var platformEntry = columnEntries.ElementAtOrDefault(2);
                    if (platformEntry != null)
                    {
                        var platforms = platformEntry.Descendants("a")
                            .Select(d => d.InnerHtml)
                            .Where(platform => !string.IsNullOrWhiteSpace(platform)).ToList();

                        if (platforms.Any())
                        {
                            album.Platforms = platforms;
                        }
                    }

                    var typeEntry = columnEntries.ElementAtOrDefault(3);
                    if (typeEntry != null && !string.IsNullOrWhiteSpace(typeEntry.InnerText))
                    {
                        album.Type = typeEntry.InnerText;
                    }

                    var yearEntry = columnEntries.ElementAtOrDefault(4);
                    if (yearEntry != null && !string.IsNullOrWhiteSpace(yearEntry.InnerText))
                    {
                        album.Year = yearEntry.InnerText;
                    }

                    albumsToPartialUrls.Add(album);
                }
            }
            catch (Exception e)
            {
                PlayniteSounds.HandleException(e, cancellationToken);
            }
            return albumsToPartialUrls;
        }

        public IEnumerable<Song> GetSongsFromAlbum(Album album, CancellationToken cancellationToken)
        {
            var songs = new List<Song>();
            try
            {

                var htmlDoc = _web.LoadFromWebAsync($"{KhInsiderBaseUrl}{album.Id}", cancellationToken).Result; ;

                // Validate Html
                var headerRow = htmlDoc.GetElementbyId("songlist_header");
                var headers = headerRow.Descendants("th").Select(n => n.InnerHtml);
                if (headers.All(h => !h.Contains("MP3")))
                {
                    Logger.Info($"No mp3 in album '{album.Name}'");
                    return songs;
                }

                var table = htmlDoc.GetElementbyId("songlist");

                // Get table and skip header
                var tableRows = table.Descendants("tr").Skip(1).ToList();
                if (tableRows.Count < 2)
                {
                    Logger.Info($"No songs in album '{album.Name}'");
                    return songs;
                }

                // Remove footer
                tableRows.RemoveAt(tableRows.Count - 1);

                foreach (var row in tableRows)
                {
                    var rowEntries = row.Descendants("a").ToList();

                    var songNameEntry = rowEntries.FirstOrDefault();
                    if (songNameEntry == null)
                    {
                        continue;
                    }

                    var partialUrl = songNameEntry.GetAttributeValue("href", null);
                    if (string.IsNullOrWhiteSpace(partialUrl))
                    {
                        continue;
                    }

                    var song = new Song
                    {
                        Name = StringUtilities.StripStrings(songNameEntry.InnerHtml),
                        Id = partialUrl,
                        Source = Source.KHInsider
                    };

                    var lengthEntry = rowEntries.ElementAtOrDefault(1);
                    if (lengthEntry != null && !string.IsNullOrWhiteSpace(lengthEntry.InnerHtml))
                    {
                        song.Length = StringUtilities.GetTimeSpan(lengthEntry.InnerHtml);
                    }

                    var sizeEntry = rowEntries.ElementAtOrDefault(2);
                    if (sizeEntry != null && !string.IsNullOrWhiteSpace(sizeEntry.InnerHtml))
                    {
                        song.SizeInMb = sizeEntry.InnerHtml;
                    }

                    songs.Add(song);
                }
            }
            catch (Exception e)
            {
                PlayniteSounds.HandleException(e, cancellationToken);
            }

            return songs;
            }

        public bool DownloadSong(Song song, string path, CancellationToken cancellationToken)
        {
            // Get Url to file from Song html page
            var htmlDoc = _web.LoadFromWebAsync($"{KhInsiderBaseUrl}{song.Id}", cancellationToken).Result;

            var fileUrl = htmlDoc.GetElementbyId("audio").GetAttributeValue("src", null);
            if (fileUrl == null)
            {
                Logger.Info($"Did not find file url for song '{song.Name}'");
                return false;
            }

            try
            {
                var httpMessage = _httpClient.GetAsync(fileUrl, cancellationToken).Result;
                using (var fs = File.Create(path))
                {
                    httpMessage.Content.CopyToAsync(fs).Wait();
                }
            }
            catch (Exception e)
            {
                if (cancellationToken.IsCancellationRequested)
                    return false;
                else throw e;
            }

            return true;
        }
    }
}
