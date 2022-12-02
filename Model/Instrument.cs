using Org.BouncyCastle.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

        private List<ToggleButton> beat = new();
        public List<ToggleButton> Beat { get { return beat;} }

        public Instrument(int instrumentId, string name, int midiNumber)
        {
            this.instrumentId = instrumentId;
            this.name = name;
            this.midiNumber = midiNumber;
        }

        public Instrument(int instrumentId, string name, int midiNumber,List<ToggleButton> beat)
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
