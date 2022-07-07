using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Model
{
    public class Measure
    {
        private int measureId;
        public int MeasureId { get { return measureId; } }

        private int beatUnit = 4;
        public int BeatUnit { get { return beatUnit; } }

        private int beatsInMeasure = 4;
        public int BeatsInMeasure { get { return beatsInMeasure; } }

        private string name;
        public string Name { get { return name; } }

        public Measure(int measureId, int beatUnit, int beatsInMeasure, string name)
        {
            this.measureId = measureId;
            this.beatUnit = beatUnit;
            this.beatsInMeasure = beatsInMeasure;
            this.name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
