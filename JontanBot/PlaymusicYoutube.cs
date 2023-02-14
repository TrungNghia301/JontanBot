using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JontanTeleBot.Program;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode;
namespace JontanTeleBot
{
    internal class PlaymusicYoutube
    {
        public static async Task PlayMusic()
        {
            var youtube = new YoutubeClient();
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(Yturl);
            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
            string name = ".mp4";
            await youtube.Videos.Streams.DownloadAsync(streamInfo, Path.Combine("PATH_File mp4 to save music", name));
        }
    }
}
