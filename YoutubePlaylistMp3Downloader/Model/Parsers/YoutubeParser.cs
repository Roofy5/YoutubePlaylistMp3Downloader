using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YoutubePlaylistMp3Downloader.Model.Parsers
{
    class YoutubeParser : IParser
    {
        private const string TitlePattern = "data-title=\"(.*?)\"";
        private const string ImagePattern = "data-thumb=\"(.*?)\"";
        //private const string Pattern = "data-title=\"(.*?)\".*?data-thumb=\"(.*?)\"";
        private const string Pattern = "data-title=\"(.*?)\".*?data-thumb=\"(.*?)\".*?timestamp\">.*?>(.*?)<";

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public List<Song> Parse()
        {
            var result = new List<Song>();
            var regex = new Regex(Pattern, RegexOptions.Singleline);
            var matches = regex.Matches(Text);

            foreach (Match match in matches)
            {
                result.Add(new Song()
                {
                    Title = match.Groups[1].Value,
                    ImageUrl = match.Groups[2].Value,
                    Duration = TimeSpan.ParseExact(match.Groups[3].Value, "m\\:ss", System.Globalization.CultureInfo.InvariantCulture)
                });
            }

            return result;
        }
    }
}
