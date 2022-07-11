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
    public class SongRepository : ISongRepository
    {
        private MySqlConnection connection = new MySqlConnection();
        public MySqlConnection Connection { get { return connection; } }

        public SongRepository()
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DrumMachineDb"].ConnectionString;
        }

        public void createSong(string songName)
        {
            throw new NotImplementedException();
        }

        public void deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Song> fetchAll()
        {
            throw new NotImplementedException();
        }

        public Song findById(int id)
        {
            throw new NotImplementedException();
        }

        public void updateBpm(Song song, int bpmValue)
        {
            throw new NotImplementedException();
        }
    }
}
