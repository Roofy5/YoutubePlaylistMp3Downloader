using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace YoutubePlaylistMp3Downloader.Model
{
    class SongItem : Song
    {
        public bool ToDownload { get; set; }
        public bool IsDownloaded { get; set; }

        public SongItem(Song song) : base()
        {
            ToDownload = true;
            IsDownloaded = false;
            this.Duration = song.Duration;
            this.Image = song.Image;
            this.ImageUrl = song.ImageUrl;
            this.SongData = song.SongData;
            this.Title = song.Title;
        }
    }
}
