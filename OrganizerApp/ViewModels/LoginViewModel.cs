using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizerApp.Models;

namespace OrganizerApp.ViewModels
{
    public class LoginViewModel
    {

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
