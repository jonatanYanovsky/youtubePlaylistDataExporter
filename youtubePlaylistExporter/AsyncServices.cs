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

            Console.WriteLine("Enter playlist code");
            Console.WriteLine("Example: OLAK5uy_nWEw_XDViVW6OkabOr67WU58-rN760uYE");

            var playlistCode = Console.ReadLine();

            var playlist = await youtube.Playlists.GetAsync(playlistCode);

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
                
                Console.WriteLine(Title);
            }
        }
    }
}
