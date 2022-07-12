using FullSteamDrumMachine.net.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FullSteamDrumMachine.net.Service.Interfaces
{
    public interface ISongManager
    {
        public ObservableCollection<Song> getSongCollection();

        public void createSong(string songName);

        public void deleteSong(Song song);

        public bool playSong(Song song);

        public void updateBpm(Song song, int bpmValue);

        public Song? findSong(int id);
    }
}
