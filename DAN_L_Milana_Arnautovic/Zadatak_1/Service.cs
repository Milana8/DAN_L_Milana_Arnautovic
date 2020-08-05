using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;

namespace Zadatak_1
{
    public class Service
    {
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (DAN_LEntities context = new DAN_LEntities())
                {
                    List<tblUser> users = new List<tblUser>();
                    users = context.tblUsers.ToList();
                    return users;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public List<vwSong> GetAllSong()
        {
            try
            {
                using (DAN_LEntities context = new DAN_LEntities())
                {
                    List<vwSong> songs = new List<vwSong>();
                    songs = (from x in context.vwSongs select x).ToList();
                    return songs;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool AddUser(string username, string pasword)
        {
            try
            {
                using (DAN_LEntities context = new DAN_LEntities())
                {
                    tblUser user = new tblUser
                    {
                        Pasword = pasword,
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

        public tblUser GetUserByUsername(string username)
        {
            try
            {
                using (DAN_LEntities context = new DAN_LEntities())
                {
                    return context.tblUsers.Where(x => x.Username == username).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool DeleteSong(vwSong song)
        {
            try
            {
                using (DAN_LEntities context = new DAN_LEntities())
                {
                    var songToDelete = context.tblSongs.Where(x => x.SongID == song.SongID).FirstOrDefault();
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

        public bool AddSong(tblUser user, vwSong song)
        {
            try
            {
                using (DAN_LEntities context = new DAN_LEntities())
                {
                    tblSong newSong = new tblSong();
                    newSong.SongName = song.SongName;
                    newSong.Author = song.Author;
                    newSong.Duration = song.Duration;
                    newSong.UserID = user.UserID;
                    context.tblSongs.Add(newSong);
                    context.SaveChanges();
                    song.SongID = newSong.SongID;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public List<vwSong> UsersSongs(tblUser user)
        {
            try
            {
                using (DAN_LEntities context = new DAN_LEntities())
                {
                    return context.vwSongs.Where(x => x.UserID == user.UserID).ToList();
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
    