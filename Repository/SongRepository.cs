using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Exceptions;
using FullSteamDrumMachine.net.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Repository
{
    public class SongRepository : ISongRepository
    {
        private MySqlConnection _connection = new MySqlConnection();

        public SongRepository()
        {
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DrumMachineDb"].ConnectionString;
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
            List<Song> result = new List<Song>();
            using(MySqlConnection connection = _connection)
            {
                try
                {
                    _connection.Open();
                    MySqlCommand command = _connection.CreateCommand();
                    command.CommandText = "SELECT * FROM song";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Song((int)reader["songId"], (string)reader["name"], (int)reader["bpm"]));
                    }
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException("Failed to retrieve songs", e);
                }
            }

            return result;
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
