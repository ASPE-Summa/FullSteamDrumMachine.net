using FullSteamDrumMachine.net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Service.Interfaces
{
    public interface IMeasureManager
    {
        public ICollection<SongMeasure> getSongMeasureCollection(Song song);

        public void deleteSongMeasure(SongMeasure songMeasure);

        public void playMeasure(Measure measure, int bpm);

        public List<Measure> getAllMeasures();

        public void addToSong(Song song, Measure measure, int sequence);

        public void createForSong(Measure measure, Song song, int sequence);

        public bool isOnlyInstance(Measure measure);

        public void deleteMeasure(Measure measure);
    }
}
