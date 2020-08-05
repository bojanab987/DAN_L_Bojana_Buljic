using System;
using System.Collections.Generic;
using System.Linq;
using Zadatak_1.Model;
using Zadatak_1.Services;

namespace Zadatak_1.Validations
{
    class ValidationClass
    {
        /// <summary>
        /// This method checks if forwarded username is unique.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsUniqueUsername(string username)
        {
            Service service = new Service();
            List<tblUser> userList = service.GetAllUsers();
            var list = userList.Where(x => x.Username == username).ToList();
            //check if exists user with forwarded username
            if (list.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if the password is correct
        /// </summary>
        /// <param name="password">the password we are checking</param>  
        /// <returns>true if correct password, false if not</returns>
        public bool PasswordChecker(string password)
        {
            if (password.Length >= 6)
            {
                var list = password.Where(Char.IsUpper).ToList();
                if (list.Count >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }        

    }
}
