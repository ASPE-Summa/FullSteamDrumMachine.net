using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Service
{
    public class SongManager : ISongManager
    {
        public void createSong(string songName)
        {
            throw new NotImplementedException();
        }

        public void deleteSong(Song song)
        {
            throw new NotImplementedException();
        }

        public Song findSong(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Song> getSongCollection()
        {
            throw new NotImplementedException();
        }

        public bool playSong(Song song)
        {
            throw new NotImplementedException();
        }

        public void updateBpm(Song song, int bpmValue)
        {
            throw new NotImplementedException();
        }
    }
}
