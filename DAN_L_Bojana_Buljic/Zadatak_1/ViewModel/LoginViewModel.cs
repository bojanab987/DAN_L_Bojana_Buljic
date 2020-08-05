using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Model;
using Zadatak_1.Services;
using Zadatak_1.Validations;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        LoginView login;
        Service service = new Service();
        ValidationClass val = new ValidationClass();

        #region Properties
        public vwUser User { get; set; }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel(LoginView login)
        {
            this.login = login;
        }
        #endregion

        #region Commands
        private ICommand logIn;
        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(LogInExecute, CanLogInExecute);
                }
                return logIn;
            }
        }

        /// <summary>
        /// This method checks if username and password are valid.
        /// </summary>
        /// <param name="password">User input for password.</param>
        public void LogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (service.GetUserByUsername(Username) != null)
            {
                User = service.GetUserByUsername(Username);
                UserView userView = new UserView(User);
                login.Close();
                userView.ShowDialog();
            }
            else if (val.IsUniqueUsername(Username) == true)
            {
                if (val.PasswordChecker(Password) == true)
                {
                    if (service.AddUser(Username, Password) == true)
                    {
                        MessageBox.Show("Successful registration.", "Notification");
                        User = service.GetUserByUsername(Username);
                        UserView userView = new UserView(User);
                        userView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Registration Failed!", "Error");
                    }

                }
                else
                {
                    MessageBox.Show("The password must have minimum 6 characters with 2  uppercases.", "Notification");
                }

            }
            else
            {
                MessageBox.Show("Wrong username or password. Please, try again.", "Notification");
            }
        }

        /// <summary>
        /// Method checks if login can be executed.
        /// </summary>
        /// <param name="password">User input for password.</param>
        /// <returns>True if login can execute, false if not.</returns>
        public bool CanLogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
