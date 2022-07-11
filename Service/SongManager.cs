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
    public class SongManager : ISongManager
    {
        private ISongRepository _songRepository;

        public SongManager()
        {
            _songRepository = new SongRepository();
        }
        public void createSong(string songName)
        {
            try
            {
                _songRepository.createSong(songName);
            }
            catch(DataPersistanceException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void deleteSong(Song song)
        {
            try
            {
                _songRepository.deleteById(song.SongId);
            }
            catch(DataRemovalException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public Song findSong(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Song> getSongCollection()
        {

           ObservableCollection<Song> result = new ObservableCollection<Song>();
            try
            {
                ICollection<Song> songs = _songRepository.fetchAll();

                foreach (Song song in songs)
                {
                    result.Add(song);
                }
            }
            catch(DataRetrievalException e)
            {
                MessageBox.Show(e.Message);
            }

            return result;
        }

        public bool playSong(Song song)
        {
            throw new NotImplementedException();
        }

        public void updateBpm(Song song, int bpmValue)
        {
            try
            {
                _songRepository.updateBpm(song, bpmValue);
            }
            catch (DataRemovalException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
