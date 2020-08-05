using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;
        Service service = new Service();


        public MainWindowViewModel(MainWindow mainOpen, tblUser user)
        {
            main = mainOpen;
            User = user;
        }

        #region Properties
        private tblUser user;
        public tblUser User
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
                        MessageBox.Show("Song is deleted");
                        SongList = service.UsersSongs(User);
                    }
                    else
                    {
                        MessageBox.Show("Song cannot be deleted");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
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
        #endregion
    }
}

