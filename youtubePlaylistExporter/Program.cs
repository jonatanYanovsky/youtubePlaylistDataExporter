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
            DateTime localDate = DateTime.Now;
            var mystring = localDate.ToString().Replace('/', '_').Replace(' ', '.').Replace(':','_');
            var writer = new StreamWriter("../playlist_output." + mystring + ".csv");
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            
            AsyncServices asyncServices = new AsyncServices();
            List<VideoData> videoDataList = new List<VideoData>();

            asyncServices.GetVideos(videoDataList).GetAwaiter().GetResult();

            csv.WriteRecords(videoDataList);
            writer.Close();

            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("Playlist data written to: playlist_output." + mystring + ".csv");
            Console.ReadLine();
        }
    }
}