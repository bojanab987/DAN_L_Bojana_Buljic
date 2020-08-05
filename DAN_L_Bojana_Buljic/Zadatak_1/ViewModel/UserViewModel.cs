using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class UserViewModel:ViewModelBase
    {
        UserView userView;

        private vwUser user;
        public vwUser User
        {
            get{ return user;}
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public UserViewModel(UserView userView, vwUser user)
        {
            this.userView = userView;
            User = user;
        }
    }
}
