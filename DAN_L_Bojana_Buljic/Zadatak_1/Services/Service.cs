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

        /// <summary>
        /// Gets all songs from database
        /// </summary>
        /// <returns>list of songs</returns>
        public List<tblSong> GetAllSongs()
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    List<tblSong> list = new List<tblSong>();
                    list = (from x in context.tblSongs select x).ToList();
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

