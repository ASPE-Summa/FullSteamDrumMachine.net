using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Repository.Exceptions;
using FullSteamDrumMachine.net.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms.VisualStyles;

namespace FullSteamDrumMachine.net.Repository
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DrumMachineDb"].ConnectionString;

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
            List<Instrument> result = new List<Instrument>();
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Instrument i JOIN MeasureInstrument mi ON mi.instrumentId = i.instrumentId WHERE mi.measureId = @measureId ORDER BY name DESC;";
                    command.Parameters.AddWithValue("@measureId", measure.MeasureId);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<ToggleButton> beat = new();
                        foreach(char character in (string)reader["beat"])
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
