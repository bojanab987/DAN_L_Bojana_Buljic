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
        public string PasswordChecker(string password)
        {
            int upperCaseChars = 0;

            //check if password lenght is minimum 6 characters
            if (password == null || !(password.Length < 6))
            {
                return null;
            }

            //check if password contains 2 uppercase characters
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    upperCaseChars++;
                    if (upperCaseChars == 2)
                    {
                        break;
                    }
                }
            }

            if (upperCaseChars < 2)
            {
                return null;
            }
            return password;
        }
    }
}
