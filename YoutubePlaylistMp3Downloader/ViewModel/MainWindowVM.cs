using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubePlaylistMp3Downloader.Helpers;
using YoutubePlaylistMp3Downloader.Model;
using YoutubePlaylistMp3Downloader.Model.HtmlDownloaders;
using YoutubePlaylistMp3Downloader.Model.Parsers;

namespace YoutubePlaylistMp3Downloader.ViewModel
{
    class MainWindowVM : BaseViewModel
    {
        #region Private Fields
        private string url;
        private ObservableCollection<Song> songs;
        #endregion

        #region Public Fields
        public string Url
        {
            get { return url; }
            set { url = value; OnChange("Url"); }
        }
        public ObservableCollection<Song> Songs
        {
            get { return songs; }
            set { songs = value; OnChange("Songs"); }
        }
        #endregion

        #region Commands
        public ICommand NewUrlButtonClick { get; set; }
        #endregion

        #region Methods
        public MainWindowVM() : base()
        {
            NewUrlButtonClick = new RelayCommand(DownloadContentFromUrl);
            Url = "https://www.youtube.com/playlist?list=PLf4wgrxbZhM_YlnAnD-c786qMwiwnbYY5";
            Songs = new ObservableCollection<Song>();
        }

        private async void DownloadContentFromUrl(object parameter)
        {
            YoutubeHtmlDownloader downloader = new YoutubeHtmlDownloader(Url);
            YoutubeParser parser = new YoutubeParser();
            string content = await downloader.DownloadContent();
            parser.Text = content;
            var songs = parser.Parse();

            foreach (var song in songs)
            {
                try
                {
                    song.Image = await ContentDownloader.DownloadContent(song.ImageUrl);
                    Songs.Add(song);
                }
                catch (Exception exc) { }
            }
        }
        #endregion
    }
}
