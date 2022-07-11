using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Service
{
    public class MusicPlayer : IMusicPlayer
    {
        public void playMeasure(int bpm, Measure measure)
        {
            throw new NotImplementedException();
        }

        public void playNote(int value)
        {
            throw new NotImplementedException();
        }

        public void playSong(Song song)
        {
            throw new NotImplementedException();
        }
    }
}
