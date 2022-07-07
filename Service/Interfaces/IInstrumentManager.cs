using FullSteamDrumMachine.net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Service.Interfaces
{
    public interface IInstrumentManager
    {
        public void removeInstrument(Measure measure, Instrument instrument);

        public void saveNewInstrument(String name, int midiNumber, Measure measure);

        public void reuseInstrument(Instrument instrument, Measure measure);

        public void updateBeat(Measure measure, Instrument instrument, String beatNotes);

        public void playNote(int midiKey);

        public ICollection<Instrument> getReuseOptionCollection(Measure measure);

        public ICollection<Instrument> getInstrumentCollectionForMeasure(Measure measure);
    }
}
