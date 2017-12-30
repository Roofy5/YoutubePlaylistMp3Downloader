using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.HtmlDownloaders
{
    public class Mp3JuiceHtmlDownloader : IHtmlDownloader
    {
        private string _url;
        private Song _song;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public Mp3JuiceHtmlDownloader(Song song)
        {
            _song = song;
            Url = "https://www.mp3juices.cc/";
        }
        public async Task<string> DownloadContent()
        {
            IEnumerable<KeyValuePair<string, string>> query = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("query", _song.Title)
            };
            HttpContent toSend = new FormUrlEncodedContent(query);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(Url, toSend))
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
