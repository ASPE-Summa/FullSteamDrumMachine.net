﻿using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Service
{
    public class InstrumentManager : IInstrumentManager
    {
        public ICollection<Instrument> getInstrumentCollectionForMeasure(Measure measure)
        {
            throw new NotImplementedException();
        }

        public ICollection<Instrument> getReuseOptionCollection(Measure measure)
        {
            throw new NotImplementedException();
        }

        public void playNote(int midiKey)
        {
            throw new NotImplementedException();
        }

        public void removeInstrument(Measure measure, Instrument instrument)
        {
            throw new NotImplementedException();
        }

        public void reuseInstrument(Instrument instrument, Measure measure)
        {
            throw new NotImplementedException();
        }

        public void saveNewInstrument(string name, int midiNumber, Measure measure)
        {
            throw new NotImplementedException();
        }

        public void updateBeat(Measure measure, Instrument instrument, string beatNotes)
        {
            throw new NotImplementedException();
        }
    }
}
