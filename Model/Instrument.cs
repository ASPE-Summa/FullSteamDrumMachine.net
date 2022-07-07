using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Model
{
    public class Instrument
    {
        private int instrumentId;
        public int InstrumentId { get { return instrumentId; } }

        private string name;
        public string Name { get { return name; } }

        private int midiNumber;
        public int MidiNumber { get { return midiNumber; } }

        private string beat = "0000000000000000";
        public string Beat { get { return beat; } }

        public Instrument(int instrumentId, string name, int midiNumber, string beat)
        {
            this.instrumentId = instrumentId;
            this.name = name;
            this.midiNumber = midiNumber;
            this.beat = beat;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
