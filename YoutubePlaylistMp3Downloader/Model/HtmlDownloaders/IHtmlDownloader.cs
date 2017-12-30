using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistMp3Downloader.Model.HtmlDownloaders
{
    interface IHtmlDownloader
    {
        string Url { get; set; }
        Task<string> DownloadContent();
    }
}
