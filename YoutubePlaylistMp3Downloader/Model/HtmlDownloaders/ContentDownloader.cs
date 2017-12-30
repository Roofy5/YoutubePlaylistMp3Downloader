using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistMp3Downloader.Model.HtmlDownloaders
{
    class ContentDownloader
    {
        public static async Task<byte[]> DownloadContent(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsByteArrayAsync();
                    }
                }
            }
        }
    }
}
