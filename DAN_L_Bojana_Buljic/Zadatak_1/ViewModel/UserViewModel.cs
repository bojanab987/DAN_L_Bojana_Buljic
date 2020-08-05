using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Model;
using Zadatak_1.Services;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class UserViewModel:ViewModelBase
    {
        UserView userView;
        Service service = new Service();

        #region Constructor
        public UserViewModel(UserView userView, vwUser user)
        {
            this.userView = userView;
            User = user;
            SongList = service.GetUsersSongs(User);
        }
        #endregion

        #region Properties
        private vwUser user;
        public vwUser User
        {
            get { return user; }
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

        private List<vwSong> songList;
        public List<vwSong> SongList
        {
            get
            {
                return songList;
            }
            set
            {
                songList = value;
                OnPropertyChanged("SongList");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Add song Command
        /// </summary>
        private ICommand addSong;
        public ICommand AddSong
        {
            get
            {
                if (addSong == null)
                {
                    addSong = new RelayCommand(param => AddSongExecute(), param => CanAddSongExecute());
                }
                return addSong;
            }
        }        

        /// <summary>
        /// Method to execute add song command, opens the add view for adding new song
        /// </summary>
        public void AddSongExecute()
        {
            try
            {
                AddView addView = new AddView(User);
                addView.ShowDialog();
                SongList = service.GetUsersSongs(User);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Method checks if add song command can be executed
        /// </summary>
        /// <returns></returns>
        public bool CanAddSongExecute()
        {
            return true;
        }

        /// <summary>
        /// Command for deleting song
        /// </summary>
        private ICommand deleteSong;
        public ICommand DeleteSong
        {
            get
            {
                if (deleteSong == null)
                {
                    deleteSong = new RelayCommand(param => DeleteSongExecute(), param => CanDeleteSongExecute());
                }
                return deleteSong;
            }
        }        

        /// <summary>
        /// Method to execute delete command...deleting song
        /// </summary>
        public void DeleteSongExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the song?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool isDeleted = service.DeleteSong(Song);
                    if (isDeleted)
                    {
                        MessageBox.Show("Song is deleted", "Notification");
                        SongList = service.GetUsersSongs(User);
                    }
                    else
                    {
                        MessageBox.Show("Song cannot be deleted", "Notification");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Method checks if delete command can be executed
        /// </summary>
        /// <returns>true or false</returns>
        public bool CanDeleteSongExecute()
        {
            if (Song != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Command for sorting song ascending by song duration
        /// </summary>
        private ICommand durationAsc;
        public ICommand DurationAsc
        {
            get
            {
                if (durationAsc == null)
                {
                    durationAsc = new RelayCommand(param => DurationAscExecute(), param => CanDurationAscExecute());
                }
                return durationAsc;
            }
        }        

        public void DurationAscExecute()
        {
            SongList = service.SortDurationAsc(User);
        }

        public bool CanDurationAscExecute()
        {
            return true;
        }

        /// <summary>
        /// Command for sorting sond descending by song duration
        /// </summary>
        private ICommand durationDesc;
        public ICommand DurationDesc
        {
            get
            {
                if (durationDesc == null)
                {
                    durationDesc = new RelayCommand(param => DurationDescExecute(), param => CanDurationDescExecute());
                }
                return durationDesc;
            }
        }        

        public void DurationDescExecute()
        {
            SongList = service.SortDurationDesc(User);
        }

        public bool CanDurationDescExecute()
        {
            return true;
        }

        /// <summary>
        /// Comand for sorting songs ascending by song name
        /// </summary>
        private ICommand nameAsc;
        public ICommand NameAsc
        {
            get
            {
                if (nameAsc == null)
                {
                    nameAsc = new RelayCommand(param => NameAscExecute(), param => CanNameAscExecute());
                }
                return nameAsc;
            }
        }        

        public void NameAscExecute()
        {
            SongList = service.SortNameAsc(User);
        }

        public bool CanNameAscExecute()
        {
            return true;
        }

        /// <summary>
        /// Comand for sorting songs descending by song name
        /// </summary>
        private ICommand nameDesc;
        public ICommand NameDesc
        {
            get
            {
                if (nameDesc == null)
                {
                    nameDesc = new RelayCommand(param => NameDescExecute(), param => CanNameDescExecute());
                }
                return nameDesc;
            }
        }        

        public void NameDescExecute()
        {
            SongList = service.SortNameDesc(User);
        }

        public bool CanNameDescExecute()
        {
            return true;
        }

        /// <summary>
        /// Command that logs out the user
        /// </summary>
        private ICommand logOut;
        public ICommand LogOut
        {
            get
            {
                if (logOut == null)
                {
                    logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return logOut;
            }
        }

        /// <summary>
        /// Executes the logOut command
        /// </summary>
        private void LogOutExecute()
        {
            try
            {
                LoginView login = new LoginView();
                userView.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to logOut
        /// </summary>
        /// <returns>true</returns>
        private bool CanLogOutExecute()
        {
            return true;
        }


        /// <summary>
        /// Command for start playing the selected song
        /// </summary>
        private ICommand playSong;
        public ICommand PlaySong
        {
            get
            {
                if (playSong == null)
                {
                    playSong = new RelayCommand(param => PlaySongExecute(), param => CanPlaySongExecute());
                }
                return playSong;
            }
        }

        /// <summary>
        /// Executes the play song command
        /// </summary>
        private void PlaySongExecute()
        {
            try
            {
                MessageBox.Show("Song is playing......");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to logOut
        /// </summary>
        /// <returns>true</returns>
        private bool CanPlaySongExecute()
        {
            return true;
        }
        #endregion

    }
}
