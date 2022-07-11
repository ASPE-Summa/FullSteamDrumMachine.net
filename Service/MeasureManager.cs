using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Service
{
    public class MeasureManager : IMeasureManager
    {
        public void addToSong(Song song, Measure measure, int sequence)
        {
            throw new NotImplementedException();
        }

        public void createForSong(Measure measure, Song song, int sequence)
        {
            throw new NotImplementedException();
        }

        public void deleteMeasure(Measure measure)
        {
            throw new NotImplementedException();
        }

        public void deleteSongMeasure(SongMeasure songMeasure)
        {
            throw new NotImplementedException();
        }

        public List<Measure> getAllMeasures()
        {
            throw new NotImplementedException();
        }

        public ICollection<SongMeasure> getSongMeasureCollection(Song song)
        {
            throw new NotImplementedException();
        }

        public bool isOnlyInstance(Measure measure)
        {
            throw new NotImplementedException();
        }

        public void playMeasure(Measure measure, int bpm)
        {
            throw new NotImplementedException();
        }
    }
}
