using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.HtmlDownloaders
{
    public class YoutubeHtmlDownloader : IHtmlDownloader
    {
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public YoutubeHtmlDownloader(string url = null)
        {
            Url = url;
        }
        public async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(Url))
                {
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }
    }
}
