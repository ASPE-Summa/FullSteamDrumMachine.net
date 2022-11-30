using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Exceptions;
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
        private string connectionString = ConfigurationManager.ConnectionStrings["DrumMachineDb"].ConnectionString;

        public void addToSong(Measure measure, Song song, int sequence)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO SongMeasure(songId, measureId, sequence) VALUES(@songId, @measureId, @sequence);";
                    cmd.Parameters.AddWithValue("@songId", song.SongId);
                    cmd.Parameters.AddWithValue("@measureId", measure.MeasureId);
                    cmd.Parameters.AddWithValue("@sequence", sequence);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new DataPersistanceException($"Failed to add measure {measure.Name} to song {song.Name}", e);
                }
            }
        }

        public int countUseages(Measure measure)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT COUNT(*) as useages FROM SongMeasure WHERE measureId = @measureId";
                    cmd.Parameters.AddWithValue("@measureId", measure.MeasureId);
                    return Int32.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException("Failed count useages of measure in song", e);
                }
            }
        }

        public Measure createMeasure(string measureName)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO Measure(name, beatUnit, beatsInMeasure) VALUES(@name, 4, 4)";
                    cmd.Parameters.AddWithValue("@name", measureName);
                    cmd.ExecuteNonQuery();
                    if (cmd.LastInsertedId != -1)
                    {
                        return findById((int)cmd.LastInsertedId);
                    }
                    throw new DataPersistanceException("Attempted to create new Measure, but no generated key returned.");

                }
                catch (Exception e)
                {
                    throw new DataPersistanceException($"Failed to create measure {measureName}", e);
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
                    cmd.CommandText = "DELETE FROM measure WHERE measureId = @measureId;";
                    cmd.Parameters.AddWithValue("@measureId", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new DataPersistanceException($"Failed to delete measure with id {id}", e);
                }
            }
        }

        public ICollection<Measure> fetchAll()
        {
            List<Measure> result = new List<Measure>();
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Measure ORDER BY name ASC;";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Measure((int)reader["measureId"], (int)reader["beatUnit"], (int)reader["beatsInMeasure"], (string)reader["name"]));
                    }
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException("Failed to retrieve songs", e);
                }
            }

            return result;
        }

        public ICollection<SongMeasure> fetchForSong(Song song)
        {
            List<SongMeasure> result = new List<SongMeasure>();
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM SongMeasure WHERE songId = @songId ORDER BY sequence ASC;";
                    command.Parameters.AddWithValue("@songId", song.SongId);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new SongMeasure((int)reader["songMeasureId"], song, findById((int)reader["measureId"])));
                    }
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException("Failed to retrieve measures for song", e);
                }
            }

            return result;
        }

        public Measure findById(int id)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM measure WHERE measureId = @measureId;";
                    command.Parameters.AddWithValue("@measureId", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new Measure((int)reader["measureId"], (int)reader["beatUnit"], (int)reader["beatsInMeasure"], (string)reader["name"]);
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException($"Failed to retrieve song with id {id}", e);
                }
            }
        }

        public void removeFromSong(SongMeasure songMeasure)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM songmeasure WHERE songMeasureId = @songMeasureId;";
                    command.Parameters.AddWithValue("@songMeasureId", songMeasure.SongMeasureId);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException($"Failed to remove songMeasure with id {songMeasure.SongMeasureId}", e);
                }
            }
        }
    }
}
