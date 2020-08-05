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

        #region Properties
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
        #endregion

        #region Constructor
        public AddViewModel(AddView songView, vwUser user)
        {
            this.songView = songView;
            User = user;
            Song = new vwSong();
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command for saving song
        /// </summary>
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

        /// <summary>
        /// Method to execute save command and saves added song
        /// </summary>
        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(Song.SongName) || String.IsNullOrEmpty(Song.SongAuthor) || String.IsNullOrEmpty(Song.SongDuration.ToString())
               || Song.SongDuration.ToString() == "00:00:00")
            {
                MessageBox.Show("Please fill all fields to save song.", "Notification");
            }
            else
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
            
        }

        /// <summary>
        /// Method to check if save execution is possible
        /// </summary>
        /// <returns></returns>
        public bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Song.SongName) || String.IsNullOrEmpty(Song.SongAuthor) || String.IsNullOrEmpty(Song.SongDuration.ToString())
                || Song.SongDuration.ToString() == "00:00:00")
            {                
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Cancel command
        /// </summary>
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

        /// <summary>
        /// Method executing cancel command and not saving song 
        /// </summary>
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

        /// <summary>
        /// Method to check if cancel is possible to be executed
        /// </summary>
        /// <returns>true</returns>
        public bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
