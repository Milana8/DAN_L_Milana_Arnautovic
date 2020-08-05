using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        LoginView view;
        Service service = new Service();

        #region Constructors

        public LoginViewModel(LoginView view)
        {
            this.view = view;
            user = new tblUser();
            UserList = service.GetAllUsers().ToList();

        }
        #endregion

        #region Property

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
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

        private List<tblUser> userList;
        public List<tblUser> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }

        private tblUser user;
        public tblUser User
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



        #endregion

        #region Commands
        private ICommand login;
        /// <summary>
        /// Command login
        /// </summary>
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute);
                }
                return login;
            }
            set { login = value; }
        }
        /// <summary>
        /// Method for checking username and password
        /// </summary>
        /// <param name="o"></param>
        private void LoginExecute(object o)
        {
            try
            {
                string pasword = (o as PasswordBox).Password;
                if (IsUniqueUsername(UserName) == true)
                {
                    MainWindow mw = new MainWindow();
                    view.Close();
                    mw.ShowDialog();
                }


                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #endregion

        public bool IsUniqueUsername(string username)
        {
            Service service = new Service();
            List<tblUser> userList = service.GetAllUsers();
            var list = userList.Where(x => x.Username == username).ToList();
            if (list.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       
    }
}
    
