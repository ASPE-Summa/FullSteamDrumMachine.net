using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Exceptions;
using FullSteamDrumMachine.net.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Controls.Primitives;

namespace FullSteamDrumMachine.net.Repository
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DrumMachineDb"].ConnectionString;

        public void addToMeasure(Instrument instrument, Measure measure)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO measureInstrument(measureId, instrumentId, beat) VALUES(@measureId, @instrumentId, @beat);";
                    cmd.Parameters.AddWithValue("@measureId", measure.MeasureId);
                    cmd.Parameters.AddWithValue("@instrumentId", instrument.InstrumentId);
                    cmd.Parameters.AddWithValue("@beat", instrument.Beat);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new DataPersistanceException($"Failed to add instrument {instrument.Name} to measure {measure.Name}", e);
                }
            }
        }

        public Instrument createInstrument(string name, int midiNumber)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO instrument(name, midiNumber) VALUES(@name, @midiNumber)";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@midiNumber", midiNumber);
                    cmd.ExecuteNonQuery();
                    if (cmd.LastInsertedId != -1)
                    {
                        return findById((int)cmd.LastInsertedId);
                    }
                    throw new DataPersistanceException("Attempted to create new Instrument, but no generated key returned.");

                }
                catch (Exception e)
                {
                    throw new DataPersistanceException($"Failed to create Instrument {name}", e);
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

        public ICollection<Instrument> fetchAll()
        {
            List<Instrument> result = new List<Instrument>();
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM instrument ORDER BY name ASC;";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<ToggleButton> beatList = new();
                        result.Add(new Instrument((int)reader["instrumentId"], (string)reader["name"], (int)reader["midiNumber"], beatList));
                    }
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException("Failed to retrieve songs", e);
                }
            }

            return result;
        }

        public ICollection<Instrument> fetchForMeasure(Measure measure)
        {
            List<Instrument> result = new List<Instrument>();
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM instrument i JOIN MeasureInstrument mi ON mi.instrumentId = i.instrumentId WHERE mi.measureId = @measureId ORDER BY name DESC;";
                    command.Parameters.AddWithValue("@measureId", measure.MeasureId);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<ToggleButton> beat = new();
                        foreach (char character in (string)reader["beat"])
                        {
                            ToggleButton c = new ToggleButton();
                            c.IsChecked = character != '0';
                            beat.Add(c);
                        }
                        result.Add(new Instrument((int)reader["instrumentId"], (string)reader["name"], (int)reader["midiNumber"], beat));
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw new DataRetrievalException("Failed to retrieve instruments", e);
                }
            }

            return result;
        }

        public ICollection<Instrument> fetchReuseOptionCollection(Measure measure)
        {
            List<Instrument> result = new List<Instrument>();
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM instrument i WHERE instrumentId NOT IN (SELECT instrumentId FROM measureInstrument WHERE measureId = @measureId) ORDER BY i.name ASC;";
                    command.Parameters.AddWithValue("@measureId", measure.MeasureId);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Instrument((int)reader["instrumentId"], (string)reader["name"], (int)reader["midiNumber"]));
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw new DataRetrievalException("Failed to retrieve instruments", e);
                }
            }

            return result;
        }

        public Instrument findById(int id)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM instrument WHERE instrumentId = @instrumentId;";
                    command.Parameters.AddWithValue("@instrumentId", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new Instrument((int)reader["instrumentId"], (string)reader["name"], (int)reader["midiNumber"]);
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException($"Failed to retrieve song with id {id}", e);
                }
            }
        }

        public void removeFromMeasure(Measure measure, Instrument instrument)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM measureInstrument WHERE measureId = @measureId AND instrumentId = @instrumentId;";
                    command.Parameters.AddWithValue("@measureId", measure.MeasureId);
                    command.Parameters.AddWithValue("@instrumentId", instrument.InstrumentId);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch (Exception e)
                {
                    throw new DataRetrievalException($"Failed to remove instrument {instrument.Name}", e);
                }
            }
        }

        public void updateBeat(Measure measure, Instrument instrument, string encodedBeat)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE MeasureInstrument SET beat = @beat WHERE measureId = @measureId AND instrumentId = @instrumentId";
                    cmd.Parameters.AddWithValue("@measureId", measure.MeasureId);
                    cmd.Parameters.AddWithValue("@instrumentId", instrument.InstrumentId);
                    cmd.Parameters.AddWithValue("@beat", encodedBeat);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new DataPersistanceException($"Failed to update beat for instrument {instrument.Name}", e);
                }
            }
        }
    }
}
