using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository;
using FullSteamDrumMachine.net.Repository.Exceptions;
using FullSteamDrumMachine.net.Repository.Interfaces;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FullSteamDrumMachine.net.Service
{
    public class InstrumentManager : IInstrumentManager
    {
        private IInstrumentRepository _instrumentRepository = new InstrumentRepository();
        
        public ICollection<Instrument> getInstrumentCollectionForMeasure(Measure measure)
        {
            try
            {
                return _instrumentRepository.fetchForMeasure(measure);
 
            }
            catch (DataRetrievalException e)
            {
                MessageBox.Show(e.Message);
                return new List<Instrument>();
            }
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
