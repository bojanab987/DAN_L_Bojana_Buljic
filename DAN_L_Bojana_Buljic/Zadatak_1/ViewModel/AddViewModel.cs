using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;
using Zadatak_1.Services;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class AddViewModel:ViewModelBase
    {
        AddView songView;
        Service service = new Service();

        private vwUser user;
        public vwUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private vwSong song;

        public vwSong Song
        {
            get
            {
                return song;
            }
            set
            {
                song = value;
                OnPropertyChanged("Song");
            }
        }

        public AddSongViewModel(AddSongView songView, vwUser user)
        {
            this.songView = songView;
            User = user;
            Song = new vwSong();
        }
    }
}
