using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Playlists;
using CsvHelper;
using System.Globalization;
using System.IO;
using VideoDataNameSpace;


namespace youtubePlaylistExporter {
    class Program {
        static void Main(string[] args) {
            AsyncServices asyncServices = new AsyncServices();
            List<VideoData> videoDataList = new List<VideoData>();

            asyncServices.GetVideos(videoDataList).GetAwaiter().GetResult();

            /*for (int i = 0; i < 6; i++) {
                VideoData videoData = new VideoData();
                videoData.Description = "d";
                videoData.Title = "t";
                videoData.Url = "u";

                videoDataList.Add(videoData);
            }*/

            var writer = new StreamWriter("playlist_output.csv");
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(videoDataList);
            writer.Close();
            /*foreach (VideoData videoData in videoDataList) {
                csv.WriteRecord(videoData);
                csv.NextRecord();
            }*/

            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
        }
    }
}