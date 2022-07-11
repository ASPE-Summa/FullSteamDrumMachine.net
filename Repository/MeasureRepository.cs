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
    public class MeasureRepository : IMeasureRepository
    {
        private MySqlConnection connection = new MySqlConnection();
        public MySqlConnection Connection { get { return connection; } }

        public MeasureRepository()
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DrumMachineDb"].ConnectionString;
        }

        public void addToSong(Measure measure, Song song, int sequence)
        {
            throw new NotImplementedException();
        }

        public int countUseages(Measure measure)
        {
            throw new NotImplementedException();
        }

        public Measure createMeasure(Measure measure)
        {
            throw new NotImplementedException();
        }

        public void deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Measure> fetchAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<SongMeasure> fetchForSong(Song song)
        {
            throw new NotImplementedException();
        }

        public Measure findById(int id)
        {
            throw new NotImplementedException();
        }

        public void removeFromSong(SongMeasure songMeasure)
        {
            throw new NotImplementedException();
        }
    }
}
