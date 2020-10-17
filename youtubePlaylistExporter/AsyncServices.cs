using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using VideoDataNameSpace;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace youtubePlaylistExporter {
    public class AsyncServices {
        public async Task GetVideos(List<VideoData> videoDataList) {
            var youtube = new YoutubeClient();
            var playlist = await youtube.Playlists.GetAsync("OLAK5uy_nWEw_XDViVW6OkabOr67WU58-rN760uYE");
            // OLAK5uy_nWEw_XDViVW6OkabOr67WU58-rN760uYE PLabyTvUoQxdEElUs-tSasRZaO2us9d3lq

            //var writer = new StreamWriter("C:/Users/Jon/Documents/youtubePlaylistDownloader/playlist_output.csv");
            //var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);


            VideoData videoDataHeader = new VideoData();
            videoDataHeader.Title = playlist.Title;
            videoDataHeader.Description = "Description";
            videoDataHeader.Url = playlist.Url;
            videoDataList.Add(videoDataHeader);


            var somePlaylistVideos = await youtube.Playlists.GetVideosAsync(playlist.Id);
            foreach (var video in somePlaylistVideos) {
                var Title = video.Title;
                var Description = video.Description;
                var Url = video.Url;

                VideoData videoData = new VideoData();

                videoData.Title = Title;
                videoData.Description = Description;
                videoData.Url = Url;

                videoDataList.Add(videoData);

                //var videoDataLine = $"{title},{url},{description}";
                Console.WriteLine(Title);
            }
            //await csv.WriteRecordsAsync(videoDataList);

        }
    }
}
