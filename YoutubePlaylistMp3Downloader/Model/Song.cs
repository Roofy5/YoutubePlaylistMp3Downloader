using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistMp3Downloader.Model
{
    class Song
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string ImageUrl { get; set; }
        public byte[] Image { get; set; }
        public byte[] SongData { get; set; }

        public Song()
        {
            Title = string.Empty;
            Duration = TimeSpan.Zero;
            ImageUrl = string.Empty;
            Image = null;
            SongData = null;
        }
    }
}
