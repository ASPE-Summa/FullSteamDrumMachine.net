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

        private int songId;
        public int SongId { get { return songId; } }

        private int measureId;
        public int MeasureId { get { return measureId; } }

        private int sequence;
        public int Sequence { get { return sequence; } }

        public SongMeasure(int songMeasureId, int songId, int measureId, int sequence)
        {
            this.songMeasureId = songMeasureId;
            this.songId = songId;
            this.measureId = measureId;
            this.sequence = sequence;
        }
    }
}
