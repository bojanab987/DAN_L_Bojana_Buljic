using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Model;

namespace Zadatak_1.Services
{
    class Service
    {
        #region User service methods
        /// <summary>
        /// Gets all users from database
        /// </summary>
        /// <returns>list of users</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    List<tblUser> list = new List<tblUser>();
                    list = (from x in context.tblUsers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets user by forwarded username.
        /// </summary>
        /// <param name="username">User's username</param>        
        /// <returns>User.</returns>
        public vwUser GetUserByUsername(string username)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwUsers.Where(x => x.Username == username).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Adds the user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>true for created user, false if not</returns>
        public bool AddUser(string username, string password)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    tblUser user = new tblUser
                    {
                        Password = password,
                        Username = username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        #endregion

        #region Songs service methods
        /// <summary>
        /// Gets all songs of a logged in user from database
        /// </summary>
        /// <returns>list of songs</returns>
        public List<vwSong> GetUsersSongs(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method for adding song by user
        /// </summary>
        /// <param name="user">user which is adding song</param>
        /// <param name="song">song for adding</param>
        /// <returns></returns>
        public bool AddSong(vwUser user, vwSong song)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    tblSong newSong = new tblSong();
                    newSong.SongName = song.SongName;
                    newSong.SongAuthor = song.SongAuthor;
                    newSong.SongDuration = song.SongDuration;
                    newSong.UserId = user.UserId;
                    context.tblSongs.Add(newSong);
                    context.SaveChanges();
                    song.SongId = newSong.SongId;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// Method for sorting Song names ascending
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<vwSong> SortNameAsc(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).OrderBy(x => x.SongName).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method for sorting songs descending by song name
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<vwSong> SortNameDesc(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).OrderByDescending(x => x.SongName).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method for sorting songs ascending by song duration
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<vwSong> SortDurationAsc(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).OrderBy(x => x.SongDuration).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method for sorting songs descending by song duration
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<vwSong> SortDurationDesc(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).OrderByDescending(x => x.SongDuration).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }       

        /// <summary>
        /// Method for deleting song from database
        /// </summary>
        /// <param name="song"></param>
        /// <returns>true if deleted, false if not</returns>
        public bool DeleteSong(vwSong song)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    var songToDelete = context.tblSongs.Where(x => x.SongId == song.SongId).FirstOrDefault();
                    context.tblSongs.Remove(songToDelete);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }       
        #endregion

        /// <summary>
        /// Gets all played songs from database
        /// </summary>
        /// <returns>list of played songs</returns>
        public List<tblPlayedSong> GetAllPlayedSongs()
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    List<tblPlayedSong> list = new List<tblPlayedSong>();
                    list = (from x in context.tblPlayedSongs select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        


    }
}

