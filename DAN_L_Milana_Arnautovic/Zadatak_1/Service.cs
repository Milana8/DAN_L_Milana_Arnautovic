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

       
    }
}
    