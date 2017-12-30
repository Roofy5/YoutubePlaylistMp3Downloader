using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlaylistMp3Downloader.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnChange(params string[] properties)
        {
            if (PropertyChanged == null)
                return;
            foreach (var property in properties)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
