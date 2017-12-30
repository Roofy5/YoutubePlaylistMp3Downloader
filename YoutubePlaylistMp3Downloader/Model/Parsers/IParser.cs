using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistMp3Downloader.Model.Parsers
{
    interface IParser
    {
        string Text { get; set; }
        List<Song> Parse();
    }
}
