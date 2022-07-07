﻿using FullSteamDrumMachine.net.Model;
using System.Collections.Generic;

namespace FullSteamDrumMachine.net.Service.Interfaces
{
    public interface ISongManager
    {
        public ICollection<Song> getSongCollection();

        public void createSong(string songName);

        public void deleteSong(Song song);

        public bool playSong(Song song);

        public void updateBpm(Song song, int bpmValue);

        public Song findSong(int id);
    }
}
