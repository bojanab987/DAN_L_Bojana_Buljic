using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
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

        public AddViewModel(AddView songView, vwUser user)
        {
            this.songView = songView;
            User = user;
            Song = new vwSong();
        }

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        public void SaveExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save this song?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool isAdded = service.AddSong(User, Song);
                    if (isAdded == true)
                    {
                        MessageBox.Show("Song is added.", "Notification", MessageBoxButton.OK);
                        songView.Close();
                    }
                    else
                    {
                        MessageBox.Show("Song cannot be added.", "Notification", MessageBoxButton.OK);
                        songView.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Song.SongName) || String.IsNullOrEmpty(Song.SongAuthor) || String.IsNullOrEmpty(Song.SongDuration.ToString())
                || Song.SongDuration.ToString() == "00:00:00")
            {
                MessageBox.Show("Please fill all fields to save song.", "Notification");
                return false;
            }
            else
            {
                return true;
            }
        }


        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        public void CancelExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel adding the song?", "Be sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    songView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
