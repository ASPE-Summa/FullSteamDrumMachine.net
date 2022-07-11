using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Repository
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private MySqlConnection connection = new MySqlConnection();
        public MySqlConnection Connection { get { return connection; } }

        public InstrumentRepository()
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DrumMachineDb"].ConnectionString;
        }

        public void addToMeasure(Instrument instrument, Measure measure)
        {
            throw new NotImplementedException();
        }

        public Instrument createInstrument(string name, int midiNumber)
        {
            throw new NotImplementedException();
        }

        public void deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Instrument> fetchAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Instrument> fetchForMeasure(Measure measure)
        {
            throw new NotImplementedException();
        }

        public ICollection<Instrument> fetchReuseOptionCollection(Measure measure)
        {
            throw new NotImplementedException();
        }

        public Instrument findById(int id)
        {
            throw new NotImplementedException();
        }

        public void removeFromMeasure(Measure measure, Instrument instrument)
        {
            throw new NotImplementedException();
        }

        public void updateBeat(Measure measure, Instrument instrument, string encodedBeat)
        {
            throw new NotImplementedException();
        }
    }
}
