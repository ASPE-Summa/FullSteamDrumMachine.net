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
    public class MeasureManager : IMeasureManager
    {
        private IMeasureRepository _measureRepository = new MeasureRepository();
        public void addToSong(Song song, Measure measure, int sequence)
        {
            try
            {
                _measureRepository.addToSong(measure, song, sequence);
            }
            catch (DataPersistanceException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void createForSong(string measureName, Song song, int sequence)
        {
            try
            {
                Measure measure = _measureRepository.createMeasure(measureName);
                _measureRepository.addToSong(measure, song, sequence);
            }
            catch (DataPersistanceException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void deleteMeasure(Measure measure)
        {
            try
            {
                _measureRepository.deleteById(measure.MeasureId);
            }
            catch (DataRemovalException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void deleteSongMeasure(SongMeasure songMeasure)
        {
            try
            {
                _measureRepository.removeFromSong(songMeasure);
            }
            catch (DataRemovalException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public ObservableCollection<Measure> getAllMeasures()
        {
            ObservableCollection<Measure> result = new();
            try
            {
                ICollection<Measure> measures = _measureRepository.fetchAll();
                foreach (Measure measure in measures)
                {
                    result.Add(measure);
                }
            }
            catch (DataRetrievalException e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }

        public ObservableCollection<SongMeasure> getSongMeasureCollection(Song song)
        {
            ObservableCollection<SongMeasure> result = new();
            try
            {
                ICollection<SongMeasure> measures = _measureRepository.fetchForSong(song);
                foreach (SongMeasure measure in measures)
                {
                    result.Add(measure);
                }
            }
            catch (DataRetrievalException e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }

        public bool isOnlyInstance(Measure measure)
        {
            try
            {
                int useages = _measureRepository.countUseages(measure);
                return useages == 1;
            }
            catch (DataRetrievalException e)
            {
                MessageBox.Show(e.Message);
            }

            // Return false so the system doesn't delete more than it should in any case.
            // It's easier to remove unnecesary data than to try and restore necessary data that was removed.
            return false;
        }

        public void playMeasure(Measure measure, int bpm)
        {
            throw new NotImplementedException();
        }
    }
}
