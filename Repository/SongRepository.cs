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
using System.Windows;

namespace FullSteamDrumMachine.net.Repository
{
    public class SongRepository : ISongRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DrumMachineDb"].ConnectionString;

        public void createSong(string songName)
        {
            using (MySqlConnection connection = new (connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO song(name,bpm) VALUES(@songName, 95);";
                    cmd.Parameters.AddWithValue("@songName", songName);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    throw new DataPersistanceException($"Failed to insert song {songName}", e);
                }
            }
        }

        public void deleteById(int id)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM song WHERE songId = @songId;";
                    cmd.Parameters.AddWithValue("@songId", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new DataPersistanceException($"Failed to delete song with id {id}", e);
                }
            }
        }

        public ICollection<Song> fetchAll()
        {
            List<Song> result = new List<Song>();
            using(MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM song ORDER BY name ASC;";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Song s = new Song((int)reader["songId"], (string)reader["name"], (int)reader["bpm"]);
                        result.Add(s);
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
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM song WHERE songId = @songId;";
                    command.Parameters.AddWithValue("@songId", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    return new Song((int)reader["songId"], (string)reader["name"], (int)reader["bpm"]);
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException($"Failed to retrieve song with id {id}", e);
                }
            }
        }

        public void updateBpm(Song song, int bpmValue)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE song SET bpm = @bpm WHERE songId = @songId";
                    cmd.Parameters.AddWithValue("@songId", song.SongId);
                    cmd.Parameters.AddWithValue("@bpm", bpmValue);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new DataPersistanceException($"Failed to update bpm for song {song.Name}", e);
                }
            }
        }
    }
}
