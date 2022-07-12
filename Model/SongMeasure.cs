using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Model
{
    public class SongMeasure
    {
        private int songMeasureId;
        public int SongMeasureId { get { return songMeasureId; } }

        private Song song;
        public Song Song { get { return song; } }

        private Measure measure;
        public Measure Measure { get { return measure; } }


        public SongMeasure(int songMeasureId, Song song, Measure measure)
        {
            this.songMeasureId = songMeasureId;
            this.song = song;
            this.measure = measure;
        }

        public override string ToString()
        {
            return measure.Name;
        }
    }
}
